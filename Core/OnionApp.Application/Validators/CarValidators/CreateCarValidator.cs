using FluentValidation;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.CarValidators
{
    public class CreateCarValidator:AbstractValidator<CreateCarCommand>    
    {
        public CreateCarValidator()
        {
            RuleFor(x => x.Model).NotEmpty().WithMessage("Araba modeli boş bırakılamaz");
            RuleFor(x => x.Fuel).NotEmpty().WithMessage("Araba benzini boş bırakılamaz");
           
        }
    }
}
