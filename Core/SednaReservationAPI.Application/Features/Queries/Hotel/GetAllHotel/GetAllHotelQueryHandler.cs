using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel
{
    public class GetAllHotelQueryHandler : IRequestHandler<GetAllHotelQueryRequest, List<GetAllHotelQueryResponse>>
    {
        private readonly IHotelReadRepository _hotelReadRepository;

        public GetAllHotelQueryHandler(IHotelReadRepository hotelReadRepository)
        {
            _hotelReadRepository = hotelReadRepository;
        }

        public Task<List<GetAllHotelQueryResponse>> Handle(GetAllHotelQueryRequest request, CancellationToken cancellationToken)
        {
            var hotelsQuery = _hotelReadRepository.GetAll(false);

            // Sıralama yap
            if (request.MaxStar.HasValue)
            {
                // MaxStar bool olduğundan sıralama true (en yüksekten düşüğe) veya false (en düşükten yükseğe) olarak yapılır
                hotelsQuery = request.MaxStar.Value
                    ? hotelsQuery.OrderByDescending(h => h.Star) // Büyükten küçüğe
                    : hotelsQuery.OrderBy(h => h.Star); // Küçükten büyüğe
            }
            else if (request.MaxPrice.HasValue)
            {
                // MaxPrice bool olduğundan sıralama true (en yüksekten düşüğe) veya false (en düşükten yükseğe) olarak yapılır
                hotelsQuery = request.MaxPrice.Value
                    ? hotelsQuery.OrderByDescending(h => h.standartRoomPrice) // Büyükten küçüğe
                    : hotelsQuery.OrderBy(h => h.standartRoomPrice); // Küçükten büyüğe
            }

            // Pagination (Sayfalandırma)
            if (request.Page.HasValue && request.Size.HasValue)
            {
                var totalCount = _hotelReadRepository.GetAll(false).Count();

                var hotels = hotelsQuery
                    .Skip(request.Page.Value * request.Size.Value)
                    .Take(request.Size.Value)
                    .Select(hotel => new GetAllHotelQueryResponse
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
                        ImageUrl = hotel.ImageUrl,
                        TotalCount = totalCount,    
                    }).ToList();

                return Task.FromResult(hotels);
            }
            else
            {
                // Eğer sayfa ve boyut belirtilmemişse
                var hotels = hotelsQuery
                    .Select(hotel => new GetAllHotelQueryResponse
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
                        ImageUrl = hotel.ImageUrl,
                        TotalCount = _hotelReadRepository.GetAll(false).Count(),
                    }).ToList();

                return Task.FromResult(hotels);
            }
        }
    }
}
