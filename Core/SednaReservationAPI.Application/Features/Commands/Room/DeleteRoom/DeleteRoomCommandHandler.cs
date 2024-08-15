using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.DeleteRoom
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommandRequest, DeleteRoomCommandResponse>
    {
        readonly IRoomWriteRepository _roomWriteRepository;

        public DeleteRoomCommandHandler(IRoomWriteRepository roomWriteRepository)
        {
            _roomWriteRepository = roomWriteRepository;
        }

        public async Task<DeleteRoomCommandResponse> Handle(DeleteRoomCommandRequest request, CancellationToken cancellationToken)
        {
            await _roomWriteRepository.RemoveAsync(request.Id);
            await _roomWriteRepository.SaveAsync();
            return new();
        }
    }
}
