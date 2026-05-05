using FluentValidation;
using OnionApp.Application.Features.Commands.AboutCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.AboutValidators
{
    public class UpdateAboutValidator:AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("About Title Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("About Image Boş Geçilemez");
            
        }
    }
}
