using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.DeleteReview
{
    public class DeleteReviewCommandRequest : IRequest<DeleteReviewCommandResponse>
    {
        public string? Id { get; set; }
    }
}
