using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation
{

    // Hotel Rezervasyonları görüntüleme

    public class GetHotelByIdReservationQueryHandler : IRequestHandler<GetHotelByIdReservationQueryRequest, GetHotelByIdReservationQueryResponse>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetHotelByIdReservationQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<GetHotelByIdReservationQueryResponse>Handle(GetHotelByIdReservationQueryRequest request, CancellationToken cancellationToken)
        {

            var rezervation = _reservationReadRepository.GetWhere(r => r.HotelId == request.hotelId)
                .OrderByDescending(p => p.CreatedDate) // En son eklenenleri önce al
                .Skip(request.Page * request.Size)
                .Take(request.Size).ToList();
              
            var TotalCount=_reservationReadRepository.GetWhere(r => r.HotelId == request.hotelId).Count();
            return new GetHotelByIdReservationQueryResponse() { rezervations = rezervation , TotalCount = TotalCount };
           


        }
    }
}
