using Microsoft.AspNetCore.SignalR;
using OnionApp.API.Hubs;

namespace OnionApp.API.Services
{
    public class ReservationNotifier(IHubContext<ReservationHub> hubContext) : IReservationNotifier
    {
        private static readonly List<object> _history = [];
        private static int _unreadCount;

        public async Task NotifyReservationCreatedAsync(int reservationId, string fullName, DateTime createdAtUtc)
        {
            Interlocked.Increment(ref _unreadCount);

            var payload = new
            {
                ReservationId = reservationId,
                FullName = fullName,
                CreatedAtUtc = createdAtUtc
            };

            lock (_history)
            {
                _history.Insert(0, payload);
                if (_history.Count > 50) _history.RemoveAt(_history.Count - 1);
            }

            await hubContext.Clients.Groups("Admin", "Manager").SendAsync("ReceiveReservationCreated", payload);
            await hubContext.Clients.Groups("Admin", "Manager").SendAsync("ReceiveReservationCount", _unreadCount);
        }

        public Task<int> GetUnreadCountAsync() => Task.FromResult(_unreadCount);

        public Task<IReadOnlyCollection<object>> GetRecentNotificationsAsync()
        {
            lock (_history)
            {
                return Task.FromResult((IReadOnlyCollection<object>)_history.ToList());
            }
        }
    }
}