using SednaReservationAPI.Application.Repositories.HotelExtensions;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories.HotelExtensions
{
    public class HotelExtensionsReadRepository : ReadRepository<HotelExtension>, IReadRepositoryHotelExtensions
    {
        public HotelExtensionsReadRepository(SednaReservationAPIDbContext context) : base(context)
        {
        }
    }
}
