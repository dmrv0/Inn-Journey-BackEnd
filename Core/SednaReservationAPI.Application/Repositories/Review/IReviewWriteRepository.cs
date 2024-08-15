using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Repositories
{
    public interface IReviewWriteRepository : IWriteRepository<Review>
    {
    }
}
