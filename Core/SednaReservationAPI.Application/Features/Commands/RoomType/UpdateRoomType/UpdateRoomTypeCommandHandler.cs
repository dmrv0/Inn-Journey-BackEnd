using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomType.UpdateRoomType
{
    public class UpdateRoomTypeCommandHandler : IRequestHandler<UpdateRoomTypeCommandRequest, UpdateRoomTypeCommandResponse>
    {
        readonly IRoomTypeReadRepository _roomTypeReadRepository;
        readonly IRoomTypeWriteRepository _roomTypeWriteRepository;

        public UpdateRoomTypeCommandHandler(IRoomTypeReadRepository roomTypeReadRepository, IRoomTypeWriteRepository roomTypeWriteRepository)
        {
            _roomTypeReadRepository = roomTypeReadRepository;
            _roomTypeWriteRepository = roomTypeWriteRepository;
        }

        public async Task<UpdateRoomTypeCommandResponse> Handle(UpdateRoomTypeCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.RoomType roomType = await _roomTypeReadRepository.GetByIdAsync(request.Id);

            roomType.Name = request.Name;
            roomType.Description = request.Description;
            roomType.ImageUrl = request.ImageUrl;
            roomType.UpdatedDate = DateTime.UtcNow;

            await _roomTypeWriteRepository.SaveAsync();
            return new();
        }
    }
}
