using SednaReservationAPI.Application.Repositories.HotelExtensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories.HotelExtensions
{
    public class HotelExtensionsWriteRepository : WriteRepository<HotelExtension>, IWriteRepositoryHotelExtensions
    {
        public HotelExtensionsWriteRepository(SednaReservationAPIDbContext context) : base(context)
        {
        }
    }
}
