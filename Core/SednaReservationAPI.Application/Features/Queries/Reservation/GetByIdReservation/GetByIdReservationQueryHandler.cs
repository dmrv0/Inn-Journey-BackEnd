using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetByIdReservation
{
    public class GetByIdReservationQueryHandler : IRequestHandler<GetByIdReservationQueryRequest, GetByIdReservationQueryResponse>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetByIdReservationQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }
        public async Task<GetByIdReservationQueryResponse> Handle(GetByIdReservationQueryRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Reservation reservation = await _reservationReadRepository.GetByIdAsync(request.Id, false);

            var response = new GetByIdReservationQueryResponse
            {
                Id = reservation.Id.ToString(),
                UserId = reservation.UserId,
                RoomId = reservation.RoomId,
                HotelId = reservation.HotelId,
                CheckIn = reservation.CheckIn,
                CheckOut = reservation.CheckOut,
                TotalPrice = reservation.TotalPrice,
                Status = reservation.Status,
                Deleted = reservation.Deleted,
            };

            return response;
        }
    }
}
