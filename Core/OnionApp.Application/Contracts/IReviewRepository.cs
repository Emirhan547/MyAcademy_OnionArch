using OnionApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionApp.Application.Contracts
{
    public interface IReviewRepository
    {
        Task<List<Review>>GetReviewsByCarId(int carId);
    }
}
