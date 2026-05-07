using Microsoft.ML;
using OnionApp.Application.Contracts;
using OnionApp.Application.Contracts.AI;
using OnionApp.Application.Features.Queries.AiQueries;
using OnionApp.Application.Features.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Persistence.ArtificialIntelligence
{
    public sealed class MlNetSmartPricingPredictionService(ICarPricingRepository carPricingRepository) : ISmartPricingPredictionService
    {
        public async Task<SmartPricingResult> PredictDailyPriceAsync(GetSmartPricingAiQuery request, CancellationToken cancellationToken = default)
        {
            var ml = new MLContext(seed: 42);

            var carPricings = await carPricingRepository.GetCarPricingWithCars();
            var historicalData = BuildTrainingRows(carPricings);

            if (!historicalData.Any())
            {
                return new SmartPricingResult
                {
                    SuggestedDailyPrice = 1500,
                    Summary = "Yeterli geçmiş veri bulunamadığı için varsayılan fiyat önerisi döndürüldü.",
                    PriceFactors = ["Veri azlığı", "Varsayılan fiyat politikası"]
                };
            }

            var trainData = ml.Data.LoadFromEnumerable(historicalData);
            var pipeline = ml.Transforms.Categorical.OneHotEncoding(nameof(PricingTrainingRow.CarType))
                .Append(ml.Transforms.Categorical.OneHotEncoding(nameof(PricingTrainingRow.Season)))
                .Append(ml.Transforms.Categorical.OneHotEncoding(nameof(PricingTrainingRow.Location)))
                .Append(ml.Transforms.Categorical.OneHotEncoding(nameof(PricingTrainingRow.Fuel)))
                .Append(ml.Transforms.Concatenate("Features", nameof(PricingTrainingRow.CarType), nameof(PricingTrainingRow.Season), nameof(PricingTrainingRow.Location), nameof(PricingTrainingRow.Km), nameof(PricingTrainingRow.HistoricalDemandIndex), nameof(PricingTrainingRow.Fuel)))
                .Append(ml.Regression.Trainers.Sdca(labelColumnName: nameof(PricingTrainingRow.Label), maximumNumberOfIterations: 100));

            var model = pipeline.Fit(trainData);
            var engine = ml.Model.CreatePredictionEngine<PricingTrainingRow, PricingPrediction>(model);
            var prediction = engine.Predict(new PricingTrainingRow
            {
                CarType = NormalizeCarType(request.CarType),
                Season = NormalizeSeason(request.Season),
                Location = NormalizeLocation(request.Location),
                Km = request.Km,
                Fuel = NormalizeFuel(request.Fuel),
                HistoricalDemandIndex = Math.Clamp(request.HistoricalDemandIndex, 0, 100)
            });

            var suggestedPrice = Math.Round(Math.Max(650m, (decimal)prediction.Score), 2);
            var result = new SmartPricingResult
            {
                SuggestedDailyPrice = suggestedPrice,
                Summary = $"ML.NET regresyon modeli; araç tipi, sezon, lokasyon, km, yakıt ve talep indeksine göre günlük fiyatı hesapladı.",
                PriceFactors =
     [
         $"Araç tipi: {request.CarType}",
        $"Sezon: {request.Season}",
        $"Lokasyon: {request.Location}",
        $"Talep indeksi: {request.HistoricalDemandIndex}/100"
     ]
            };

            return result;
        }

        private static List<PricingTrainingRow> BuildTrainingRows(List<Domain.Entities.CarPricing> carPricings)
        {
            var rows = new List<PricingTrainingRow>();
            var dailyPricings = carPricings.Where(x => x.PricingId == 2).ToList();
            var seasons = new[] { ("low", 0.90m), ("normal", 1.00m), ("high", 1.18m) };
            var locations = new[] { ("istanbul", 1.12m), ("ankara", 1.00m), ("izmir", 1.06m), ("other", 0.97m) };

            foreach (var item in dailyPricings)
            {
                var car = item.Car;
                if (car is null) continue;

                var carType = NormalizeCarType($"{car.Brand?.Name} {car.Model}");
                var fuel = NormalizeFuel(car.Fuel);
                var baseKm = car.Km;

                foreach (var (season, seasonFactor) in seasons)
                    foreach (var (location, locationFactor) in locations)
                    {
                        var demand = season == "high" ? 80f : season == "low" ? 35f : 55f;
                        var noise = (baseKm % 30000) / 30000m;
                        rows.Add(new PricingTrainingRow
                        {
                            CarType = carType,
                            Season = season,
                            Location = location,
                            Fuel = fuel,
                            Km = baseKm,
                            HistoricalDemandIndex = demand,
                            Label = (float)(item.Amount * seasonFactor * locationFactor * (1m - noise * 0.08m))
                        });
                    }
            }

            return rows;
        }

        private static string NormalizeSeason(string season)
            => string.IsNullOrWhiteSpace(season) ? "normal" : season.Trim().ToLowerInvariant();

        private static string NormalizeLocation(string location)
        {
            var normalized = string.IsNullOrWhiteSpace(location) ? "other" : location.Trim().ToLowerInvariant();
            return normalized is "istanbul" or "ankara" or "izmir" ? normalized : "other";
        }

        private static string NormalizeFuel(string fuel)
            => string.IsNullOrWhiteSpace(fuel) ? "unknown" : fuel.Trim().ToLowerInvariant();

        private static string NormalizeCarType(string carType)
            => string.IsNullOrWhiteSpace(carType) ? "general" : carType.Trim().ToLowerInvariant();

        private sealed class PricingTrainingRow
        {
            public string CarType { get; set; } = string.Empty;
            public string Season { get; set; } = string.Empty;
            public string Location { get; set; } = string.Empty;
            public float Km { get; set; }
            public string Fuel { get; set; } = string.Empty;
            public float HistoricalDemandIndex { get; set; }
            public float Label { get; set; }
        }

        private sealed class PricingPrediction
        {
            public float Score { get; set; }
        }
    }
}
