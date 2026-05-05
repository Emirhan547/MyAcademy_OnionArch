using FluentValidation;
using OnionApp.Application.Features.Commands.LocationCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.LocationValidators
{
    public class UpdateLocationValidator:AbstractValidator<UpdateLocationCommand>
    {
        public UpdateLocationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Location alanı boş bırakılamaz");
        }
    }
}
