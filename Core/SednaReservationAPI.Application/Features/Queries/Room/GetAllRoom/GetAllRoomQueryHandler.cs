using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Room.GetAllRoom
{
    public class GetAllRoomQueryHandler : IRequestHandler<GetAllRoomQueryRequest, List<GetAllRoomQueryResponse>>
    {
        readonly IRoomReadRepository _roomReadRepository;

        public GetAllRoomQueryHandler(IRoomReadRepository roomReadRepository)
        {
            _roomReadRepository = roomReadRepository;
        }
        public Task<List<GetAllRoomQueryResponse>> Handle(GetAllRoomQueryRequest request, CancellationToken cancellationToken)
        {
            var room = _roomReadRepository.GetAll(false).Select(room => new GetAllRoomQueryResponse
            {
                Id = room.Id.ToString(),
                HotelId = room.HotelId,
                RoomTypeId = room.RoomTypeId,
                AdultPrice = room.AdultPrice,
                ChildPrice = room.ChildPrice,
                Capacity= room.Capacity,
                Status = room.Status

            }).ToList();
            return Task.FromResult(room);
        }
    }
}
