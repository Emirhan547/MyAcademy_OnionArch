using FluentValidation;
using OnionApp.Application.Features.Commands.CarCommands;
using OnionApp.Application.Features.Commands.ContactCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.ContactValidators
{
    public class UpdateContactValidator:AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş bırakılamaz");
        }
    }
}
