using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Payment.CreatePayment
{
    public class CreatePaymentCommandRequest : IRequest<CreatePaymentCommandResponse>
    {
        public string ReservationId { get; set; }
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
