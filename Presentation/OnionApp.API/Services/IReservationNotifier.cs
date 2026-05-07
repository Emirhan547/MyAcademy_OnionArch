namespace OnionApp.API.Services
{
    public interface IReservationNotifier
    {
        Task NotifyReservationCreatedAsync(int reservationId, string fullName, DateTime createdAtUtc);
        Task<int> GetUnreadCountAsync();
        Task<IReadOnlyCollection<object>> GetRecentNotificationsAsync();
    }
}
