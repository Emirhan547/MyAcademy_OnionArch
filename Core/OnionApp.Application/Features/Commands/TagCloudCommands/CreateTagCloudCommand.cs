using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.TagCloudCommands
{
    public class CreateTagCloudCommand:IRequest<BaseResult<object>>
    {
        public string Title { get; set; }
        public int BlogId { get; set; }
    }
}
