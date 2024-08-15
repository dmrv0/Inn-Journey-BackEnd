using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByUserId
{
    public class GetReservationByUserIdQueryResponse
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? HotelId { get; set; }
        public string? RoomId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public string? Status { get; set; }
        public bool? Deleted { get; set; }
        public int? TotalCount { get; set; }
    }
}
