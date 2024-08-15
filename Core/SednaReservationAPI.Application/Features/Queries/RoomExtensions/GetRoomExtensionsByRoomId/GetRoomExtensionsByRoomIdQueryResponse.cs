using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.RoomExtensions.GetRoomExtensionsByRoomId
{
    public class GetRoomExtensionsByRoomIdQueryResponse
    {
        public string Id { get; set; }
        public string roomId { get; set; }
        public string iconUrl { get; set; }
        public string Name { get; set; }

    }
}
