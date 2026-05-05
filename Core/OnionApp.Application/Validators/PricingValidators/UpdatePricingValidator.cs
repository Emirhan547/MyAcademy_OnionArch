using FluentValidation;
using OnionApp.Application.Features.Commands.PricingCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.PricingValidators
{
    public class UpdatePricingValidator:AbstractValidator<UpdatePricingCommand>
    {
        public UpdatePricingValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
