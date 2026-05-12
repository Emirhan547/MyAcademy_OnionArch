namespace OnionApp.WebUI.Dtos.DashboardStatsDtos
{
    public class DashboardStatsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int BrandCount { get; set; }
        public string AvgDaily { get; set; } = "0.00";
        public int PendingReservationCount { get; set; }
        public int ActiveReservationCount { get; set; }
        public int TodayCheckOutCount { get; set; }
        public int TodayReturnCount { get; set; }
        public decimal ReservationLoadRate { get; set; }
        public DateTime GeneratedAt { get; set; }
        public int TodayReservationCount { get; set; }
    }
}

