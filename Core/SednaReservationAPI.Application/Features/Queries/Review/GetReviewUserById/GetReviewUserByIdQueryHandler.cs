using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetReviewUserById
{
    public class GetReviewUserByIdQueryHandler : IRequestHandler<GetReviewUserByIdQueryRequest, GetReviewUserByIdQueryResponse>
    {
        IReviewReadRepository _reviewReadRepository;

        public GetReviewUserByIdQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<GetReviewUserByIdQueryResponse> Handle(GetReviewUserByIdQueryRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Review> review = await _reviewReadRepository.GetWhere(r => r.UserId == request.userId)
                  .OrderByDescending(p => p.CreatedDate) // En son eklenenleri önce al
                  .Skip(request.Page * request.Size)
                  .Take(request.Size).Select(r => new Domain.Entities.Review
                  {
                      Id = r.Id,
                      Comment = r.Comment,
                      CreatedDate = r.CreatedDate,
                      UpdatedDate = r.UpdatedDate,
                      HotelId = r.HotelId,
                      Rating = r.Rating,

                  }).ToListAsync();

            return new() { TotalCount = _reviewReadRepository.GetWhere(r => r.UserId == request.userId).Count(), reviews = review };
        }
    }
}
