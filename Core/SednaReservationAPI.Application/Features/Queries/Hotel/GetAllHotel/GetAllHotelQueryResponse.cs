using SednaReservationAPI.Domain.Entities;
using SednaReservationAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel
{
    public class GetAllHotelQueryResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
        public double StarRating { get; set; }
        public float Star {  get; set; }
        public string? ImageUrl { get; set; }
        public decimal? standartRoomPrice { get; set; }
        public string? googleMap { get; set; }
        public int? TotalCount { get; set; }
    }
}
