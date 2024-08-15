using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetReviewUserById
{
    public class GetReviewUserByIdQueryResponse
    {
        public List<Domain.Entities.Review> reviews { get; set; }
        public int TotalCount { get; set; }
    }
}
