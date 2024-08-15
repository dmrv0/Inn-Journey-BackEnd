using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.Room.CreateRoom;
using SednaReservationAPI.Application.Features.Commands.Room.DeleteRoom;
using SednaReservationAPI.Application.Features.Commands.Room.UpdateRoom;
using SednaReservationAPI.Application.Features.Queries.Room.GetAllRoom;
using SednaReservationAPI.Application.Features.Queries.Room.GetByIdRoom;
using SednaReservationAPI.Application.Features.Queries.Room.GetRoomByHotelId;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomReadRepository _roomReadRepository;
        private readonly IRoomWriteRepository _roomWriteRepository;
        private readonly IMediator _mediator;

        public RoomsController(IRoomReadRepository roomReadRepository, IRoomWriteRepository roomWriteRepository, IMediator mediator)
        {
            _roomReadRepository = roomReadRepository;
            _roomWriteRepository = roomWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> getRoom([FromQuery] GetAllRoomQueryRequest getAllRoomQueryRequest)
        {
            List<GetAllRoomQueryResponse> response = await _mediator.Send(getAllRoomQueryRequest);
            return Ok(response);

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> getRoomById([FromRoute] GetByIdRoomQueryRequest getByIdRoomQueryRequest)
        {
            GetByIdRoomQueryResponse response = await _mediator.Send(getByIdRoomQueryRequest);
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> addRoom(CreateRoomCommandRequest createRoomCommandRequest)
        {
            CreateRoomCommandResponse response = await _mediator.Send(createRoomCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteRoom([FromRoute] DeleteRoomCommandRequest deleteRoomCommandRequest)
        {
            DeleteRoomCommandResponse response = await _mediator.Send(deleteRoomCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> updateRoom([FromBody] UpdateRoomCommandRequest updateRoomCommandRequest)
        {
            UpdateRoomCommandResponse response = await _mediator.Send(updateRoomCommandRequest);
            return Ok(response);
        }
        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> getRoomByHotel([FromRoute] GetRoomByHotelIdQueryRequest getRoomByHotelIdQueryRequest)
        {
            List<GetRoomByHotelIdQueryResponse> response = await _mediator.Send(getRoomByHotelIdQueryRequest);
            return Ok(response);
        }
    }
}
