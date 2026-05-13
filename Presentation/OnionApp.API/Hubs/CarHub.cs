using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using OnionApp.API.Security;
using OnionApp.Application.Features.Queries.StatisticsQueries;

namespace OnionApp.API.Hubs
{
    
    public class CarHub : Hub<ICarClient>
    {
             

    }
}
