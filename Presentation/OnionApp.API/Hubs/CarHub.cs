using MediatR;
using Microsoft.AspNetCore.SignalR;
using OnionApp.Application.Features.Queries.StatisticsQueries;

namespace OnionApp.API.Hubs
{
    public class CarHub(IMediator mediator) : Hub
    {
       

        public async Task SendCarCount()
        {
            var result = await mediator.Send(new GetCarCountQuery());
            await Clients.All.SendAsync("ReceiveCarCount", result);
        }

    }
}
