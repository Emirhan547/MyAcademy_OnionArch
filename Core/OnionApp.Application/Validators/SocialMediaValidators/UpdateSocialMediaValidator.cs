using FluentValidation;
using OnionApp.Application.Features.Commands.SocialMediaCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.SocialMediaValidators
{
    public class UpdateSocialMediaValidator:AbstractValidator<UpdateSocialMediaCommand>
    {
        public UpdateSocialMediaValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Sosyal medya adı boş olamaz.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Sosyal medya URL'si boş olamaz.");
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon Boş bırakılamaz");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Sosyal medya URL'si boş olamaz.");
        }
    }
}
