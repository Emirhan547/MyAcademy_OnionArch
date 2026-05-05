using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.FeatureCommands
{
    public class CreateFeatureCommand:IRequest<BaseResult<object>>
    {
        public string Name { get; set; }
    }
}
