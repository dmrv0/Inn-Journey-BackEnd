using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.RoomType.GetByIdRoomType
{
    public class GetByIdRoomTypeQueryRequest : IRequest<GetByIdRoomTypeQueryResponse>
    {
        public string? Id { get; set; }
    }
}
