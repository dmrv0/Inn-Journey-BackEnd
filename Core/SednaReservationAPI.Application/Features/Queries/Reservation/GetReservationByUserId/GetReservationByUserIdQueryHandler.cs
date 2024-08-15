using MediatR;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByUserId
{
    public class GetReservationByUserIdQueryHandler : IRequestHandler<GetReservationByUserIdQueryRequest, List<GetReservationByUserIdQueryResponse>>
    {
        readonly IReservationReadRepository _reservationReadRepository;

        public GetReservationByUserIdQueryHandler(IReservationReadRepository reservationReadRepository)
        {
            _reservationReadRepository = reservationReadRepository;
        }
        public async Task<List<GetReservationByUserIdQueryResponse>> Handle(GetReservationByUserIdQueryRequest request, CancellationToken cancellationToken)


        {
        
            var totalCount = _reservationReadRepository.GetWhere(r => r.UserId == request.userId).Count();


            var reservationQuery = _reservationReadRepository.GetWhere(r => r.UserId == request.userId);


            var reservation = reservationQuery
                .OrderByDescending(p => p.CreatedDate) // En son eklenenleri önce al
                .Skip(request.Page.Value * request.Size.Value)
                .Take(request.Size.Value)
                .Select(rezer => new GetReservationByUserIdQueryResponse
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
                 TotalCount = totalCount,
             }).ToList();
            return await Task.FromResult(reservation);
        }
    }
}
