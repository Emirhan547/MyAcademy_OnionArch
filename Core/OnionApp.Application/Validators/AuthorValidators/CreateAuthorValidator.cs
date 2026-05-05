using FluentValidation;
using OnionApp.Application.Features.Commands.AuthorCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.AuthorValidators
{
    public class CreateAuthorValidator:AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Boş Bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl Boş Bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description Boş Bırakılamaz");
        }
    }
}
