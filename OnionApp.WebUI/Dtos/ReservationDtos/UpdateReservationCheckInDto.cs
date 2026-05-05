namespace OnionApp.WebUI.Dtos.ReservationDtos
{
    public class UpdateReservationCheckInDto
    {
        public int ReservationId { get; set; }
        public int EndKilometer { get; set; }
        public int EndFuelLevel { get; set; }
        public string? CheckInDamageNote { get; set; }
        public decimal ExtraChargeAmount { get; set; }
    }
}
