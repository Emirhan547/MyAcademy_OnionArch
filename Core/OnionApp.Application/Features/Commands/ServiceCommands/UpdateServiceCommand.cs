using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.ServiceCommands
{
    public class UpdateServiceCommand:IRequest<BaseResult<object>>
    {
        public int Id { get; set; }
        public string Title { get; init; }
        public string Description { get; init; }
        public string IconUrl { get; init; }
    }
}
