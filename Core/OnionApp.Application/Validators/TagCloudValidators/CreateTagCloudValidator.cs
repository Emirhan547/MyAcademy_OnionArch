using FluentValidation;
using OnionApp.Application.Features.Commands.TagCloudCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.TagCloudValidators
{
    public class CreateTagCloudValidator:AbstractValidator<CreateTagCloudCommand>
    {
        public CreateTagCloudValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.");
        }
    }
}
