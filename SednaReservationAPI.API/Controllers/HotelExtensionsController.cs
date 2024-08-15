using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.HotelExtensions.Create;
using SednaReservationAPI.Application.Features.Commands.HotelExtensions.Update;
using SednaReservationAPI.Application.Features.Commands.RoomExtension;
using SednaReservationAPI.Application.Features.Queries.HotelExtensions.GetHotelExtensionsByHotelId;
using SednaReservationAPI.Application.Features.Queries.RoomExtensions.GetRoomExtensionsByRoomId;
using SednaReservationAPI.Application.Repositories.RoomEntensions;
using SednaReservationAPI.Application.Repositories.RoomExtensions;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelExtensionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        //private readonly IWriteRepositoryRoomExtensions _writeRepositoryRoomExtensions;
        //private readonly IReadRepositoryRoomExtensions _readRepositoryRoomExtensions;


        public HotelExtensionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddHotelExtension(CreateHotelExtensionCommandRequest createHotelExtensionCommandRequest)
        {
            CreateHotelExtensionCommandResponse response = await _mediator.Send(createHotelExtensionCommandRequest);
            return Ok(response);
        }

        [HttpGet("{hotelId}")]
        public async Task<IActionResult> geHotelExtensions([FromRoute] GetHotelExtensionsByHotelIdQueryRequest getHotelExtensionsByHotelIdQueryRequest)
        {
            List<GetHotelExtensionsByHotelIdQueryResponse> response= await _mediator.Send(getHotelExtensionsByHotelIdQueryRequest);
            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> updateRoomExtensions(UpdateHotelExtensionCommandRequest updateHotelExtensionCommandRequest)
        {
            UpdateHotelExtensionCommandResponse response = await _mediator.Send(updateHotelExtensionCommandRequest);
            return Ok(response);
        }
    }
}
