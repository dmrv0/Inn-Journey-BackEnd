using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.Reservation.CreateReservation;
using SednaReservationAPI.Application.Features.Commands.Reservation.DeleteReservation;
using SednaReservationAPI.Application.Features.Commands.Reservation.UpdateReservation;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetAllReservation;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetByIdReservation;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetHotelByIdReservation;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByRoomId;
using SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByUserId;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationReadRepository _reservationReadRepository;
        private readonly IReservationWriteRepository _reservationWriteRepository;
        private readonly IMediator _mediator;

        public ReservationsController(IReservationReadRepository reservationReadRepository, IReservationWriteRepository reservationWriteRepository, IMediator mediator)
        {
            _reservationReadRepository = reservationReadRepository;
            _reservationWriteRepository = reservationWriteRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllReservationQueryRequest getAllReservationQueryRequest)
        {
            List<GetAllReservationQueryResponse> response = await _mediator.Send(getAllReservationQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdReservationQueryRequest getByIdReservationQueryRequest)
        {

            GetByIdReservationQueryResponse response = await _mediator.Send(getByIdReservationQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> addReservation(CreateReservationCommandRequest createReservationCommandRequest)
        {
            CreateReservationCommandResponse response = await _mediator.Send(createReservationCommandRequest);
                return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteReservation([FromRoute] DeleteReservationCommandRequest deleteReservationCommandRequest)
        {
            DeleteReservationCommandResponse response = await _mediator.Send(deleteReservationCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> updateReservation([FromBody] UpdateReservationCommandRequest updateReservationCommandRequest)
        {
            UpdateReservationCommandResponse response = await _mediator.Send(updateReservationCommandRequest);
            return Ok(response);
        }
        [HttpGet("hotel/")]
        public async Task<IActionResult> getHotelByReservations([FromQuery] GetHotelByIdReservationQueryRequest getHotelByIdReservationQueryRequest)
        {
            GetHotelByIdReservationQueryResponse response = await _mediator.Send(getHotelByIdReservationQueryRequest);
            return Ok(response);
        }
        [HttpGet("user")]       
        public async Task<IActionResult> getReservationByUserId([FromQuery] GetReservationByUserIdQueryRequest getReservationByUserIdQueryRequest)
        {
            List<GetReservationByUserIdQueryResponse> response = await _mediator.Send(getReservationByUserIdQueryRequest);
            return Ok(response);
        }

        [HttpGet("room/{roomId}")]
        public async Task<IActionResult> getReservationByRoomId([FromRoute] GetReservationByRoomIdQueryRequest getReservationByRoomIdQueryRequest)
        {
            List<GetReservationByRoomIdQueryResponse> response = await _mediator.Send(getReservationByRoomIdQueryRequest);
            return Ok(response);
        }
    }
}
