using Iyzipay.Model;
using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SednaReservationAPI.Application.Features.Commands.Hotel.CreateHotel
{
    public class CreateHotelCommandHandler : IRequestHandler<CreateHotelCommandRequest, CreateHotelCommandResponse>
    {
        readonly IHotelWriteRepository _hotelWriteRepository;
        readonly IRoomWriteRepository _roomWriteRepository;
        readonly IRoomTypeReadRepository _roomTypeReadRepory;


        public CreateHotelCommandHandler(IHotelWriteRepository hotelWriteRepository, IRoomWriteRepository roomWriteRepository, IRoomTypeReadRepository roomTypeReadRepory)
        {
            _hotelWriteRepository = hotelWriteRepository;
            _roomWriteRepository = roomWriteRepository;
            _roomTypeReadRepory = roomTypeReadRepory;
        }

        public async Task<CreateHotelCommandResponse> Handle(CreateHotelCommandRequest request, CancellationToken cancellationToken)
        {

            var hotel = new Domain.Entities.Hotel
            {
                userId = request.userId,
                Name = request.Name,
                Address = request.Address,
                Phone = request.Phone,
                Email = request.Email,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                Star = request.Star,
                googleMap = request.googleMap,
                standartRoomPrice = request.standartRoomPrice,
            };

            await _hotelWriteRepository.AddAsync(hotel);
            await _hotelWriteRepository.SaveAsync();

            var standardRoomTypeId = _roomTypeReadRepory.GetAll().FirstOrDefault(rt => rt.Name == "Standart Oda")?.Id;

            if (standardRoomTypeId == null)
            {
                throw new Exception("Standart oda türü bulunamadı.");
            }

            await _roomWriteRepository.AddAsync(new Domain.Entities.Room()
            {
                HotelId = hotel.Id.ToString(),
                RoomTypeId = standardRoomTypeId.Value.ToString(),
                AdultPrice = request.standartRoomPrice,
                ChildPrice = request.standartRoomPrice,
            });

            try
            {
                await _roomWriteRepository.SaveAsync();

            }
            catch (Exception err)
            {

                throw new Exception("Bir hata oluştu");
            }

            return new CreateHotelCommandResponse()
            {
                hotelId = hotel.Id.ToString(),
                Success = true,
                Message = "Oteliniz başarıyla eklendi. Otomatik olarak standart odanız oluşturulmuştur."
            };
        }
    }
}
