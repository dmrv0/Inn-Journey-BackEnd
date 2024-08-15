using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.DeleteRoom
{
    public class DeleteRoomCommandRequest : IRequest<DeleteRoomCommandResponse>
    {
        public string Id { get; set; }
    }
}
