using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Reservation.DeleteReservation
{
    public class DeleteReservationCommandResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
