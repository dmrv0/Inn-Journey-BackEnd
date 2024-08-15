using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandRequest : IRequest<CreateReviewCommandResponse>
    {
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; }
    }
}
