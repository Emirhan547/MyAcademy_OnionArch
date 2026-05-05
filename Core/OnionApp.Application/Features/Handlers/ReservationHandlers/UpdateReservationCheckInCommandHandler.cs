using MediatR;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.ReservationCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Features.Handlers.ReservationHandlers
{
    public class UpdateReservationCheckInCommandHandler(IRepository<Reservation> repository, IUnitOfWork unitOfWork) : IRequestHandler<UpdateReservationCheckInCommand>
    {
        public async Task Handle(UpdateReservationCheckInCommand request, CancellationToken cancellationToken)
        {
            var reservation = await repository.GetByIdAsync(request.ReservationId);
            if (reservation == null) return;

            reservation.EndKilometer = request.EndKilometer;
            reservation.EndFuelLevel = request.EndFuelLevel;
            reservation.CheckInDamageNote = request.CheckInDamageNote;
            reservation.ExtraChargeAmount = request.ExtraChargeAmount;
            reservation.CheckInAt = DateTime.UtcNow;
            reservation.Status = "Completed";

            repository.Update(reservation);
            await unitOfWork.SaveChangesAsync();
        }
    }
}