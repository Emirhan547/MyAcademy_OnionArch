using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Results.TokenResults
{
    public class GetTokenResponse
    {
        public GetTokenResponse(string token,DateTime expireDate)
        {
            Token=token;
            ExpireDate=expireDate;
        }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
