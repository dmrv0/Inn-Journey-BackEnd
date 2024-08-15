using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.HotelExtensions.GetHotelExtensionsByHotelId
{
    public class GetHotelExtensionsByHotelIdQueryRequest:IRequest<List<GetHotelExtensionsByHotelIdQueryResponse>>
    {
        public string hotelId { get; set; }
    }
}
