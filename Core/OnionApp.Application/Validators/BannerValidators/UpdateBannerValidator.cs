using FluentValidation;
using OnionApp.Application.Features.Commands.BannerCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.BannerValidators
{
    public class UpdateBannerValidator:AbstractValidator<UpdateBannerCommand>
    {
        public UpdateBannerValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Banner Başlık Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Banner Açıklama Boş Geçilemez");
            RuleFor(x => x.VideoUrl).NotEmpty().WithMessage("Banner Video Url Boş Geçilemez");
            RuleFor(x => x.VideoDescription).NotEmpty().WithMessage("Banner Video Açıklaması Boş Geçilemez");
        }
    }
}
