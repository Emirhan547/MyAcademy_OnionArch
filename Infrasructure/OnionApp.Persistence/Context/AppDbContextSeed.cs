using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Enums;

namespace OnionApp.Persistence.Context
{
    public static class AppDbContextSeed
    {
        public static async Task MigrateAsync(AppDbContext context, UserManager<AppUser> userManager)
        {
            // ─── Migrations ────────────────────────────────────────────────────────────
            await context.Database.MigrateAsync();

            // ─── Brands ────────────────────────────────────────────────────────────────
            if (!context.Brands.Any())
            {
                var brands = new List<Brand>
                {
                    new Brand { Name = "BMW" },
                    new Brand { Name = "Mercedes-Benz" },
                    new Brand { Name = "Audi" },
                    new Brand { Name = "Volkswagen" },
                    new Brand { Name = "Toyota" },
                    new Brand { Name = "Honda" },
                    new Brand { Name = "Ford" },
                    new Brand { Name = "Renault" },
                };
                await context.Brands.AddRangeAsync(brands);
                await context.SaveChangesAsync();
            }

            // ─── Features ──────────────────────────────────────────────────────────────
            if (!context.Features.Any())
            {
                var features = new List<Feature>
                {
                    new Feature { Name = "Klima" },
                    new Feature { Name = "Navigasyon" },
                    new Feature { Name = "Bluetooth" },
                    new Feature { Name = "Geri Görüş Kamerası" },
                    new Feature { Name = "Şerit Takip Sistemi" },
                    new Feature { Name = "Adaptif Hız Sabitleme" },
                    new Feature { Name = "Isıtmalı Koltuk" },
                    new Feature { Name = "Panoramik Tavan" },
                    new Feature { Name = "Deri Döşeme" },
                    new Feature { Name = "Otomatik Park" },
                };
                await context.Features.AddRangeAsync(features);
                await context.SaveChangesAsync();
            }

            // ─── Pricings ──────────────────────────────────────────────────────────────
            // ─── Pricings ──────────────────────────────────────────────────────────────
            if (!context.Pricings.Any())
            {
                var pricings = new List<Pricing>
    {
        new Pricing { Name = "Günlük" },
        new Pricing { Name = "Haftalık" },
        new Pricing { Name = "Aylık" },
    };

                await context.Pricings.AddRangeAsync(pricings);
                await context.SaveChangesAsync();
            }

            // ─── Locations ─────────────────────────────────────────────────────────────
            if (!context.Locations.Any())
            {
                var locations = new List<Location>
                {
                    new Location { Name = "İstanbul Havalimanı" },
                    new Location { Name = "Sabiha Gökçen Havalimanı" },
                    new Location { Name = "Ankara Esenboğa Havalimanı" },
                    new Location { Name = "İzmir Adnan Menderes Havalimanı" },
                    new Location { Name = "Kadıköy Şube" },
                    new Location { Name = "Beşiktaş Şube" },
                    new Location { Name = "Ataşehir Şube" },
                    new Location { Name = "Antalya Havalimanı" },
                };
                await context.Locations.AddRangeAsync(locations);
                await context.SaveChangesAsync();
            }

            // ─── Cars ──────────────────────────────────────────────────────────────────
            if (!context.Cars.Any())
            {
                var brands = context.Brands.ToList();
                int bmwId = brands.First(b => b.Name == "BMW").Id;
                int mercedesId = brands.First(b => b.Name == "Mercedes-Benz").Id;
                int audiId = brands.First(b => b.Name == "Audi").Id;
                int vwId = brands.First(b => b.Name == "Volkswagen").Id;
                int toyotaId = brands.First(b => b.Name == "Toyota").Id;
                int hondaId = brands.First(b => b.Name == "Honda").Id;
                int fordId = brands.First(b => b.Name == "Ford").Id;
                int renaultId = brands.First(b => b.Name == "Renault").Id;

                var cars = new List<Car>
                {
                    // BMW
                    new Car
                    {
                        BrandId = bmwId, Model = "3 Series", CoverImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=1200",
                        Km = 850, Transmission = "Otomatik", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    new Car
                    {
                        BrandId = bmwId, Model = "5 Series", CoverImageUrl = "https://images.unsplash.com/photo-1616422285623-13ff0162193c?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1616422285623-13ff0162193c?w=1200",
                        Km = 1200, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Dizel"
                    },
                    new Car
                    {
                        BrandId = bmwId, Model = "X5", CoverImageUrl = "https://images.unsplash.com/photo-1580274455191-1c62238fa333?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1580274455191-1c62238fa333?w=1200",
                        Km = 500, Transmission = "Otomatik", Seat = 7, Luggage = 4, Fuel = "Dizel"
                    },
                    // Mercedes
                    new Car
                    {
                        BrandId = mercedesId, Model = "C 200", CoverImageUrl = "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1618843479313-40f8afb4b4d8?w=1200",
                        Km = 720, Transmission = "Otomatik", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    new Car
                    {
                        BrandId = mercedesId, Model = "E 220d", CoverImageUrl = "https://images.unsplash.com/photo-1629897048514-3dd7414fe72a?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1629897048514-3dd7414fe72a?w=1200",
                        Km = 2100, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Dizel"
                    },
                    new Car
                    {
                        BrandId = mercedesId, Model = "GLE 300d", CoverImageUrl = "https://images.unsplash.com/photo-1614200187524-dc4b892acf16?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1614200187524-dc4b892acf16?w=1200",
                        Km = 300, Transmission = "Otomatik", Seat = 7, Luggage = 4, Fuel = "Dizel"
                    },
                    // Audi
                    new Car
                    {
                        BrandId = audiId, Model = "A4 2.0 TDI", CoverImageUrl = "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1606664515524-ed2f786a0bd6?w=1200",
                        Km = 980, Transmission = "Otomatik", Seat = 5, Luggage = 2, Fuel = "Dizel"
                    },
                    new Car
                    {
                        BrandId = audiId, Model = "Q5 45 TFSI", CoverImageUrl = "https://images.unsplash.com/photo-1617469767053-d3b523a0b982?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1617469767053-d3b523a0b982?w=1200",
                        Km = 400, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Benzin"
                    },
                    // Volkswagen
                    new Car
                    {
                        BrandId = vwId, Model = "Passat 2.0 TDI", CoverImageUrl = "https://images.unsplash.com/photo-1571063745897-34f4c15a7c40?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1571063745897-34f4c15a7c40?w=1200",
                        Km = 3200, Transmission = "Otomatik", Seat = 5, Luggage = 2, Fuel = "Dizel"
                    },
                    new Car
                    {
                        BrandId = vwId, Model = "Golf 1.5 TSI", CoverImageUrl = "https://images.unsplash.com/photo-1541899481282-d53bffe3c35d?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1541899481282-d53bffe3c35d?w=1200",
                        Km = 1800, Transmission = "Manuel", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    // Toyota
                    new Car
                    {
                        BrandId = toyotaId, Model = "Corolla Hybrid", CoverImageUrl = "https://images.unsplash.com/photo-1621007947382-bb3c3994e3fb?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1621007947382-bb3c3994e3fb?w=1200",
                        Km = 600, Transmission = "Otomatik", Seat = 5, Luggage = 2, Fuel = "Hibrit"
                    },
                    new Car
                    {
                        BrandId = toyotaId, Model = "RAV4 Hybrid", CoverImageUrl = "https://images.unsplash.com/photo-1568605117036-5fe5e7bab0b7?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1568605117036-5fe5e7bab0b7?w=1200",
                        Km = 250, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Hibrit"
                    },
                    // Honda
                    new Car
                    {
                        BrandId = hondaId, Model = "Civic 1.5 VTEC", CoverImageUrl = "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1590362891991-f776e747a588?w=1200",
                        Km = 4200, Transmission = "Manuel", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    // Ford
                    new Car
                    {
                        BrandId = fordId, Model = "Focus 1.5 EcoBoost", CoverImageUrl = "https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1492144534655-ae79c964c9d7?w=1200",
                        Km = 2800, Transmission = "Manuel", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    new Car
                    {
                        BrandId = fordId, Model = "Kuga ST-Line", CoverImageUrl = "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1519641471654-76ce0107ad1b?w=1200",
                        Km = 900, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Dizel"
                    },
                    // Renault
                    new Car
                    {
                        BrandId = renaultId, Model = "Megane 1.3 TCe", CoverImageUrl = "https://images.unsplash.com/photo-1485291571150-772bcfc10da5?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1485291571150-772bcfc10da5?w=1200",
                        Km = 5100, Transmission = "Manuel", Seat = 5, Luggage = 2, Fuel = "Benzin"
                    },
                    // Elektrikli
                    new Car
                    {
                        BrandId = bmwId, Model = "iX3", CoverImageUrl = "https://images.unsplash.com/photo-1593941707874-ef25b8b4a92b?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1593941707874-ef25b8b4a92b?w=1200",
                        Km = 100, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Elektrik"
                    },
                    new Car
                    {
                        BrandId = audiId, Model = "e-tron 55", CoverImageUrl = "https://images.unsplash.com/photo-1542362567-b07e54358753?w=600",
                        BigImageUrl = "https://images.unsplash.com/photo-1542362567-b07e54358753?w=1200",
                        Km = 150, Transmission = "Otomatik", Seat = 5, Luggage = 3, Fuel = "Elektrik"
                    },
                };
                await context.Cars.AddRangeAsync(cars);
                await context.SaveChangesAsync();
            }

            // ─── CarDescriptions ───────────────────────────────────────────────────────
            if (!context.CarDescriptions.Any())
            {
                var cars = context.Cars.ToList();
                var descriptions = cars.Select(c => new CarDescription
                {
                    CarId = c.Id,
                    Details = c.Model switch
                    {
                        "3 Series" => "BMW 3 Serisi, spor sürüş dinamikleri ve premium iç mekanıyla segmentinin referans otomobilidir. Güçlü motor seçenekleri ve gelişmiş sürücü destek sistemleriyle donatılmıştır.",
                        "5 Series" => "BMW 5 Serisi, iş dünyasının vazgeçilmez executive sedanıdır. Geniş iç hacmi, konforlu süspansiyon ayarı ve üst düzey donanımıyla uzun yolculukları keyfe dönüştürür.",
                        "X5" => "BMW X5, tam anlamıyla bir lüks SUV deneyimi sunar. Yedi koltuk kapasitesi, yüksek zemin klirensı ve güçlü dizel motoruyla hem şehir içi hem de uzun yol için idealdir.",
                        "C 200" => "Mercedes-Benz C 200, yıllardır C-Segmentin sembolü olmayı sürdürmektedir. Şık tasarımı, kaliteli malzemeleri ve gelişmiş güvenlik sistemleriyle konfor ve güvenliği bir arada sunar.",
                        "E 220d" => "Mercedes-Benz E 220d, premium executive sedan kategorisinin lideridir. Yakıt tasarruflu dizel motoru ve geniş kabin alanıyla aile ve iş seyahatlerinde eşsiz konfor sağlar.",
                        "GLE 300d" => "Mercedes-Benz GLE 300d, üst segment SUV sınıfının güçlü temsilcisidir. Yedi koltuk kapasitesi, yüksek tork değeri ve MBUX infotainment sistemi ile fark yaratır.",
                        "A4 2.0 TDI" => "Audi A4, Alman mühendisliğinin ikonik bir eseridir. Quattro dört çeker sistemi, sakin kabin ortamı ve dijital gösterge paneli (Virtual Cockpit) ile sürücüye üstün bir deneyim sunar.",
                        "Q5 45 TFSI" => "Audi Q5, premium orta segment SUV pazarının gözdesidir. TFSI motoru, elektrikli bagaj kapağı ve Audi'nin MMI dokunmatik sistemi ile pratikliği lükse taşır.",
                        "Passat 2.0 TDI" => "Volkswagen Passat, Avrupa'nın en çok tercih edilen executive sedanlarından biridir. Uzun menzilli dizel motoru, geniş bagajı ve sürüş güvenlik sistemleriyle uzun yolculuklar için biçilmiş kaftandır.",
                        "Golf 1.5 TSI" => "Volkswagen Golf, otomobil tarihinin en başarılı kompakt araçlarından biridir. TSI motoru, çevre dostu yakıt tüketimi ve VW'nin güvenilir kalite mirasıyla her günkü kullanım için mükemmeldir.",
                        "Corolla Hybrid" => "Toyota Corolla Hybrid, dünyanın en güvenilir otomobiline hibrit teknoloji eklenmiş halidir. Düşük yakıt tüketimi ve sıfıra yakın bakım maliyetiyle ekonomik sürüş arayanların ilk tercihi.",
                        "RAV4 Hybrid" => "Toyota RAV4 Hybrid, kompakt SUV segmentinde hibrit teknolojinin öncüsüdür. AWD-i sistemi sayesinde zor yol koşullarında bile güven veren bu araç, düşük emisyon ve güçlü performansı bir arada sunuyor.",
                        "Civic 1.5 VTEC" => "Honda Civic, genç ve dinamik sürücüler için tasarlanmış kompakt bir spor sedandır. VTEC teknolojisiyle donatılmış motoru, keskin direksiyon geri bildirimi ve sportif tasarımıyla dikkat çeker.",
                        "Focus 1.5 EcoBoost" => "Ford Focus, Avrupa'nın satış listelerine on yıllar boyunca hakim olan kompakt hatchback'idir. EcoBoost motoru güçlü performans sunarken yakıt tüketimini minimize eder.",
                        "Kuga ST-Line" => "Ford Kuga ST-Line, sporcu estetiğini SUV pratiğiyle buluşturur. Akıllı dört çeker sistemi, geniş bagajı ve SYNC 3 infotainment ekranıyla hem şehirli hem de maceraperest sürücülere hitap eder.",
                        "Megane 1.3 TCe" => "Renault Megane, Fransız tasarım anlayışını modern teknoloji ile harmanlayan kompakt bir sedandır. Geniş iç hacmi, ergonomik koltukları ve kablosuz şarj özelliğiyle günlük kullanımda konfor sağlar.",
                        "iX3" => "BMW iX3, elektrikli araç dünyasına BMW kalitesini taşır. 286 beygir güç ve 460 km menzil sunarak günlük kullanımdan uzun yol seyahatine kadar her ihtiyacı karşılar. Isı pompası ve DC hızlı şarj desteği standarttır.",
                        "e-tron 55" => "Audi e-tron 55, premium elektrikli SUV segmentinin öncü modelidir. Quattro elektrik 4×4, 300 kW güç ve 400 km'yi aşan menziliyle performans ve yolculuk konforu bir arada.",
                        _ => $"{c.Model}, yüksek standartlarda bakıma alınmış, temiz ve konforlu bir araçtır."
                    }
                }).ToList();
                await context.CarDescriptions.AddRangeAsync(descriptions);
                await context.SaveChangesAsync();
            }

            // ─── CarPricings ───────────────────────────────────────────────────────────
            if (!context.CarPricings.Any())
            {
                var cars = context.Cars.ToList();
                var pricings = context.Pricings.ToList();
                int dailyId = pricings.First(p => p.Name == "Günlük").Id;
                int weeklyId = pricings.First(p => p.Name == "Haftalık").Id;
                int monthId = pricings.First(p => p.Name == "Aylık").Id;

                // daily : weekly : monthly ≈ 1 : 5.5 : 18
                var priceMap = new Dictionary<string, (decimal daily, decimal weekly, decimal monthly)>
                {
                    ["3 Series"] = (950, 5500, 17000),
                    ["5 Series"] = (1250, 7200, 22000),
                    ["X5"] = (1800, 10500, 32000),
                    ["C 200"] = (1000, 5800, 18000),
                    ["E 220d"] = (1350, 7800, 24000),
                    ["GLE 300d"] = (1950, 11000, 34000),
                    ["A4 2.0 TDI"] = (1100, 6200, 19000),
                    ["Q5 45 TFSI"] = (1600, 9200, 28000),
                    ["Passat 2.0 TDI"] = (850, 4900, 15000),
                    ["Golf 1.5 TSI"] = (700, 4000, 12500),
                    ["Corolla Hybrid"] = (750, 4300, 13500),
                    ["RAV4 Hybrid"] = (1400, 8000, 25000),
                    ["Civic 1.5 VTEC"] = (680, 3900, 12000),
                    ["Focus 1.5 EcoBoost"] = (650, 3700, 11500),
                    ["Kuga ST-Line"] = (1100, 6300, 19500),
                    ["Megane 1.3 TCe"] = (600, 3400, 10500),
                    ["iX3"] = (2200, 13000, 40000),
                    ["e-tron 55"] = (2500, 14500, 45000),
                };

                var carPricings = new List<CarPricing>();
                foreach (var car in cars)
                {
                    if (!priceMap.TryGetValue(car.Model, out var p)) continue;
                    carPricings.Add(new CarPricing { CarId = car.Id, PricingId = dailyId, Amount = p.daily });
                    carPricings.Add(new CarPricing { CarId = car.Id, PricingId = weeklyId, Amount = p.weekly });
                    carPricings.Add(new CarPricing { CarId = car.Id, PricingId = monthId, Amount = p.monthly });
                }
                await context.CarPricings.AddRangeAsync(carPricings);
                await context.SaveChangesAsync();
            }

            // ─── CarFeatures ───────────────────────────────────────────────────────────
            if (!context.CarFeatures.Any())
            {
                var cars = context.Cars.ToList();
                var features = context.Features.ToList();
                var rand = new Random(42);
                var carFeatures = new List<CarFeature>();

                foreach (var car in cars)
                {
                    // Klima, Bluetooth — her araca var
                    foreach (var feat in features)
                    {
                        bool available = feat.Name switch
                        {
                            "Klima" => true,
                            "Bluetooth" => true,
                            "Geri Görüş Kamerası" => car.Fuel != "Benzin" || car.Model.Contains("X5") || car.Model.Contains("Q5") || car.Model.Contains("GLE"),
                            "Navigasyon" => rand.NextDouble() > 0.3,
                            "Şerit Takip Sistemi" => rand.NextDouble() > 0.4,
                            "Adaptif Hız Sabitleme" => rand.NextDouble() > 0.5,
                            "Isıtmalı Koltuk" => car.Fuel is "Elektrik" or "Hibrit" || rand.NextDouble() > 0.5,
                            "Panoramik Tavan" => car.Model.Contains("X5") || car.Model.Contains("GLE") || car.Model.Contains("Q5") || car.Model.Contains("RAV4") || rand.NextDouble() > 0.7,
                            "Deri Döşeme" => car.Model.Contains("5 Series") || car.Model.Contains("E 220") || car.Model.Contains("GLE") || car.Model.Contains("iX3") || car.Model.Contains("e-tron") || rand.NextDouble() > 0.6,
                            "Otomatik Park" => car.Fuel is "Elektrik" || rand.NextDouble() > 0.75,
                            _ => rand.NextDouble() > 0.5
                        };
                        carFeatures.Add(new CarFeature
                        {
                            CarId = car.Id,
                            FeatureId = feat.Id,
                            Available = available
                        });
                    }
                }
                await context.CarFeatures.AddRangeAsync(carFeatures);
                await context.SaveChangesAsync();
            }

            // ─── RentACars ─────────────────────────────────────────────────────────────
            if (!context.RentACars.Any())
            {
                var cars = context.Cars.ToList();
                var locations = context.Locations.ToList();
                var rentACars = new List<RentACar>();

                // Her araç en az 2 konumda mevcut
                foreach (var car in cars)
                {
                    var pickedLocations = locations.OrderBy(_ => Guid.NewGuid()).Take(2).ToList();
                    foreach (var loc in pickedLocations)
                    {
                        rentACars.Add(new RentACar
                        {
                            CarId = car.Id,
                            LocationId = loc.Id,
                            Available = true
                        });
                    }
                }
                await context.RentACars.AddRangeAsync(rentACars);
                await context.SaveChangesAsync();
            }

            // ─── Reviews ───────────────────────────────────────────────────────────────
            if (!context.Reviews.Any())
            {
                var cars = context.Cars.ToList();
                var reviews = new List<Review>();

                var reviewData = new[]
                {
                    ("Ahmet Yılmaz",   "https://i.pravatar.cc/150?img=1",  "Harika bir araç! Hem konforlu hem de yakıt tasarruflu. Kesinlikle tavsiye ederim.", "5"),
                    ("Fatma Kaya",     "https://i.pravatar.cc/150?img=2",  "Motor performansı beklentilerimin üzerindeydi, iç mekan kalitesi de çok iyiydi.", "5"),
                    ("Mehmet Demir",   "https://i.pravatar.cc/150?img=3",  "Navigasyon sistemi biraz karmaşık ama genel olarak tatmin edici bir deneyim.", "4"),
                    ("Ayşe Çelik",     "https://i.pravatar.cc/150?img=4",  "Ailecek hafta sonu gezimizde kullandık, yeterince geniş ve konforlu buldum.", "4"),
                    ("Can Öztürk",     "https://i.pravatar.cc/150?img=5",  "Direksiyon yönetimi çok hassas, uzun yolda yorgunluk hissetmedim.", "5"),
                    ("Selin Arslan",   "https://i.pravatar.cc/150?img=6",  "Araç temiz ve bakımlıydı fakat park sensörü biraz geç tepki verdi.", "3"),
                    ("Emre Koç",       "https://i.pravatar.cc/150?img=7",  "Elektrikli araç deneyimim oldu ilk kez, çok memnun kaldım, sessiz ve güçlü.", "5"),
                    ("Zeynep Yıldız",  "https://i.pravatar.cc/150?img=8",  "Yakıt tüketimi konusunda gerçekten tasarruflu, uzun yolda 5,2 lt/100km yaptık.", "5"),
                    ("Burak Şahin",    "https://i.pravatar.cc/150?img=9",  "Koltuklar biraz sert ama diğer özelliklerde hiç sorun yaşamadım.", "4"),
                    ("Merve Aydın",    "https://i.pravatar.cc/150?img=10", "Sesiz sürüş ve üst düzey iç mekan, patronumu havalimanında karşılamak için mükemmeldi.", "5"),
                };

                var startDate = new DateTime(2025, 1, 1);
                int reviewIdx = 0;
                foreach (var car in cars)
                {
                    int count = new Random(car.Id).Next(2, 5);
                    for (int i = 0; i < count; i++)
                    {
                        var rd = reviewData[reviewIdx % reviewData.Length];
                        reviews.Add(new Review
                        {
                            CarId = car.Id,
                            CustomerName = rd.Item1,
                            CustomerImage = rd.Item2,
                            Comment = rd.Item3,
                            RaytingValue = rd.Item4,
                            ReviewDate = startDate.AddDays(reviewIdx * 9)
                        });
                        reviewIdx++;
                    }
                }
                await context.Reviews.AddRangeAsync(reviews);
                await context.SaveChangesAsync();
            }

            // ─── Categories ────────────────────────────────────────────────────────────
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Araç İncelemeleri" },
                    new Category { Name = "Seyahat Rehberleri" },
                    new Category { Name = "Bakım & Tavsiyeler" },
                    new Category { Name = "Elektrikli Araçlar" },
                    new Category { Name = "Kampanyalar" },
                    new Category { Name = "Sektör Haberleri" },
                };
                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }

            // ─── Authors ───────────────────────────────────────────────────────────────
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author
                    {
                        Name = "Barış Erdoğan",
                        ImageUrl = "https://i.pravatar.cc/150?img=11",
                        Description = "Otomotiv dünyasında 12 yıllık deneyime sahip editör ve araç test uzmanı."
                    },
                    new Author
                    {
                        Name = "Leyla Çınar",
                        ImageUrl = "https://i.pravatar.cc/150?img=12",
                        Description = "Seyahat yazarı ve kira araç kullanıcısı deneyim uzmanı. Avrupa'nın dört bir yanını kiralık araçla gezmiştir."
                    },
                    new Author
                    {
                        Name = "Serkan Bulut",
                        ImageUrl = "https://i.pravatar.cc/150?img=13",
                        Description = "Otomotiv mühendisi ve teknik içerik üreticisi. Hibrit ve elektrikli araç teknolojileri konusunda uzman."
                    },
                    new Author
                    {
                        Name = "Deniz Kavak",
                        ImageUrl = "https://i.pravatar.cc/150?img=14",
                        Description = "Dijital pazarlama uzmanı ve araç kiralama sektörü analistı. Tüketici deneyimi üzerine yazılar kaleme almaktadır."
                    },
                };
                await context.Authors.AddRangeAsync(authors);
                await context.SaveChangesAsync();
            }

            // ─── Blogs ─────────────────────────────────────────────────────────────────
            if (!context.Blogs.Any())
            {
                var authors = context.Authors.ToList();
                var categories = context.Categories.ToList();

                int catInceleme = categories.First(c => c.Name == "Araç İncelemeleri").Id;
                int catSeyahat = categories.First(c => c.Name == "Seyahat Rehberleri").Id;
                int catBakim = categories.First(c => c.Name == "Bakım & Tavsiyeler").Id;
                int catElektrik = categories.First(c => c.Name == "Elektrikli Araçlar").Id;
                int catKampanya = categories.First(c => c.Name == "Kampanyalar").Id;
                int catHaber = categories.First(c => c.Name == "Sektör Haberleri").Id;

                int a1 = authors[0].Id, a2 = authors[1].Id, a3 = authors[2].Id, a4 = authors[3].Id;

                var blogs = new List<Blog>
                {
                    new Blog
                    {
                        Title = "BMW 3 Serisi Test: Spor Sürüşün Referansı",
                        Description = "BMW'nin ikonik 3 Serisi, spor sedan segmentinde neden hâlâ rakipsiz? Motor performansı, direksiyon hassasiyeti ve iç mekan kalitesiyle detaylı test sonuçlarımızı paylaşıyoruz.",
                        AuthorId = a1, CategoryId = catInceleme,
                        CoverImageUrl = "https://images.unsplash.com/photo-1555215695-3004980ad54e?w=800",
                        CreatedDate = new DateTime(2025, 2, 10)
                    },
                    new Blog
                    {
                        Title = "Kapadokya'yı Kiralık Araçla Keşfetmek",
                        Description = "Kapadokya'nın eşsiz coğrafyasında kiralık araçla özgürce dolaşmak mümkün mü? En iyi güzergahları, park ipuçlarını ve araç seçim tavsiyelerini bu rehberde bulacaksınız.",
                        AuthorId = a2, CategoryId = catSeyahat,
                        CoverImageUrl = "https://images.unsplash.com/photo-1605130284535-11dd9eedc58a?w=800",
                        CreatedDate = new DateTime(2025, 2, 18)
                    },
                    new Blog
                    {
                        Title = "Kiralık Araçlarda Yakıt Tasarrufu Sırları",
                        Description = "Uzun yolculuklarda yakıt masraflarını nasıl minimize edersiniz? Hibrit araç seçiminden sürüş teknikleri ve araç bakımına kadar bilmeniz gereken her şey.",
                        AuthorId = a3, CategoryId = catBakim,
                        CoverImageUrl = "https://images.unsplash.com/photo-1615906655593-ad0386982a0f?w=800",
                        CreatedDate = new DateTime(2025, 3, 5)
                    },
                    new Blog
                    {
                        Title = "Elektrikli Araç Kiralama Rehberi 2025",
                        Description = "BMW iX3 veya Audi e-tron kiralayacaksanız bilmeniz gerekenler: şarj ağı, menzil planlaması, şarj süresi ve elektrikli araç sürüş ipuçları bu yazıda.",
                        AuthorId = a3, CategoryId = catElektrik,
                        CoverImageUrl = "https://images.unsplash.com/photo-1593941707874-ef25b8b4a92b?w=800",
                        CreatedDate = new DateTime(2025, 3, 20)
                    },
                    new Blog
                    {
                        Title = "Yaz Sezonu Erken Rezervasyon Avantajları",
                        Description = "Yaz aylarında araç bulma sıkıntısı yaşamamak için erken rezervasyonun ne kadar önemli olduğunu ve nasıl avantaj elde edebileceğinizi anlatıyoruz.",
                        AuthorId = a4, CategoryId = catKampanya,
                        CoverImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800",
                        CreatedDate = new DateTime(2025, 4, 1)
                    },
                    new Blog
                    {
                        Title = "Araç Kiralama Sektörü 2025 Raporu",
                        Description = "Pandemi sonrası normalleşmenin ardından araç kiralama sektörü rekor büyüme yaşıyor. Dijital dönüşüm, sürdürülebilirlik trendleri ve müşteri beklentilerindeki değişim.",
                        AuthorId = a4, CategoryId = catHaber,
                        CoverImageUrl = "https://images.unsplash.com/photo-1551836022-deb4988cc6c0?w=800",
                        CreatedDate = new DateTime(2025, 4, 15)
                    },
                    new Blog
                    {
                        Title = "Mercedes C Serisi ile İstanbul'u Keşfetmek",
                        Description = "İstanbul'un iki yakasını, tarihi yarımadasını ve Boğaz güzergahını bir Mercedes C 200 ile keşfetmek nasıl bir deneyimdir? Yol hikayemizi okuyun.",
                        AuthorId = a2, CategoryId = catSeyahat,
                        CoverImageUrl = "https://images.unsplash.com/photo-1444086460274-68c3c5ba7a0a?w=800",
                        CreatedDate = new DateTime(2025, 5, 3)
                    },
                    new Blog
                    {
                        Title = "SUV mı Sedan mı? Doğru Araç Seçimi",
                        Description = "Kiralık araç seçerken SUV ile sedan arasında kararsız mı kaldınız? Yol koşulları, bagaj ihtiyacı, yakıt tüketimi ve konfor açısından kapsamlı karşılaştırma.",
                        AuthorId = a1, CategoryId = catInceleme,
                        CoverImageUrl = "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=800",
                        CreatedDate = new DateTime(2025, 5, 20)
                    },
                    new Blog
                    {
                        Title = "Araç Kiralama Sigortası Hakkında Bilinmeyenler",
                        Description = "Hasar muafiyeti, cam/lastik güvencesi, şahıs sigortası... Kiralık araç sigortasının tüm detaylarını ve hangi güvencelere gerçekten ihtiyaç duyduğunuzu öğrenin.",
                        AuthorId = a4, CategoryId = catBakim,
                        CoverImageUrl = "https://images.unsplash.com/photo-1556742049-0cfed4f6a45d?w=800",
                        CreatedDate = new DateTime(2025, 6, 8)
                    },
                    new Blog
                    {
                        Title = "Avrupa'da Araçla Tatil: Schengen Kuralları",
                        Description = "Kiralık araçla Avrupa'ya açılmak isteyenler için sınır geçiş belgeleri, vize gereklilikleri, yeşil kart kapsamı ve dikkat edilmesi gereken trafik kuralları.",
                        AuthorId = a2, CategoryId = catSeyahat,
                        CoverImageUrl = "https://images.unsplash.com/photo-1534528741775-53994a69daeb?w=800",
                        CreatedDate = new DateTime(2025, 6, 25)
                    },
                };
                await context.Blogs.AddRangeAsync(blogs);
                await context.SaveChangesAsync();
            }

            // ─── TagClouds ─────────────────────────────────────────────────────────────
            if (!context.TagClouds.Any())
            {
                var blogs = context.Blogs.ToList();
                var tagSets = new string[][]
                {
                    new[]{"BMW","Test","Spor Sürüş","Sedan","Performans"},
                    new[]{"Kapadokya","Seyahat","Yol Gezisi","Rehber","Gezi"},
                    new[]{"Yakıt","Tasarruf","Hibrit","Ekonomi","Çevre"},
                    new[]{"Elektrikli Araç","Şarj","Menzil","EV","Sürdürülebilirlik"},
                    new[]{"Kampanya","İndirim","Rezervasyon","Yaz","Fırsat"},
                    new[]{"Sektör","Rapor","Büyüme","Dijital","Trend"},
                    new[]{"Mercedes","İstanbul","Şehir","Boğaz","Lüks"},
                    new[]{"SUV","Sedan","Karşılaştırma","Araç Seçimi","Tavsiye"},
                    new[]{"Sigorta","Güvence","Hasar","Kiralama","İpucu"},
                    new[]{"Avrupa","Schengen","Yurt Dışı","Tatil","Belge"},
                };

                var tagClouds = new List<TagCloud>();
                for (int i = 0; i < blogs.Count; i++)
                {
                    var tags = i < tagSets.Length ? tagSets[i] : tagSets[0];
                    tagClouds.AddRange(tags.Select(t => new TagCloud { BlogId = blogs[i].Id, Title = t }));
                }
                await context.TagClouds.AddRangeAsync(tagClouds);
                await context.SaveChangesAsync();
            }

            // ─── Comments ──────────────────────────────────────────────────────────────
            if (!context.Comments.Any())
            {
                var blogs = context.Blogs.ToList();
                var comments = new List<Comment>();

                var commentPool = new (string name, string email, string text)[]
                {
                    ("Ali Vural",       "ali.vural@mail.com",      "Çok faydalı bir yazı, teşekkürler!"),
                    ("Elif Kaplan",     "elif.kaplan@mail.com",    "Tam aradığım bilgiler vardı, ellerinize sağlık."),
                    ("Hasan Demir",     "hasan.demir@mail.com",    "Bu konuda daha detaylı yazı yazmanızı bekliyoruz."),
                    ("Nuray Acar",      "nuray.acar@mail.com",     "Deneyimlerim de yazıdaki ile örtüşüyor, kesinlikle katılıyorum."),
                    ("Tarık Özkan",     "tarik.ozkan@mail.com",    "Sigorta konusu gerçekten çok önemli, vurgulamanız güzel olmuş."),
                    ("Sibel Yaman",     "sibel.yaman@mail.com",    "BMW'yi tercih ettim ve hiç pişman olmadım!"),
                    ("Koray Arslan",    "koray.arslan@mail.com",   "Bir sonraki yazıyı sabırsızlıkla bekliyorum."),
                    ("Gizem Öz",        "gizem.oz@mail.com",       "Kapadokya gezimde bu yazıdan çok yararlandım."),
                    ("Tolga Çevik",     "tolga.cevik@mail.com",    "Elektrikli araçlar hakkında merak ettiğim her şeyi öğrendim."),
                    ("Pınar Güneş",     "pinar.gunes@mail.com",    "Avrupa seyahatimde büyük kolaylık sağladı, paylaşım için sağ olun."),
                    ("Uğur Bulut",      "ugur.bulut@mail.com",     "Çok açıklayıcı ve anlaşılır kaleme alınmış."),
                    ("Aysun Toprak",    "aysun.toprak@mail.com",   "Fiyatlar konusunu da eklerseniz süper olur."),
                };

                var rand = new Random(2025);
                var date = new DateTime(2025, 1, 1);
                int cmtIdx = 0;

                foreach (var blog in blogs)
                {
                    int count = rand.Next(3, 8);
                    for (int i = 0; i < count; i++)
                    {
                        var cp = commentPool[cmtIdx % commentPool.Length];
                        comments.Add(new Comment
                        {
                            BlogId = blog.Id,
                            Name = cp.name,
                            Email = cp.email,
                            Description = cp.text,
                            CreatedDate = date.AddDays(cmtIdx * 3)
                        });
                        cmtIdx++;
                    }
                }
                await context.Comments.AddRangeAsync(comments);
                await context.SaveChangesAsync();
            }

            // ─── Services ──────────────────────────────────────────────────────────────
            if (!context.Services.Any())
            {
                var services = new List<Service>
                {
                    new Service { Title = "7/24 Müşteri Desteği",     Description = "Günün her saati müşteri hizmetlerimize ulaşabilir, her türlü sorunuza anında yanıt alabilirsiniz.",            IconUrl = "flaticon-support" },
                    new Service { Title = "Ücretsiz Araç Teslimatı",  Description = "Belirlediğiniz adrese ücretsiz araç teslim ediyoruz. Havalimanı, otel veya ev fark etmez.",                     IconUrl = "flaticon-delivery" },
                    new Service { Title = "Esnek İptal Seçenekleri",  Description = "Rezervasyon tarihinden 24 saat öncesine kadar ücretsiz iptal hakkından yararlanabilirsiniz.",                    IconUrl = "flaticon-calendar" },
                    new Service { Title = "Kapsamlı Kasko Güvencesi", Description = "Tüm araçlarımız tam kasko sigortalıdır. Ekstra güvence için kendi seçeneklerimizi de inceleyebilirsiniz.",       IconUrl = "flaticon-shield" },
                    new Service { Title = "Geniş Araç Filosu",        Description = "Ekonomik kompaktlardan lüks SUV'lara, hibrit ve elektrikli araçlara kadar 100'den fazla model seçeneği sunuyoruz.", IconUrl = "flaticon-car" },
                    new Service { Title = "Hızlı Çevrimiçi Kiralama", Description = "Mobil uygulama veya web sitemiz üzerinden dakikalar içinde rezervasyon yapın, onayınız anında gelsin.",           IconUrl = "flaticon-click" },
                };
                await context.Services.AddRangeAsync(services);
                await context.SaveChangesAsync();
            }

            // ─── Abouts ────────────────────────────────────────────────────────────────
            if (!context.Abouts.Any())
            {
                var abouts = new List<About>
                {
                    new About
                    {
                        Title       = "Türkiye'nin Güvenilir Araç Kiralama Platformu",
                        Description = "2015 yılında kurulan şirketimiz, bugün 8 şehirde 100'den fazla araçlık filosuyla hizmet vermektedir. Müşteri memnuniyetini her zaman ön planda tutan yaklaşımımız, bizi sektörde güvenilir bir marka haline getirmiştir.",
                        ImageUrl    = "https://images.unsplash.com/photo-1551836022-deb4988cc6c0?w=800"
                    },
                    new About
                    {
                        Title       = "Misyonumuz",
                        Description = "Her müşterimizin ihtiyacına özel, konforlu ve güvenli bir araç deneyimi sunmak. Şeffaf fiyatlandırma, temiz araçlar ve hızlı hizmet anlayışıyla araç kiralamayı zahmetsiz bir deneyime dönüştürmek.",
                        ImageUrl    = "https://images.unsplash.com/photo-1449965408869-eaa3f722e40d?w=800"
                    },
                    new About
                    {
                        Title       = "Sürdürülebilir Mobilite",
                        Description = "Elektrikli ve hibrit araç seçeneklerimizi genişleterek karbon ayak izimizi azaltmayı hedefliyoruz. 2030'a kadar filomuzun %40'ını sıfır emisyonlu araçlarla doldurmayı planlıyoruz.",
                        ImageUrl    = "https://images.unsplash.com/photo-1593941707874-ef25b8b4a92b?w=800"
                    },
                };
                await context.Abouts.AddRangeAsync(abouts);
                await context.SaveChangesAsync();
            }

            // ─── Banners ───────────────────────────────────────────────────────────────
            if (!context.Banners.Any())
            {
                var banners = new List<Banner>
                {
                    new Banner
                    {
                        Title            = "Özgürce Keşfet, Konforla Ulaş",
                        Description      = "Türkiye'nin dört bir yanında premium araçlarla seyahat edin. Yüzlerce model, rekabetçi fiyatlar ve 7/24 destek.",
                        VideoDescription = "Araç kiralama artık çok daha kolay",
                        VideoUrl         = "https://www.youtube.com/embed/dQw4w9WgXcQ"
                    },
                    new Banner
                    {
                        Title            = "Yaz Kampanyası: %20 İndirim",
                        Description      = "Temmuz ve Ağustos rezervasyonlarınızda tüm araç sınıflarında %20 indirim fırsatını kaçırmayın.",
                        VideoDescription = "Yaz tatilini unutulmaz kıl",
                        VideoUrl         = "https://www.youtube.com/embed/dQw4w9WgXcQ"
                    },
                    new Banner
                    {
                        Title            = "Elektrikli Araç Deneyimi",
                        Description      = "BMW iX3 ve Audi e-tron ile geleceğin sürüş deneyimini bugün yaşayın. Sessiz, güçlü ve çevre dostu.",
                        VideoDescription = "Elektrikli araçlar hakkında her şey",
                        VideoUrl         = "https://www.youtube.com/embed/dQw4w9WgXcQ"
                    },
                };
                await context.Banners.AddRangeAsync(banners);
                await context.SaveChangesAsync();
            }

            // ─── Testimonials ──────────────────────────────────────────────────────────
            if (!context.Testimonials.Any())
            {
                var testimonials = new List<Testimonial>
                {
                    new Testimonial { Name = "Murat Şimşek",   Title = "İş İnsanı",        Comment = "Havalimanı transferlerimde her zaman bu firmayı tercih ediyorum. Araçları temiz, personeli güler yüzlü. Kesinlikle tavsiye ederim.", ImageUrl = "https://i.pravatar.cc/150?img=20" },
                    new Testimonial { Name = "Ceren Yıldırım", Title = "Seyahat Bloggeri",  Comment = "Türkiye turumda kiralık araç hizmetini bu şirketten aldım. Teslim süper hızlı, araç harika, fiyat da gayet makul.", ImageUrl = "https://i.pravatar.cc/150?img=21" },
                    new Testimonial { Name = "Ufuk Tekin",     Title = "Mühendis",          Comment = "İlk kez elektrikli araç kiralayarak BMW iX3 deneyimi yaşadım. Şarj noktaları hakkında verilen bilgiler çok yardımcı oldu.", ImageUrl = "https://i.pravatar.cc/150?img=22" },
                    new Testimonial { Name = "Gamze Polat",    Title = "Doktor",            Comment = "Ailem ile Kapadokya tatilimizde SUV kiraladık. Araç pırıl pırıl teslim edildi, sorunsuz bir deneyimdi.", ImageUrl = "https://i.pravatar.cc/150?img=23" },
                    new Testimonial { Name = "Haluk Demirci",  Title = "Akademisyen",       Comment = "Online rezervasyon sistemi çok kullanışlı ve 7/24 müşteri hizmetleri gerçekten her zaman ulaşılabilir.", ImageUrl = "https://i.pravatar.cc/150?img=24" },
                    new Testimonial { Name = "Derya Keskin",   Title = "Pazarlama Uzmanı",  Comment = "Fiyat performans açısından çok memnun kaldım, üstelik araç iade sürecinde en ufak bir sorun yaşamadım.", ImageUrl = "https://i.pravatar.cc/150?img=25" },
                };
                await context.Testimonials.AddRangeAsync(testimonials);
                await context.SaveChangesAsync();
            }

            // ─── SocialMedias ──────────────────────────────────────────────────────────
            if (!context.SocialMedias.Any())
            {
                var socialMedias = new List<SocialMedia>
                {
                    new SocialMedia { Name = "Facebook",  Icon = "fab fa-facebook-f",  Url = "https://facebook.com" },
                    new SocialMedia { Name = "Twitter",   Icon = "fab fa-twitter",     Url = "https://twitter.com" },
                    new SocialMedia { Name = "Instagram", Icon = "fab fa-instagram",   Url = "https://instagram.com" },
                    new SocialMedia { Name = "LinkedIn",  Icon = "fab fa-linkedin-in", Url = "https://linkedin.com" },
                    new SocialMedia { Name = "YouTube",   Icon = "fab fa-youtube",     Url = "https://youtube.com" },
                };
                await context.SocialMedias.AddRangeAsync(socialMedias);
                await context.SaveChangesAsync();
            }

            // ─── FooterAddresses ───────────────────────────────────────────────────────
            if (!context.FooterAddresses.Any())
            {
                var footerAddresses = new List<FooterAddress>
                {
                    new FooterAddress
                    {
                        Description = "İstanbul Genel Merkez",
                        Address     = "Büyükdere Cad. No:185 Levent, İstanbul",
                        Phone       = "+90 212 555 0100",
                        Email       = "istanbul@rentacar.com.tr"
                    },
                    new FooterAddress
                    {
                        Description = "Ankara Şube",
                        Address     = "Tunalı Hilmi Cad. No:78 Kavaklıdere, Ankara",
                        Phone       = "+90 312 555 0200",
                        Email       = "ankara@rentacar.com.tr"
                    },
                    new FooterAddress
                    {
                        Description = "İzmir Şube",
                        Address     = "Atatürk Cad. No:42 Alsancak, İzmir",
                        Phone       = "+90 232 555 0300",
                        Email       = "izmir@rentacar.com.tr"
                    },
                };
                await context.FooterAddresses.AddRangeAsync(footerAddresses);
                await context.SaveChangesAsync();
            }

            // ─── Contacts ──────────────────────────────────────────────────────────────
            if (!context.Contacts.Any())
            {
                var contacts = new List<Contact>
                {
                    new Contact { Name = "Kemal Aydın",    Email = "kemal.aydin@gmail.com",     Subject = "Uzun dönem kiralama",         Message = "30 günlük kiralama için fiyat teklifi alabilir miyim?",                    SendDate = new DateTime(2025, 3, 10) },
                    new Contact { Name = "Sema Demir",     Email = "sema.demir@hotmail.com",    Subject = "Havalimanı teslim",           Message = "Sabah 06:00'da araç teslimi mümkün mü?",                                   SendDate = new DateTime(2025, 3, 15) },
                    new Contact { Name = "Volkan Çetin",   Email = "volkan.cetin@outlook.com",  Subject = "Çocuk koltuğu",              Message = "Rezervasyona çocuk koltuğu ekleyebilir miyim?",                            SendDate = new DateTime(2025, 3, 22) },
                    new Contact { Name = "Özlem Güler",    Email = "ozlem.guler@yandex.com",    Subject = "İptal ve iade",              Message = "Rezervasyonumu iptal etmek istiyorum, iade süreci nasıl işliyor?",          SendDate = new DateTime(2025, 4, 5) },
                    new Contact { Name = "Berk Kaçmaz",    Email = "berk.kacmaz@gmail.com",     Subject = "Yurt dışı seyahat izni",     Message = "Yunanistan'a geçiş için ek belge gerekmekte midir?",                       SendDate = new DateTime(2025, 4, 18) },
                    new Contact { Name = "İrem Özdemir",   Email = "irem.ozdemir@icloud.com",   Subject = "Kurumsal fatura",            Message = "Firmamız adına fatura kesilebiliyor mu?",                                   SendDate = new DateTime(2025, 5, 2) },
                };
                await context.Contacts.AddRangeAsync(contacts);
                await context.SaveChangesAsync();
            }

            // ─── Reservations ──────────────────────────────────────────────────────────
            if (!context.Reservations.Any())
            {
                var cars = context.Cars.ToList();
                var locations = context.Locations.ToList();

                int loc1 = locations[0].Id; // İstanbul Havalimanı
                int loc2 = locations[1].Id; // Sabiha Gökçen
                int loc3 = locations[2].Id; // Ankara
                int loc5 = locations[4].Id; // Kadıköy

                var reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        Name = "Osman", Surname = "Karahan", Email = "osman.karahan@mail.com", Phone = "05301112233",
                        CarId = cars[0].Id, PickUpLocationId = loc1, DropOffLocationId = loc2,
                        Age = 32, DriverLicenseYear = 8, Description = "İş seyahati",
                        Status = "Completed", PickUpDate = new DateTime(2025, 3, 1), ReturnDate = new DateTime(2025, 3, 4),
                        StartKilometer = 850, EndKilometer = 1110,
                        StartFuelLevel = 100, EndFuelLevel = 45,
                        CheckOutAt = new DateTime(2025, 3, 1, 9, 0, 0), CheckInAt = new DateTime(2025, 3, 4, 18, 0, 0),
                        ExtraChargeAmount = 0
                    },
                    new Reservation
                    {
                        Name = "Selin", Surname = "Arslan", Email = "selin.arslan@mail.com", Phone = "05422334455",
                        CarId = cars[3].Id, PickUpLocationId = loc1, DropOffLocationId = loc1,
                        Age = 27, DriverLicenseYear = 5, Description = "Aile tatili",
                        Status = "Rented", PickUpDate = new DateTime(2025, 6, 20), ReturnDate = new DateTime(2025, 6, 27),
                        StartKilometer = 720, StartFuelLevel = 100,
                        CheckOutAt = new DateTime(2025, 6, 20, 10, 30, 0),
                        ExtraChargeAmount = 0
                    },
                    new Reservation
                    {
                        Name = "Caner", Surname = "Bozkurt", Email = "caner.bozkurt@mail.com", Phone = "05533445566",
                        CarId = cars[6].Id, PickUpLocationId = loc3, DropOffLocationId = loc3,
                        Age = 40, DriverLicenseYear = 15, Description = "Uzun yol",
                        Status = "Pending", PickUpDate = new DateTime(2025, 7, 5), ReturnDate = new DateTime(2025, 7, 12),
                        ExtraChargeAmount = 0
                    },
                    new Reservation
                    {
                        Name = "Hazal", Surname = "Çevik", Email = "hazal.cevik@mail.com", Phone = "05644556677",
                        CarId = cars[10].Id, PickUpLocationId = loc5, DropOffLocationId = loc5,
                        Age = 29, DriverLicenseYear = 6, Description = "Şehir içi",
                        Status = "Pending", PickUpDate = new DateTime(2025, 7, 10), ReturnDate = new DateTime(2025, 7, 13),
                        ExtraChargeAmount = 0
                    },
                    new Reservation
                    {
                        Name = "Rıfat", Surname = "Duman", Email = "rifat.duman@mail.com", Phone = "05755667788",
                        CarId = cars[16].Id, PickUpLocationId = loc1, DropOffLocationId = loc1,
                        Age = 35, DriverLicenseYear = 10, Description = "Elektrikli araç deneyimi",
                        Status = "Completed", PickUpDate = new DateTime(2025, 4, 15), ReturnDate = new DateTime(2025, 4, 17),
                        StartKilometer = 100, EndKilometer = 340,
                        StartFuelLevel = 100, EndFuelLevel = 62,
                        CheckOutAt = new DateTime(2025, 4, 15, 8, 0, 0), CheckInAt = new DateTime(2025, 4, 17, 20, 0, 0),
                        ExtraChargeAmount = 0
                    },
                };
                await context.Reservations.AddRangeAsync(reservations);
                await context.SaveChangesAsync();
            }

