using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Hotel.CreateHotel
{
    public class CreateHotelCommandResponse
    {
        public string? hotelId {  get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }

    }
}
