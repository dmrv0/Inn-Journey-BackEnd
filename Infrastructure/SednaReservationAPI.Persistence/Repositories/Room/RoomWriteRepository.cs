using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories
{
    public class RoomWriteRepository : WriteRepository<Room>, IRoomWriteRepository
    {
        public RoomWriteRepository(SednaReservationAPIDbContext context) : base(context)
        {
        }
    }
}
