using MediatR;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Room.CreateRoom
{
    public class CreateRoomCommandRequest : IRequest<CreateRoomCommandResponse>
    {   public string? HotelId { get; set; }
        public string? RoomTypeId { get; set; }
        public decimal? AdultPrice { get; set; }
        public decimal? ChildPrice { get; set; }
        public string? Status { get; set; }
        public int Capacity { get; set; }
    }
}
