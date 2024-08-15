using SednaReservationAPI.Application.Repositories.RoomExtensions;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories.RoomExtensions
{
    public class RoomExtensionsWriteRepository:WriteRepository<RoomExtension>, IWriteRepositoryRoomExtensions
    {
        public RoomExtensionsWriteRepository(SednaReservationAPIDbContext context) : base(context)
        {

        }
    }
}
