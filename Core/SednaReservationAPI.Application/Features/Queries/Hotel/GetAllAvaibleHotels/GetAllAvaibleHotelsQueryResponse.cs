using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllAvaibleHotels
{
    public class GetAllAvaibleHotelsQueryResponse
    {

        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<Domain.Entities.Hotel>? Hotels { get; set; }
        public List<string> EmptyRoomIds { get; set; } // Boş odaların ID'lerini tutan liste
        public Dictionary<string, int> AvailableRoomCapacities { get; set; } // Oda ID'leri ve kalan kapasiteleri
        public int? TotalCount { get; set; }
    }
}
