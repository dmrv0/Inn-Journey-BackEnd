using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create;
using SednaReservationAPI.Application.Features.Commands.RoomExtension;
using SednaReservationAPI.Application.Features.Queries.RoomExtensions.GetRoomExtensionsByRoomId;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomExtensionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IWriteRepositoryRoomExtensions _writeRepositoryRoomExtensions;
        //private readonly IReadRepositoryRoomExtensions _readRepositoryRoomExtensions;


        public RoomExtensionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddRoomExtension(UpdateRoomExtensionCommandRequest createRoomExtensionCommandRequest)
        {
            UpdateRoomExtensionCommandResponse response = await _mediator.Send(createRoomExtensionCommandRequest);
            return Ok(response);
        }

        [HttpGet("{roomId}")]
        public async Task<IActionResult> getRoomExtensions([FromRoute] GetRoomExtensionsByRoomIdQueryRequest getRoomExtensionsByRoomIdQueryRequest)
        {
            List<GetRoomExtensionsByRoomIdQueryResponse> response= await _mediator.Send(getRoomExtensionsByRoomIdQueryRequest);
            return Ok(response);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> updateRoomExtensions(UpdateRoomExtensionCommandRequest updateRoomExtensionCommandRequest)
        {
            UpdateRoomExtensionCommandResponse response = await _mediator.Send(updateRoomExtensionCommandRequest);
            return Ok(response);
        }
    }
}
