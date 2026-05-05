using FluentValidation;
using OnionApp.Application.Features.Commands.BlogCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.BlogValidators
{
    public class CreateBlogValidator:AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Blog başlığı boş olamaz");
            RuleFor(x => x.CoverImageUrl).NotEmpty().WithMessage("Kapak görseli url'si boş olamaz");
            RuleFor(x => x.CreatedDate).NotEmpty().WithMessage("Oluşturulma tarihi boş olamaz");
        }
    }
}
