using SednaReservationAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Domain.Entities
{
    public class RoomExtension: BaseEntitity
    {
        public string roomId { get; set; }
        public string iconUrl { get; set; } 
        public string Name { get; set; } 

    }
}
