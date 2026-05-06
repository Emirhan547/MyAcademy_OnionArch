namespace OnionApp.WebUI.Dtos.AiDtos
{
    public sealed class ReservationAssistantAiRequestDto
    {
        public string PickUpLocation { get; set; } = string.Empty;
        public string DropOffLocation { get; set; } = string.Empty;
        public DateTime? PickUpDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int Age { get; set; } = 25;
        public int DriverLicenseYear { get; set; } = 3;
        public string TravelNotes { get; set; } = string.Empty;
    }
}
