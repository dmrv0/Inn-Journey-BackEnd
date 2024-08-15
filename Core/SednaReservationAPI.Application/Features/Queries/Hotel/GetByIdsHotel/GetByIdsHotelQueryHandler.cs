using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdsHotel
{
    public class GetByIdsHotelQueryHandler: IRequestHandler<GetByIdsHotelQueryRequest, GetByIdsHotelQueryResponse>
    {
        IHotelReadRepository _hotelRepository;

        public GetByIdsHotelQueryHandler(IHotelReadRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<GetByIdsHotelQueryResponse> Handle(GetByIdsHotelQueryRequest request, CancellationToken cancellationToken)
        {

            var hotels = await _hotelRepository.GetByIdsAsync(request.HotelIds);

            // Yanıt modelini oluştur ve doldur
            var response = new GetByIdsHotelQueryResponse
            {
                Hotels = hotels.ToList() // Oteller listesini ayarla
            };

            return response;

        }
    }
}
