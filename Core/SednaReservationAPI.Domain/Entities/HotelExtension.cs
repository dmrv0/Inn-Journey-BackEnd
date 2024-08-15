using SednaReservationAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Domain.Entities
{
    public class HotelExtension: BaseEntitity
    {
        public string? hotelId { get; set; }
        public string? iconUrl { get; set; }
        public string? Name { get; set; }
    }
}
