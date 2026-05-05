using MediatR;
using OnionApp.Application.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Commands.BannerCommands
{
    public class UpdateBannerCommand:IRequest<BaseResult<object>>
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string VideoDescription { get; set; }
        public string VideoUrl { get; set; }
    }
}
