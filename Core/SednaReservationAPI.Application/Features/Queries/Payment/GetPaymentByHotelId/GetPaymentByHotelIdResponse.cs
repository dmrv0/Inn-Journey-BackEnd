using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByHotelId
{
    public class GetPaymentByHotelIdResponse
    {
        public string? Id { get; set; }
        public string userId { get; set; }
        public string hotelId { get; set; }
        public string ReservationId { get; set; }
        public decimal Amount { get; set; }
        public string? Status { get; set; }
        public string? PaymentMethod { get; set; }
        public DateTime Date { get; set; }
        public int TotalCount { get; set; }
    }
}
