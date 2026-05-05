using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Commands.AppUserCommands;
using OnionApp.Domain.Entities;
using OnionApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AppUserHandlers
{
    public class CreateAppUserCommandHandler(UserManager<AppUser> userManager) : IRequestHandler<CreateAppUserCommand>
    {
        public async Task Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname
            };

            var createResult = await userManager.CreateAsync(user, request.Password);
            if (!createResult.Succeeded)
            {
                var errors = string.Join(", ", createResult.Errors.Select(x => x.Description));
                throw new InvalidOperationException(errors);
            }

            await userManager.AddToRoleAsync(user, RolesType.Member.ToString());
        }
    }
}
