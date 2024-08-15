using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SednaReservationAPI.Application.Features.Commands.Review.CreateReview;
using SednaReservationAPI.Application.Features.Commands.Review.DeleteReview;
using SednaReservationAPI.Application.Features.Commands.Review.UpdateReview;
using SednaReservationAPI.Application.Features.Queries.Review.GetAllReview;
using SednaReservationAPI.Application.Features.Queries.Review.GetByIdReview;
using SednaReservationAPI.Application.Features.Queries.Review.GetReviewHotelById;
using SednaReservationAPI.Application.Features.Queries.Review.GetReviewUserById;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReservationReadRepository _reservationReadRepository;
        private readonly IReservationWriteRepository _reservationWriteRepository;
        private readonly IMediator _mediator;

        public ReviewsController(IReservationReadRepository reservationReadRepository, IReservationWriteRepository reservationWriteRepository, IMediator mediator)
        {
            _reservationReadRepository = reservationReadRepository;
            _reservationWriteRepository = reservationWriteRepository;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> getReview([FromQuery] GetAllReviewQueryRequest getAllReviewQueryRequest)
        {
            List<GetAllReviewQueryResponse> response = await _mediator.Send(getAllReviewQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> getReviewById([FromRoute] GetByIdReviewQueryRequest getByIdReviewQueryRequest)
        {
            GetByIdReviewQueryResponse response = await _mediator.Send(getByIdReviewQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> getAddReview(CreateReviewCommandRequest createReviewCommandRequest)
        {
            CreateReviewCommandResponse response = await _mediator.Send(createReviewCommandRequest);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> deleteReview([FromRoute] DeleteReviewCommandRequest deleteReviewCommandRequest)
        {
            DeleteReviewCommandResponse response = await _mediator.Send(deleteReviewCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> updateReview([FromBody] UpdateReviewCommandRequest updateReviewCommandRequest)
        {
            UpdateReviewCommandResponse response = await _mediator.Send(updateReviewCommandRequest);
            return Ok(response);
        }
        [HttpGet("comments/")]
        public async Task<IActionResult> getReviewHotelById([FromQuery] GetReviewHotelByIdQueryRequest getReviewHotelByIdQueryRequest)
        {
            GetReviewHotelByIdQueryResponse response = await _mediator.Send(getReviewHotelByIdQueryRequest);
            return Ok(response);

        }
        [HttpGet("user/comments")]
        public async Task<IActionResult> getReviewUserById([FromQuery] GetReviewUserByIdQueryRequest getReviewUserByIdQueryRequest)
        {
            GetReviewUserByIdQueryResponse response = await _mediator.Send(getReviewUserByIdQueryRequest);
            return Ok(response);
        }

    }
}
