using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.RoomType.GetAllRoomType
{
    public class GetAllRoomTypesQueryHandler : IRequestHandler<GetAllRoomTypesQueryRequest, List<GetAllRoomTypesQueryResponse>>
    {
        readonly IRoomTypeReadRepository _roomTypeReadRepository;

        public GetAllRoomTypesQueryHandler(IRoomTypeReadRepository roomTypeReadRepository)
        {
            _roomTypeReadRepository = roomTypeReadRepository;
        }

        public Task<List<GetAllRoomTypesQueryResponse>> Handle(GetAllRoomTypesQueryRequest request, CancellationToken cancellationToken)
        {
            var roomType = _roomTypeReadRepository.GetAll(false).Select(roomType => new GetAllRoomTypesQueryResponse
            {
                Id = roomType.Id.ToString(),
                Name = roomType.Name,
                Description = roomType.Description,
                ImageUrl = roomType.ImageUrl

            }).ToList();
            return Task.FromResult(roomType);
        }
    }
}
