using MediatR;
using SednaReservationAPI.Application.Features.Queries.Review.GetReviewHotelById;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Room.GetRoomByHotelId
{
    public class GetRoomByHotelIdQueryHandler : IRequestHandler<GetRoomByHotelIdQueryRequest, List<GetRoomByHotelIdQueryResponse>>
    {
        readonly IRoomReadRepository _roomReadRepository;

        public GetRoomByHotelIdQueryHandler(IRoomReadRepository roomReadRepository)
        {
            _roomReadRepository = roomReadRepository;
        }

        public async Task<List<GetRoomByHotelIdQueryResponse>> Handle(GetRoomByHotelIdQueryRequest request, CancellationToken cancellation)
        {
            var room = _roomReadRepository.GetWhere(r => r.HotelId == request.HotelId).Select(rev => new GetRoomByHotelIdQueryResponse
            {
                Id = rev.Id.ToString(),
                HotelId = rev.HotelId,
                RoomTypeId = rev.RoomTypeId,
                AdultPrice = rev.AdultPrice,
                ChildPrice = rev.ChildPrice,
                Capacity = rev.Capacity,
                Status = rev.Status,
            }).ToList();

            return await Task.FromResult(room);

        }
    }
}
