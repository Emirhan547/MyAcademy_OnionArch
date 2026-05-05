using FluentValidation;
using OnionApp.Application.Features.Commands.CategoryCommands;
using OnionApp.Domain.Entities;

namespace OnionApp.Application.Validators.CategoryValidators
{
    public class CategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adı boş bırakılamaz")
                                .MinimumLength(3).WithMessage("Kategori adı en az 3 karakter olmalıdır.");
        }

    }
}