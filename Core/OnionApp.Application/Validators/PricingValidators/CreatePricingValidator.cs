using FluentValidation;
using OnionApp.Application.Features.Commands.PricingCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.PricingValidators
{
    public class CreatePricingValidator:AbstractValidator<CreatePricingCommand>
    {
        public CreatePricingValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name is required");
        }
    }
}
