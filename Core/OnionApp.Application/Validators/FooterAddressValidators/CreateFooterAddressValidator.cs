using FluentValidation;
using OnionApp.Application.Features.Commands.FooterAddressCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Validators.FooterAddressValidators
{
    public class CreateFooterAddressValidator:AbstractValidator<CreateFooterAddressCommand>
    {
        public CreateFooterAddressValidator()
        {
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres alanı boş geçilemez.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
        
        }
    }
}
