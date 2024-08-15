using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.RoomType.CreateRoomType;
using SednaReservationAPI.Application.Features.Commands.RoomType.DeleteRoomType;
using SednaReservationAPI.Application.Features.Commands.RoomType.UpdateRoomType;
using SednaReservationAPI.Application.Features.Queries.RoomType.GetAllRoomType;
using SednaReservationAPI.Application.Features.Queries.RoomType.GetByIdRoomType;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypesController : ControllerBase
    {
        private readonly IRoomTypeReadRepository _roomTypeReadRepository;
        private readonly IRoomTypeWriteRepository _roomTypeWriteRepository;
        private readonly IMediator _mediator;

        public RoomTypesController(IRoomTypeReadRepository roomTypeReadRepository, IRoomTypeWriteRepository roomTypeWriteRepository, IMediator mediator)
        {
            _roomTypeReadRepository = roomTypeReadRepository;
            _roomTypeWriteRepository = roomTypeWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllRoomTypesQueryRequest getAllRoomTypesQueryRequest)
        {
            List<GetAllRoomTypesQueryResponse> response = await _mediator.Send(getAllRoomTypesQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdRoomTypeQueryRequest getByIdRoomTypeQueryRequest)
        {
            GetByIdRoomTypeQueryResponse response = await _mediator.Send(getByIdRoomTypeQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> addRoomType(CreateRoomTypeCommandRequest createRoomTypeCommandRequest)
        {
            CreateRoomTypeCommandResponse response = await _mediator.Send(createRoomTypeCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteRoomType([FromRoute] DeleteRoomTypeCommandRequest deleteRoomTypeCommandRequest)
        {
            DeleteRoomTypeCommandResponse response = await _mediator.Send(deleteRoomTypeCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> updateRoom([FromBody] UpdateRoomTypeCommandRequest updateRoomTypeCommandRequest)
        {
            UpdateRoomTypeCommandResponse response = await _mediator.Send(updateRoomTypeCommandRequest);
            return Ok(response);
        }
    }
}
