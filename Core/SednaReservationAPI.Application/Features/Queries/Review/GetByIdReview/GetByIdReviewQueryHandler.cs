using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetByIdReview
{
    public class GetByIdReviewQueryHandler : IRequestHandler<GetByIdReviewQueryRequest, GetByIdReviewQueryResponse>
    {
        readonly IReviewReadRepository _reviewReadRepository;

        public GetByIdReviewQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<GetByIdReviewQueryResponse> Handle(GetByIdReviewQueryRequest request, CancellationToken cancellationToken)
        {
            var review = await _reviewReadRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdReviewQueryResponse
            {
                Id = review.Id.ToString(),
                HotelId = review.HotelId,
                UserId = review.UserId,
                Rating = review.Rating,
                Comment = review.Comment
            };

            return response;
        }
    }
}
