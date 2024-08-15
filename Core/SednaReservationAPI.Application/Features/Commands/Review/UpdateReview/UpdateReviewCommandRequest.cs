using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.UpdateReview
{
    public class UpdateReviewCommandRequest : IRequest<UpdateReviewCommandResponse>
    {
        public string Id { get; set; }
        public string HotelId { get; set; }
        public string UserId { get; set; }
        public float Rating { get; set; }
        public string? Comment { get; set; }
    }
}
