using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.Customer.CreateCustomer;
using SednaReservationAPI.Application.Features.Commands.Customer.DeleteCustomer;
using SednaReservationAPI.Application.Features.Commands.Customer.UpdateCustomer;
using SednaReservationAPI.Application.Features.Commands.RoomType.CreateRoomType;
using SednaReservationAPI.Application.Features.Commands.RoomType.DeleteRoomType;
using SednaReservationAPI.Application.Features.Commands.RoomType.UpdateRoomType;
using SednaReservationAPI.Application.Features.Queries.Customer.GetAllCustomer;
using SednaReservationAPI.Application.Features.Queries.Customer.GetByIdCustomer;
using SednaReservationAPI.Application.Features.Queries.RoomType.GetAllRoomType;
using SednaReservationAPI.Application.Features.Queries.RoomType.GetByIdRoomType;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerReadRepository _customerReadRepository;
        private readonly ICustomerWriteRepository _customerWriteRepository;
        private readonly IMediator _mediator;

        public CustomersController(ICustomerReadRepository customerReadRepository, ICustomerWriteRepository customerWriteRepository, IMediator mediator)
        {
            _customerReadRepository = customerReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllCustomerQueryRequest getAllCustomerQueryRequest)
        {
            List<GetAllCustomerQueryResponse> response = await _mediator.Send(getAllCustomerQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCustomerQueryRequest getByIdCustomerQueryRequest)
        {
            GetByIdCustomerQueryResponse response = await _mediator.Send(getByIdCustomerQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> addRoomType(CreateCustomerCommandRequest createCustomerCommandRequest)
        {
            CreateCustomerCommandResponse response = await _mediator.Send(createCustomerCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteRoomType([FromRoute] DeleteCustomerCommandRequest deleteCustomerCommandRequest)
        {
            DeleteCustomerCommandResponse response = await _mediator.Send(deleteCustomerCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> updateRoom([FromBody] UpdateCustomerCommandRequest updateCustomerCommandRequest)
        {
            UpdateCustomerCommandResponse response = await _mediator.Send(updateCustomerCommandRequest);
            return Ok(response);
        }
    }
}
