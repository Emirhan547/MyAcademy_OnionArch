using MediatR;
using OnionApp.Application.Base;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.BlogCommands
{
    public  class RemoveBlogCommand:IRequest<BaseResult<object>>
    {
        public int Id { get; set; }

        public RemoveBlogCommand(int id)
        {
            Id = id;
        }
    }
}
