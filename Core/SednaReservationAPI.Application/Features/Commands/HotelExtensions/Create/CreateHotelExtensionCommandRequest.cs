using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create
{
    public class CreateHotelExtensionCommandRequest : IRequest<CreateHotelExtensionCommandResponse>
    {
        public List<HotelExtensionDto> HotelExtensions { get; set; } // Eklentiler

    }

    public class HotelExtensionDto
    {
        public string hotelId { get; set; }
        public string IconUrl { get; set; } // Eklenti simge URL'si
        public string Name { get; set; } // Eklenti adı
    }
}
