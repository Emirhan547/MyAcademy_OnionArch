using MediatR;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ReservationCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ReservationHandlers
{
    public class UpdateReservationCheckOutCommandHandler(IRepository<Reservation> repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateReservationCheckOutCommand>
    {
        public async Task Handle(UpdateReservationCheckOutCommand request, CancellationToken cancellationToken)
        {
            var reservation = await repository.GetByIdAsync(request.ReservationId);
            if (reservation == null) return;

            reservation.StartKilometer = request.StartKilometer;
            reservation.StartFuelLevel = request.StartFuelLevel;
            reservation.CheckOutDamageNote = request.CheckOutDamageNote;
            reservation.CheckOutAt = DateTime.UtcNow;
            reservation.Status = "Rented";

            repository.Update(reservation);
            await unitOfWork.SaveChangesAsync();
        }
    }
}