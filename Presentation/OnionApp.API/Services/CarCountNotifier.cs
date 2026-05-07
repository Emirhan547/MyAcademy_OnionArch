using MediatR;
using Microsoft.AspNetCore.SignalR;
using OnionApp.API.Hubs;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.StatisticsQueries;

namespace OnionApp.API.Services
{
    public class CarCountNotifier(
       IHubContext<CarHub, ICarClient> hubContext,
       IMediator mediator) : ICarCountNotifier
    {
        public async Task NotifyCarCountAsync(CancellationToken cancellationToken = default)
        {
            var result = await mediator.Send(
                new GetCarCountQuery(),
                cancellationToken);

            await hubContext.Clients.All.ReceiveCarCount(result.Data);
        }
    }
}