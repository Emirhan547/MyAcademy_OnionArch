namespace OnionApp.WebUI.Dtos.ReservationDtos
{
    public class UpdateReservationCheckOutDto
    {
        public int ReservationId { get; set; }
        public int StartKilometer { get; set; }
        public int StartFuelLevel { get; set; }
        public string? CheckOutDamageNote { get; set; }
    }
}
