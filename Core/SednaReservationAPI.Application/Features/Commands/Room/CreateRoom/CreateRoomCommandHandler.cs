using Iyzipay.Model;
using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.CreateRoom
{
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommandRequest, CreateRoomCommandResponse>
    {
        readonly IRoomWriteRepository _roomWriteRepository;

        public CreateRoomCommandHandler(IRoomWriteRepository roomWriteRepository, IWriteRepositoryRoomExtensions roomExtensions)
        {
            _roomWriteRepository = roomWriteRepository;

        }

        public async Task<CreateRoomCommandResponse> Handle(CreateRoomCommandRequest request, CancellationToken cancellationToken)
        {
            var room = new Domain.Entities.Room
            {   
                HotelId = request.HotelId,
                RoomTypeId = request.RoomTypeId,
                AdultPrice = request.AdultPrice,
                ChildPrice = request.ChildPrice,
                Status = request.Status,
                Capacity = request.Capacity
            };
                await _roomWriteRepository.AddAsync(room);
            try

            {
                await _roomWriteRepository.SaveAsync();
            }
            catch (Exception err)
            {
                throw err;
            }

            return new CreateRoomCommandResponse
            {
                roomId = room.Id.ToString() // Oda ID'sini döndürün
            };
        }
    }
}
