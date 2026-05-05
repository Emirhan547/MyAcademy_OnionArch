using FluentValidation;
using OnionApp.Application.Features.Commands.ServiceCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.ServiceValidators
{
    public class CreateServiceValidator:AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Title Boş geçilemez");
            RuleFor(x=>x.IconUrl).NotEmpty().WithMessage("Icon Url Boş geçilemez");
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Description Boş geçilemez");
        }
    }
}
