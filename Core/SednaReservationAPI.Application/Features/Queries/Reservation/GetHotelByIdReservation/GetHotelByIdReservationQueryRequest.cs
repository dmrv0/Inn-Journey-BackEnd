using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation
{
    public class GetHotelByIdReservationQueryRequest : IRequest<GetHotelByIdReservationQueryResponse>
    {
        public string hotelId { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
