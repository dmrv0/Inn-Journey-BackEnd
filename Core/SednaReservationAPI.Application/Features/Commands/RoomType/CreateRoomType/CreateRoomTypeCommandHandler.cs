using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.RoomType.CreateRoomType
{
    public class CreateRoomTypeCommandHandler : IRequestHandler<CreateRoomTypeCommandRequest, CreateRoomTypeCommandResponse>
    {
        readonly IRoomTypeWriteRepository _roomTypeWriteRepository;

        public CreateRoomTypeCommandHandler(IRoomTypeWriteRepository roomTypeWriteRepository)
        {
            _roomTypeWriteRepository = roomTypeWriteRepository;
        }

        public async Task<CreateRoomTypeCommandResponse> Handle(CreateRoomTypeCommandRequest request, CancellationToken cancellationToken)
        {
            await _roomTypeWriteRepository.AddAsync(new Domain.Entities.RoomType
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
            });

            await _roomTypeWriteRepository.SaveAsync();
            return new();
        }
    }
}
