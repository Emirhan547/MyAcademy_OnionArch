using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.SocialMediaCommands
{
    public class RemoveSocialMediaCommand:IRequest<BaseResult<object>>
    {
        public int Id { get; set; }

        public RemoveSocialMediaCommand(int id)
        {
            Id = id;
        }
    }
}
