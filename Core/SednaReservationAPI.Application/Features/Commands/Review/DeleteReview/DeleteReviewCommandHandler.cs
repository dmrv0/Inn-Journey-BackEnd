using MediatR;
using SednaReservationAPI.Application.Features.Commands.Review.CreateReview;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.DeleteReview
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommandRequest, DeleteReviewCommandResponse>
    {
        readonly IReviewWriteRepository _reviewWriteRepository;

        public DeleteReviewCommandHandler(IReviewWriteRepository reviewWriteRepository)
        {
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task<DeleteReviewCommandResponse> Handle(DeleteReviewCommandRequest request, CancellationToken cancellationToken)
        {
            await _reviewWriteRepository.RemoveAsync(request.Id);
            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
