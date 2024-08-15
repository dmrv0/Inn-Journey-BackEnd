using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetAllReservation
{
    public class GetAllReservationQueryHandler : IRequestHandler<GetAllReservationQueryRequest, List<GetAllReservationQueryResponse>>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetAllReservationQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }

        public Task<List<GetAllReservationQueryResponse>> Handle(GetAllReservationQueryRequest request, CancellationToken cancellationToken)
        {
            var reservation = _reservationReadRepository.GetAll(false)
              .Select(r => new GetAllReservationQueryResponse
              {
                  Id = r.Id.ToString(),
                  UserId = r.UserId,
                  RoomId = r.RoomId,
                  HotelId = r.HotelId,
                  CheckIn = r.CheckIn,
                  CheckOut = r.CheckOut,
                  TotalPrice = r.TotalPrice,
                  Status = r.Status,
                  Deleted = r.Deleted
              })
              .ToList();



            return Task.FromResult(reservation);
        }
    }
}
