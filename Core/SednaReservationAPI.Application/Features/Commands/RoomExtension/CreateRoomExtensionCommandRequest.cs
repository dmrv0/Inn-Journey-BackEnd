using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomExtension
{
    public class CreateRoomExtensionCommandRequest: IRequest<CreateRoomExtensionCommandResponse>
    {
        public List<RoomExtensionDto> RoomExtensions { get; set; } // Eklentiler

    }

    public class RoomExtensionDto
    {
        public string roomId { get; set; }
        public string IconUrl { get; set; } // Eklenti simge URL'si
        public string Name { get; set; } // Eklenti adı
    }
}
