using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Hotel.DeleteHotel
{
    public class DeleteHotelCommandRequest : IRequest<DeleteHotelCommandResponse>
    {
        public string? Id { get; set; }
    }
}
