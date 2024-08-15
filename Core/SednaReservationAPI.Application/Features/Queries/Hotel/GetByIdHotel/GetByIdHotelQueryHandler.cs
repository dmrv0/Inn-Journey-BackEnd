using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdHotel
{
    public class GetByIdHotelQueryHandler : IRequestHandler<GetByIdHotelQueryRequest, GetByIdHotelQueryResponse>
    {

        readonly IHotelReadRepository _hotelReadRepository;

        public GetByIdHotelQueryHandler(IHotelReadRepository hotelReadRepository)
        {
            _hotelReadRepository = hotelReadRepository;
        }

        public async Task<GetByIdHotelQueryResponse> Handle(GetByIdHotelQueryRequest request, CancellationToken cancellationToken)
        {

            var hotel = await _hotelReadRepository.GetByIdAsync(request.Id, false);

          
            var response = new GetByIdHotelQueryResponse
            {
                Id = hotel.Id.ToString(),
                Name = hotel.Name,
                Address = hotel.Address,
                Phone = hotel.Phone,
                Email = hotel.Email,
                Description = hotel.Description,
                StarRating = hotel.StarRating,
                Star = hotel.Star,
                standartRoomPrice = hotel.standartRoomPrice,
                googleMap = hotel.googleMap,
                ImageUrl = hotel.ImageUrl
            };

            return response;
        }
    }
}
