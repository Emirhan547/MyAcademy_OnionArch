using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OnionApp.API.Security;
using System.Security.Claims;

namespace OnionApp.API.Hubs;

[Authorize(Policy = PolicyNames.EmployeeOnly)]
public class ReservationHub : Hub
{
    public override async Task OnConnectedAsync()
    {
        var roleClaims = Context.User?.FindAll(ClaimTypes.Role).Select(x => x.Value).Distinct(StringComparer.OrdinalIgnoreCase)
            ?? Enumerable.Empty<string>();

        foreach (var role in roleClaims)
        {
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase) || role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, role);
            }
        }

        await base.OnConnectedAsync();
    }
}