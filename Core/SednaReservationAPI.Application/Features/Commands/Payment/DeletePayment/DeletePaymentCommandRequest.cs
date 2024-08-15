using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Payment.DeletePayment
{
    public class DeletePaymentCommandRequest : IRequest<DeletePaymentCommandResponse>
    {
        public string? Id { get; set; }
    }
}
