using MediatR;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.CarFeatureCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository _repository) : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        public async Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            await _repository.ChangeCarFeatureAvailableToTrue(request.Id);
        }
    }
}
