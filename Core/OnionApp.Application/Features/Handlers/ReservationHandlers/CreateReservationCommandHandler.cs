using Mapster;
using MediatR;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ReservationCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler(IRepository<Reservation> _repository,IUnitOfWork _unitOfWork) : IRequestHandler<CreateReservationCommand>
    {
        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var mapped = request.Adapt<Reservation>();
            mapped.Status = string.IsNullOrWhiteSpace(mapped.Status) ? "Pending" : mapped.Status;
            await _repository.CreateAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
