using MediatR;
using SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.HotelExtensions.Update
{
    public class UpdateHotelExtensionCommandRequest:IRequest<UpdateHotelExtensionCommandResponse>
    {
        public List<HotelExtensionDto> HotelExtensions { get; set; } // Eklentiler
    }
}
