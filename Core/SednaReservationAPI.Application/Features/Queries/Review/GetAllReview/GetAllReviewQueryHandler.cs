using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetAllReview
{
    public class GetAllReviewQueryHandler : IRequestHandler<GetAllReviewQueryRequest, List<GetAllReviewQueryResponse>>
    {
        IReviewReadRepository _reviewReadRepository;

        public GetAllReviewQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public Task<List<GetAllReviewQueryResponse>> Handle(GetAllReviewQueryRequest request, CancellationToken cancellationToken)
        {
            var review = _reviewReadRepository.GetAll(false).Select(review => new GetAllReviewQueryResponse
            {
                Id = review.Id.ToString(),
                HotelId = review.HotelId,
                UserId = review.UserId,
                Rating = review.Rating,
                Comment = review.Comment

            }).ToList();
            return Task.FromResult(review);
        }
    }
}