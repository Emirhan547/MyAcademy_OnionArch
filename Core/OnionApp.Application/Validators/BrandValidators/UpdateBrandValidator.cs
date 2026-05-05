using FluentValidation;
using OnionApp.Application.Features.Commands.BrandCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.BrandValidators
{
    public class UpdateBrandValidator:AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Marka adı boş bırakılamaz");
        }
    }
}
