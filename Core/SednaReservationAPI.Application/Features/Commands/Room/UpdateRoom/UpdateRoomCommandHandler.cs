using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.UpdateRoom
{
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommandRequest, UpdateRoomCommandResponse>
    {
        readonly IRoomReadRepository _roomReadRepository;
        readonly IRoomWriteRepository _roomWriteRepository;

        public UpdateRoomCommandHandler(IRoomReadRepository roomReadRepository, IRoomWriteRepository roomWriteRepository)
        {
            _roomReadRepository = roomReadRepository;
            _roomWriteRepository = roomWriteRepository;
        }

        public async Task<UpdateRoomCommandResponse> Handle(UpdateRoomCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Room room = await _roomReadRepository.GetByIdAsync(request.Id);
            room.HotelId = request.HotelId;
            room.RoomTypeId = request.RoomTypeId;
            room.AdultPrice = request.AdultPrice;
            room.ChildPrice = request.ChildPrice;
            room.Status = request.Status;
            room.Capacity = request.Capacity;

            await _roomWriteRepository.SaveAsync();
            return new();
        }
    }
}
