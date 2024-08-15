using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.DTOs.User;
using SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser;
using SednaReservationAPI.Application.Features.Commands.AppUser.LoginUser;
using SednaReservationAPI.Application.Features.Commands.AppUser.UpdateAppUser;
using SednaReservationAPI.Application.Features.Queries.AppUser.GetAllUser;
using SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdsUser;
using SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdUser;
using SednaReservationAPI.Application.Features.Queries.Hotel.GetByIdsHotel;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse createUserCommandResponse = await _mediator.Send(createUserCommandRequest);
            return Ok(createUserCommandResponse);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUser([FromQuery]GetAllUserQueryRequest getAllUserQueryRequest)
        {
            List<GetAllUserQueryResponse> getAllUserQueryResponse= await _mediator.Send(getAllUserQueryRequest);

            return Ok(getAllUserQueryResponse);
        }
        [HttpGet("ById/{Id}")]
        public async Task<IActionResult> getUserById([FromRoute]GetByIdUserQueryRequest getByIdUserQueryRequest)
        {
            GetByIdUserQueryResponse response = await _mediator.Send(getByIdUserQueryRequest);

            if (response == null) {

                return NotFound();
            }
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> updateUser([FromBody]UpdateAppUserCommandRequest updateUserCommandRequest)
        {
            UpdateAppUserCommandResponse response = await _mediator.Send(updateUserCommandRequest);

            if (response == null) {
                return BadRequest();
            }
            return Ok(response);

        }
        [HttpPost("GetByIds")]
        public async Task<IActionResult> getUserByIds([FromBody]GetByIdsUserQueryRequest getByIdsUserQueryRequest)
        {
            GetByIdsUserQueryResponse response = await _mediator.Send(getByIdsUserQueryRequest);

            return Ok(response);

        }
    }
}
