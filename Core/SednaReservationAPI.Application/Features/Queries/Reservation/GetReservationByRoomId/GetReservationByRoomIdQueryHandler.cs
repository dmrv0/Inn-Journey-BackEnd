using MediatR;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByUserId;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByRoomId
{
    public class GetReservationByRoomIdQueryHandler :IRequestHandler<GetReservationByRoomIdQueryRequest, List<GetReservationByRoomIdQueryResponse>>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetReservationByRoomIdQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public async Task<List<GetReservationByRoomIdQueryResponse>> Handle(GetReservationByRoomIdQueryRequest request, CancellationToken cancellationToken)
        {
            var rezervation = _reservationReadRepository
                .GetWhere(r => r.RoomId == request.roomId)
                .OrderByDescending(p => p.CreatedDate) // En son eklenenleri önce al
                .Select(rezer => new GetReservationByRoomIdQueryResponse
            {
                Id = rezer.Id.ToString(),
                UserId = rezer.UserId,
                HotelId = rezer.HotelId,
                RoomId = rezer.RoomId,
                CheckIn = rezer.CheckIn,
                CheckOut = rezer.CheckOut,
                TotalPrice = rezer.TotalPrice,
                Status = rezer.Status,
                Deleted = rezer.Deleted,
            }).ToList();

            return await Task.FromResult(rezervation);
        }
    }
}
