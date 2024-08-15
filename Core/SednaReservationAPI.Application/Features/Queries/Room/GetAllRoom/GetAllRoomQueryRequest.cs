using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Room.GetAllRoom
{
    public class GetAllRoomQueryRequest : IRequest<List<GetAllRoomQueryResponse>>
    {
    }
}
