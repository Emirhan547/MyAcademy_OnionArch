using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface ICarCountNotifier
    {
        Task NotifyCarCountAsync(CancellationToken cancellationToken = default);
    }
}
