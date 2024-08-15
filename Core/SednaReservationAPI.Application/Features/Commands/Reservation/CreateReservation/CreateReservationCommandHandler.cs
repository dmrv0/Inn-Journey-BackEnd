using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Reservation.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommandRequest, CreateReservationCommandResponse>
    {
        readonly IReservationWriteRepository _reservationWriteRepository;
        readonly IReservationReadRepository _reservationReadRepository;
        readonly IRoomReadRepository _roomReadRepository;

        public CreateReservationCommandHandler(IReservationWriteRepository reservationWriteRepository, IReservationReadRepository reservationReadRepository, IRoomReadRepository roomReadRepository)
        {
            _reservationWriteRepository = reservationWriteRepository;
            _reservationReadRepository = reservationReadRepository;
             _roomReadRepository = roomReadRepository;
        }

        public async Task<CreateReservationCommandResponse> Handle(CreateReservationCommandRequest request, CancellationToken cancellationToken)
        {
            var res = new Domain.Entities.Reservation
            {
                UserId = request.UserId,
                RoomId = request.RoomId,
                HotelId = request.HotelId,
                CheckIn = request.CheckIn,
                CheckOut = request.CheckOut,
                TotalPrice = request.TotalPrice,
                Status = request.Status
            };

            var model = _reservationReadRepository.GetWhere(r => r.RoomId == request.RoomId &&
                    ((r.CheckIn <= request.CheckOut && r.CheckOut >= request.CheckIn))).ToList(); // Tarihler arasında örtüşme kontrolü


            Domain.Entities.Room room = await _roomReadRepository.GetByIdAsync(request.RoomId);
          

            if (model.Count <= room.Capacity)
            {
                await _reservationWriteRepository.AddAsync(res);

                await _reservationWriteRepository.SaveAsync();

                return new()
                {
                    Id = res.Id.ToString(),
                    Success = true,
                    Message = "Randevu başarıyla oluşturuldu."
                };
            }


            else if (model.Count > room.Capacity)
            {

                return new() {
                    Success = false,
                    Message = "Bu tarihler arasında hiç boş odamız yok" };
            }

            else
            {
              
                return new() { Success = false, Message = "Bir hata oluştu!" };
            }
        }
    }
}
