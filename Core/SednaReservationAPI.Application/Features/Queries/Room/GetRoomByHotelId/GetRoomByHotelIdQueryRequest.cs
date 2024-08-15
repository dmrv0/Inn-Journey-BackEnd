using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Room.GetRoomByHotelId
{
    public class GetRoomByHotelIdQueryRequest:IRequest<List<GetRoomByHotelIdQueryResponse>>
    {
        public string? HotelId { get; set; }
    }
}
