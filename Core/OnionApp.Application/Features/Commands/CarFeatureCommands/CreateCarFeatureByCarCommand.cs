using MediatR;
using OnionApp.Application.Base;
using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand:IRequest<BaseResult<object>>
    {
        public int CarId { get; set; }
        public int FeatureId { get; set; }
        public bool Available { get; set; }
    }
}
