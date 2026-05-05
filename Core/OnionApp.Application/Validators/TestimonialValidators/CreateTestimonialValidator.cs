using FluentValidation;
using OnionApp.Application.Features.Commands.TestimonialCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.TestimonialValidators
{
    public class CreateTestimonialValidator:AbstractValidator<CreateTestimonialCommand>
    {
        public CreateTestimonialValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Boş Geçilemez");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Yorum Boş Geçilemez");

        }
    }
}
