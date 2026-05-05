using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.LocationCommands
{
    public class CreateLocationCommand:IRequest<BaseResult<object>>
    {
        public string Name { get; set; }
    }
}
