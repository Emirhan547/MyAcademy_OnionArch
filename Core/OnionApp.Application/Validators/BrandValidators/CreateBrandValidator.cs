using FluentValidation;
using OnionApp.Application.Features.Commands.BrandCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.BrandValidators
{
    public class CreateBrandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Marka adı boş bırakılamaz");
        }
    }
}
