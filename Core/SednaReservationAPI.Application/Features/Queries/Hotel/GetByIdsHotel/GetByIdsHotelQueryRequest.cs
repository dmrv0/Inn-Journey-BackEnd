using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdsHotel
{
    public class GetByIdsHotelQueryRequest:IRequest<GetByIdsHotelQueryResponse>
    {
        public IEnumerable<string> HotelIds { get; set; } // Otel ID'leri
    }
}
