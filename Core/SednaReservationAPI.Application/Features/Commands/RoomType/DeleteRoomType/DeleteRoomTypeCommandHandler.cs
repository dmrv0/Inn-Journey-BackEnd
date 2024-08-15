using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomType.DeleteRoomType
{
    public class DeleteRoomTypeCommandHandler : IRequestHandler<DeleteRoomTypeCommandRequest, DeleteRoomTypeCommandResponse>
    {
        readonly IRoomTypeWriteRepository _roomTypeWriteRepository;

        public DeleteRoomTypeCommandHandler(IRoomTypeWriteRepository roomTypeWriteRepository)
        {
            _roomTypeWriteRepository = roomTypeWriteRepository;
        }

        public async Task<DeleteRoomTypeCommandResponse> Handle(DeleteRoomTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _roomTypeWriteRepository.RemoveAsync(request.Id);
            await _roomTypeWriteRepository.SaveAsync();
            return new();
        }
    }
}