            // ─── Users ─────────────────────────────────────────────────────────────────
            if (!userManager.Users.Any())
            {
                // Admin
                var admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@rentacar.com.tr",
                    Name = "Admin",
                    Surname = "Kullanıcı",
                    EmailConfirmed = true
                };
                var adminResult = await userManager.CreateAsync(admin, "Admin@1234");
                if (adminResult.Succeeded)
                    await userManager.AddToRoleAsync(admin, RolesType.Admin.ToString());

                // Manager
                var manager = new AppUser
                {
                    UserName = "manager",
                    Email = "manager@rentacar.com.tr",
                    Name = "Şube",
                    Surname = "Müdürü",
                    EmailConfirmed = true
                };
                var managerResult = await userManager.CreateAsync(manager, "Manager@1234");
                if (managerResult.Succeeded)
                    await userManager.AddToRoleAsync(manager, RolesType.Manager.ToString());

                // Member
                var member = new AppUser
                {
                    UserName = "ahmetyilmaz",
                    Email = "ahmet.yilmaz@mail.com",
                    Name = "Ahmet",
                    Surname = "Yılmaz",
                    EmailConfirmed = true
                };
                var memberResult = await userManager.CreateAsync(member, "Member@1234");
                if (memberResult.Succeeded)
                    await userManager.AddToRoleAsync(member, RolesType.Member.ToString());
            }
        }
    }
}