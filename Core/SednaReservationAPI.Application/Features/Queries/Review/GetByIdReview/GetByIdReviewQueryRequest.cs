using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetByIdReview
{
    public class GetByIdReviewQueryRequest : IRequest<GetByIdReviewQueryResponse>
    {
        public string Id { get; set; }
    }
}
