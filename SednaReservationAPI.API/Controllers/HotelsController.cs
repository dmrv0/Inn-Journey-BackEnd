using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Consts;
using SednaReservationAPI.Application.CustomAttributes;
using SednaReservationAPI.Application.Enum;
using SednaReservationAPI.Application.Features.Commands.Hotel.CreateHotel;
using SednaReservationAPI.Application.Features.Commands.Hotel.DeleteHotel;
using SednaReservationAPI.Application.Features.Commands.Hotel.UpdateHotel;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetAllAvaibleHotels;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetAllHotel;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdHotel;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdsHotel;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetUserByIdHotel;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelReadRepository _hotelReadRepository;
        private readonly IHotelWriteRepository _hotelWriteRepository;
        private readonly IMediator _mediator;

        public HotelsController(IHotelReadRepository hotelReadRepository, IHotelWriteRepository hotelWriteRepository, IMediator mediator)
        {
            _hotelReadRepository = hotelReadRepository;
            _hotelWriteRepository = hotelWriteRepository;
            _mediator = mediator;
        }
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme) ]

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Hotels, ActionType = ActionType.Reading, Definition = "Get Hotels")]
        public async Task<IActionResult> Get([FromQuery] GetAllHotelQueryRequest getAllHotelQueryRequest)
        {
            List<GetAllHotelQueryResponse> response = await _mediator.Send(getAllHotelQueryRequest);
            return Ok(response);
        }
        [HttpGet("{id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Hotels, ActionType = ActionType.Reading, Definition = "Get Hotels ById")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdHotelQueryRequest getByIdHotelQueryRequest)
        {
            GetByIdHotelQueryResponse response = await _mediator.Send(getByIdHotelQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Hotels, ActionType = ActionType.Reading, Definition = "Add Hotels")]
        public async Task<IActionResult> Add(CreateHotelCommandRequest createHotelCommandRequest)
        {
            CreateHotelCommandResponse response = await _mediator.Send(createHotelCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Hotels, ActionType = ActionType.Reading, Definition = "Delete Hotels")]
        public async Task<IActionResult> DeleteAsync([FromRoute] DeleteHotelCommandRequest deleteHotelCommandRequest)
        {

            DeleteHotelCommandResponse response = await _mediator.Send(deleteHotelCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Hotels, ActionType = ActionType.Reading, Definition = "Put Hotels")]
        public async Task<IActionResult> Update([FromBody] UpdateHotelCommandRequest updateHotelCommandRequest)
        {
            UpdateHotelCommandResponse response = await _mediator.Send(updateHotelCommandRequest);
            return Ok(response);
        }

        [HttpGet("myHotels/{userId}")]
        public async Task<IActionResult> getMyHotels([FromRoute] GetByAdminAllHotelQueryRequest getByAdminAllHotelQueryRequest)
        {
            List<GetByAdminAllHotelQueryResponse> response = await _mediator.Send(getByAdminAllHotelQueryRequest);
            return Ok(response);

        }

        [HttpGet("AvaibleHotels")]
        public async Task<IActionResult> getAvaibleHotels([FromQuery]GetAllAvaibleHotelsQueryRequest getAllAvaibleHotelsQueryRequest)
        {
            GetAllAvaibleHotelsQueryResponse response = await _mediator.Send(getAllAvaibleHotelsQueryRequest);
            return Ok(response);
        }
        [HttpPost("GetHotelName")]
        public async Task<IActionResult> getHotelsName([FromBody]GetByIdsHotelQueryRequest getByIdsHotelQueryRequest)
        {
            GetByIdsHotelQueryResponse response = await _mediator.Send(getByIdsHotelQueryRequest);
            return Ok(response);
        }
    }
}
