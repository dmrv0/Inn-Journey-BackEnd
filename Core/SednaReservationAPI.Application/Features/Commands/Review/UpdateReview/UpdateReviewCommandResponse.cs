using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.UpdateReview
{
    public class UpdateReviewCommandResponse
    {
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; }
    }
}
