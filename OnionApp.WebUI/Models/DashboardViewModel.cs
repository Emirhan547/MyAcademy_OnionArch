namespace OnionApp.WebUI.Models
{
    public class DashboardViewModel
    {
        public int CarCount { get; set; }
        public int BrandCount { get; set; }
        public int LocationCount { get; set; }
        public int BlogCount { get; set; }
        public int AuthorCount { get; set; }
        public int AutoTransmissionCount { get; set; }
        public int ElectricCount { get; set; }
        public int GasOrDieselCount { get; set; }
        public int UnderThousandKmCount { get; set; }
        public decimal AvgDailyPrice { get; set; }
        public decimal AvgWeeklyPrice { get; set; }
        public decimal AvgMonthlyPrice { get; set; }
        public string TopBrand { get; set; } = string.Empty;
        public string MostCommentedBlog { get; set; } = string.Empty;
        public string MinDailyPriceCar { get; set; } = string.Empty;
        public string MaxDailyPriceCar { get; set; } = string.Empty;
    }
}
