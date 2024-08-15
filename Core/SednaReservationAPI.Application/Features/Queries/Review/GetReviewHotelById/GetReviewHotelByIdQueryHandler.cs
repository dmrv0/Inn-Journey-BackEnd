using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Review.GetReviewHotelById
{
    public class GetReviewHotelByIdQueryHandler:IRequestHandler<GetReviewHotelByIdQueryRequest, GetReviewHotelByIdQueryResponse>
    {
        IReviewReadRepository _reviewReadRepository;

        public GetReviewHotelByIdQueryHandler(IReviewReadRepository reviewReadRepository)
        {
            _reviewReadRepository = reviewReadRepository;
        }

        public async Task<GetReviewHotelByIdQueryResponse> Handle(GetReviewHotelByIdQueryRequest request, CancellationToken cancellation)
        {
            List<Domain.Entities.Review> review =  await _reviewReadRepository.GetWhere(r => r.HotelId == request.HotelId)
                .OrderByDescending(p => p.CreatedDate) // En son eklenenleri önce al
                .Skip(request.Page * request.Size) 
                .Take(request.Size).Select(r => new Domain.Entities.Review
                {
                    Id = r.Id,
                    UserId = r.UserId,
                    Comment = r.Comment,
                    CreatedDate = r.CreatedDate,
                    UpdatedDate = r.UpdatedDate,
                    HotelId = r.HotelId,
                    Rating = r.Rating,

                }).ToListAsync();


            return new() { TotalCount = _reviewReadRepository.GetWhere(r => r.HotelId == request.HotelId).Count(), reviews = review };

        }
    }
}
