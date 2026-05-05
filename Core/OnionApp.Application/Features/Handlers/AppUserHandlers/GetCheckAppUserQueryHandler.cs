using MediatR;
using Microsoft.AspNetCore.Identity;
using OnionApp.Application.Contracts;
using OnionApp.Application.Features.Queries.AppUserQueries;
using OnionApp.Application.Features.Results.AppUserResults;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler(UserManager<AppUser> userManager) : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByNameAsync(request.Username);
            if (user is null)
            {
                return new GetCheckAppUserQueryResult { IsExist = false };
            }
            var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
            if (!isPasswordValid)
            {
                return new GetCheckAppUserQueryResult { IsExist = false };
            }

            var roles = await userManager.GetRolesAsync(user);

            return new GetCheckAppUserQueryResult
            {
                IsExist = true,
                Id = user.Id,
                UserName = user.UserName ?? string.Empty,
                Role = roles.FirstOrDefault() ?? string.Empty
            };
        }
    }
}
