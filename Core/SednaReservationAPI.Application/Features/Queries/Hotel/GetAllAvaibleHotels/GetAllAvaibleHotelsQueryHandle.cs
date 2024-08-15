using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Hotel.GetAllAvaibleHotels
{
    public class GetAllAvaibleHotelsQueryHandle : IRequestHandler<GetAllAvaibleHotelsQueryRequest, GetAllAvaibleHotelsQueryResponse>
    {
        readonly IReservationReadRepository _reservationReadRepository;
        readonly IHotelReadRepository _hotelReadRepository;
        readonly IRoomReadRepository _roomReadRepository;

        public GetAllAvaibleHotelsQueryHandle(IReservationReadRepository reservationReadRepository, IHotelReadRepository hotelReadRepository, IRoomReadRepository roomReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
            _hotelReadRepository = hotelReadRepository;
            _roomReadRepository = roomReadRepository;
        }

        public async Task<GetAllAvaibleHotelsQueryResponse> Handle(GetAllAvaibleHotelsQueryRequest request, CancellationToken cancellationToken)
        {// Tarihler arasında örtüşme kontrolü için rezervasyonları al
            List<Domain.Entities.Reservation> reservations = await _reservationReadRepository.GetWhere(r =>
                r.CheckIn <= request.CheckOut &&
                r.CheckOut >= request.CheckIn).ToListAsync(cancellationToken);

            var response = new GetAllAvaibleHotelsQueryResponse
            {
                EmptyRoomIds = new List<string>(), // Boş odaların ID'leri için başlatıyoruz
                AvailableRoomCapacities = new Dictionary<string, int>() // Oda kapasiteleri için başlatıyoruz
            };

            // Eğer hiç rezervasyon yoksa, tüm otelleri göster
            if (!reservations.Any())
            {
                var hotels = await _hotelReadRepository.GetAll().ToListAsync(cancellationToken);
                response.Hotels = hotels;
                response.Success = true;
                response.Message = "Tüm oteller mevcut.";
                return response;
            }

            var reservedHotelIds = reservations.Select(r => r.HotelId).Distinct().ToList(); // Guid türünde ID'ler

            var hotelsWithAvailableRooms = new List<Domain.Entities.Hotel>();
            var hotelsWithoutRooms = new List<Domain.Entities.Hotel>();

            // Rezervasyon yapılmış otellerin ID'lerini al
            var reservedHotels = await _hotelReadRepository.GetAll()
                .Where(h => reservedHotelIds.Contains(h.Id.ToString())) // Guid karşılaştırması
                .ToListAsync(cancellationToken);

            foreach (var hotel in reservedHotels)
            {
                // Otelin odalarını al
                var rooms = await _roomReadRepository.GetWhere(r => r.HotelId == hotel.Id.ToString()).ToListAsync(cancellationToken);

                if (rooms.Any())
                {
                    foreach (var room in rooms)
                    {
                        // Odanın mevcut rezervasyonlarını al
                        var roomReservations = await _reservationReadRepository.GetWhere(r =>
                            r.RoomId == room.Id.ToString() &&
                            r.CheckIn <= request.CheckOut &&
                            r.CheckOut >= request.CheckIn).ToListAsync(cancellationToken);

                        // Odanın kapasitesini al
                        int roomCapacity = room.Capacity;

                        // Kapasitenin ne kadarının dolduğunu hesapla
                        int bookedCapacity = roomReservations.Count(); // Her rezervasyon odanın tamamını kaplıyor varsayılır

                        // Boş kalan kapasiteyi hesapla
                        int availableCapacity = roomCapacity - bookedCapacity;

                        // Eğer oda kapasitesinin kalan kısmı yeterliyse, oteli uygun olarak ekle
                        if (availableCapacity > 0)
                        {
                            if (!hotelsWithAvailableRooms.Contains(hotel))
                            {
                                hotelsWithAvailableRooms.Add(hotel);
                            }

                            // Boş odaların ID'lerini listeye ekle
                            response.EmptyRoomIds.Add(room.Id.ToString());

                            // Kalan kapasiteyi dictionary'ye ekle
                            if (!response.AvailableRoomCapacities.ContainsKey(room.Id.ToString()))
                            {
                                response.AvailableRoomCapacities[room.Id.ToString()] = availableCapacity;
                            }
                        }
                    }
                }
            }

            // Rezervasyonu olmayan otelleri hariç tut
            var allHotels = await _hotelReadRepository.GetAll().ToListAsync(cancellationToken);
            var reservedHotelIdsSet = new HashSet<string>(reservedHotelIds); // Set olarak kullanıyoruz

            // Oda olan otelleri filtreleme
            var hotelsWithRooms = new List<Domain.Entities.Hotel>();
            foreach (var hotel in allHotels)
            {
                var rooms = await _roomReadRepository.GetWhere(r => r.HotelId == hotel.Id.ToString()).ToListAsync(cancellationToken);
                if (rooms.Any())
                {
                    hotelsWithRooms.Add(hotel);
                }
            }

            // Mevcut otellerin üzerine ekleme işlemi
            var allHotelsWithAvailableRooms = hotelsWithRooms
                .Where(h => !reservedHotelIdsSet.Contains(h.Id.ToString())) // Rezervasyon yapılmamış otelleri ekle
                .Concat(hotelsWithAvailableRooms) // Önce boş oda olanları ekle
                .ToList();

            // Sayfalamayı gerçekleştirin ve oda kapasitelerini güncelleyin
            if (request.Size > 0 && request.Page >= 0)
            {
                // Toplam otel sayısını al
                response.TotalCount = allHotelsWithAvailableRooms.Count();

                // Sayfalama işlemi
                var pagedHotels = allHotelsWithAvailableRooms
                    .Skip(request.Page * request.Size) // Sayfayı 0 tabanlı index olarak kullanıyoruz
                    .Take(request.Size)
                    .Select(hotel => new Domain.Entities.Hotel()
                    {
                        Id = hotel.Id,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        Phone = hotel.Phone,
                        Email = hotel.Email,
                        Description = hotel.Description,
                        StarRating = hotel.StarRating,
                        Star = hotel.Star,
                        ImageUrl = hotel.ImageUrl,
                        standartRoomPrice = hotel.standartRoomPrice
                    })
                    .ToList();

                response.Hotels = pagedHotels;

                // Sayfadaki otellerin oda kapasitelerini güncelleyin
                response.AvailableRoomCapacities = response.AvailableRoomCapacities
                    .Where(kv => pagedHotels.Select(h => h.Id.ToString()).Contains(kv.Key))
                    .ToDictionary(kv => kv.Key, kv => kv.Value);
            }

            response.Success = true;
            return response;

        }
    }
}
