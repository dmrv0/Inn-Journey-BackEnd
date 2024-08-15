using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetUserByIdHotel
{

    public class GetByAdminAllHotelQueryResponse
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int Star { get; set; }
        public double StarRating { get; set; }
        public decimal? standartRoomPrice { get; set; }
        public string? googleMap { get; set; }
        public string ImageUrl { get; set; } = string.Empty;


    }
}
