using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdsHotel
{
    public class GetByIdsHotelQueryResponse
    {
       public List<Domain.Entities.Hotel> Hotels { get; set; }
    }
}
