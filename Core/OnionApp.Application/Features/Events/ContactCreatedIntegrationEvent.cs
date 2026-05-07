using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Features.Events
{
    public sealed record ContactCreatedIntegrationEvent(
     int ContactId,
     string Name,
     string Email,
     string Subject,
     DateTime SendDate);
}
