using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OnionApp.API.Security;
using OnionApp.Application.Features.Queries.StatisticsQueries;

namespace OnionApp.API.Hubs
{
    [Authorize(Policy = PolicyNames.EmployeeOnly)]
    public class CarHub : Hub<ICarClient>
    {
             

    }
}
