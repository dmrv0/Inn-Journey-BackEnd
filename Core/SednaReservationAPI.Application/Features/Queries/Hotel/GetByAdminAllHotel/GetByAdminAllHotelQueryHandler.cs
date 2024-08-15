using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetUserByIdHotel
{
    public class GetByAdminAllHotelQueryHandler : IRequestHandler<GetByAdminAllHotelQueryRequest, List<GetByAdminAllHotelQueryResponse>>
    {

        readonly IHotelReadRepository _repository;

        public GetByAdminAllHotelQueryHandler(IHotelReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetByAdminAllHotelQueryResponse>> Handle(GetByAdminAllHotelQueryRequest request, CancellationToken cancellationToken)
        {
            var hotels = _repository.GetWhere(r => r.userId == request.userId).Select(hotels => new GetByAdminAllHotelQueryResponse
            {
                Id = hotels.Id.ToString(),
                UserId = hotels.userId,
                Name = hotels.Name,
                Address = hotels.Address,
                Email = hotels.Email,
                Phone = hotels.Phone,
                Star = hotels.Star,
                ImageUrl = hotels.ImageUrl,
                standartRoomPrice = hotels.standartRoomPrice,
                StarRating = hotels.StarRating,
            }).ToList();

            return await Task.FromResult(hotels);

        }
    }
}
