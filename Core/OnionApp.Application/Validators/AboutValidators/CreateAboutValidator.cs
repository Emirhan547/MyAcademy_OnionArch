using FluentValidation;
using OnionApp.Application.Features.Commands.AboutCommands;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.AboutValidators
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutValidator()
        {

            RuleFor(x=>x.Title).NotEmpty().WithMessage("About Title Boş Geçilemez");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("About Image Boş Geçilemez");  


        }
    }
}
