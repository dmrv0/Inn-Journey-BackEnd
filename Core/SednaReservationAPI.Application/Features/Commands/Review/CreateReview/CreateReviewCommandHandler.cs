using MediatR;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.CreateReview
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommandRequest, CreateReviewCommandResponse>
    {
        readonly IReviewWriteRepository _reviewWriteRepository;
        readonly IReviewReadRepository _reviewReadRepository;
        readonly IHotelWriteRepository _hotelWriteRepository;
        readonly IHotelReadRepository _hotelReadRepository;
        public CreateReviewCommandHandler(IReviewWriteRepository reviewWriteRepository, IHotelWriteRepository hotelWriteRepository, IReviewReadRepository reviewReadRepository, IHotelReadRepository hotelReadRepository)
        {
            _reviewWriteRepository = reviewWriteRepository;
            _hotelWriteRepository = hotelWriteRepository;
            _reviewReadRepository = reviewReadRepository;
            _hotelReadRepository = hotelReadRepository;
        }
        public async Task<CreateReviewCommandResponse> Handle(CreateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Yeni bir inceleme ekleyin
                await _reviewWriteRepository.AddAsync(new Domain.Entities.Review
                {
                    HotelId = request.HotelId,
                    UserId = request.UserId,
                    Rating = request.Rating,
                    Comment = request.Comment,
                });
                await _reviewWriteRepository.SaveAsync();

                // Otele ait tüm incelemeleri alın
                var reviews = await _reviewReadRepository.GetWhere(i => i.HotelId == request.HotelId)
                    .ToListAsync(cancellationToken);

                // Ortalama puanı hesaplayın
                float rating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

                // Otel nesnesini güncelleyin
                Domain.Entities.Hotel hotel = await _hotelReadRepository.GetByIdAsync(request.HotelId);
                if (hotel != null)
                {
                    hotel.StarRating = rating;
                    await _hotelWriteRepository.SaveAsync();
                }
                else
                {
                    throw new InvalidOperationException("Belirtilen otel bulunamadı.");
                }

                return new CreateReviewCommandResponse();
            }
            catch (DbUpdateException ex)
            {
                // Veritabanı güncelleme hatası
                throw new Exception("Veritabanı güncelleme hatası", ex);
            }
            catch (InvalidOperationException ex)
            {
                // Geçersiz işlem hatası
                throw new Exception("Geçersiz işlem", ex);
            }
            catch (Exception ex)
            {
                // Diğer tüm hatalar
                throw new Exception("İşlem sırasında hata oluştu", ex);
            }
        }
    }
}
