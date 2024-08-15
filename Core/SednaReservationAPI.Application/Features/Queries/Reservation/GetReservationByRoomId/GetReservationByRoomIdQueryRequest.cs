using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByRoomId
{
    public class GetReservationByRoomIdQueryRequest: IRequest<List<GetReservationByRoomIdQueryResponse>>
    {
        public string roomId { get; set; }
    }
}
