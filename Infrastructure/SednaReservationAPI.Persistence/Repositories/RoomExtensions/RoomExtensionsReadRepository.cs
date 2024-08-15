using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories.RoomExtensions
{
    public class RoomExtensionsReadRepository : ReadRepository<RoomExtension>, IReadRepositoryRoomExtensions
    {
        public RoomExtensionsReadRepository(SednaReservationAPIDbContext context) : base(context)
        {

        }

    }
}