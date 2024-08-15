using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.HotelExtensions.GetHotelExtensionsByHotelId
{
    public class GetHotelExtensionsByHotelIdQueryResponse
    {
        public string Id { get; set; }
        public string hotelId { get; set; }
        public string iconUrl { get; set; }
        public string Name { get; set; }

    }
}
