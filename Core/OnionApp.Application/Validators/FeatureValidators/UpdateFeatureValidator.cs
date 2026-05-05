using FluentValidation;
using OnionApp.Application.Features.Commands.FeatureCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.FeatureValidators
{
    public class UpdateFeatureValidator:AbstractValidator<UpdateFeatureCommand>
    {
        public UpdateFeatureValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Feature Alanı Boş bırakılamaz");
        }
    }
}
