using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.RoomType.GetByIdRoomType
{
    public class GetByIdRoomTypeQueryHandler : IRequestHandler<GetByIdRoomTypeQueryRequest, GetByIdRoomTypeQueryResponse>
    {
        readonly IRoomTypeReadRepository _roomTypeReadRepository;

        public GetByIdRoomTypeQueryHandler(IRoomTypeReadRepository roomTypeReadRepository)
        {
            _roomTypeReadRepository = roomTypeReadRepository;
        }
        public async Task<GetByIdRoomTypeQueryResponse> Handle(GetByIdRoomTypeQueryRequest request, CancellationToken cancellationToken)
        {
            var roomType = await _roomTypeReadRepository.GetByIdAsync(request.Id, false);
            var response = new GetByIdRoomTypeQueryResponse
            {
                Id = roomType.Id.ToString(),
                Name = roomType.Name,
                Description = roomType.Description,
                ImageUrl = roomType.ImageUrl
            };
            return response;
        }
    }
}
