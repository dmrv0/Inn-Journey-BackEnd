using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Reservation.DeleteReservation
{
    public class DeleteReservationCommandRequest : IRequest<DeleteReservationCommandResponse>
    {
        public string? Id { get; set; }
    }
}
