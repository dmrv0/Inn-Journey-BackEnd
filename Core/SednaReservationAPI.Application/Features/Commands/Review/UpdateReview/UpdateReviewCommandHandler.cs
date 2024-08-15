using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Review.UpdateReview
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommandRequest, UpdateReviewCommandResponse>
    {
        readonly IReviewReadRepository _reviewReadRepository;
        readonly IReviewWriteRepository _reviewWriteRepository;

        public UpdateReviewCommandHandler(IReviewReadRepository reviewReadRepository, IReviewWriteRepository reviewWriteRepository)
        {
            _reviewReadRepository = reviewReadRepository;
            _reviewWriteRepository = reviewWriteRepository;
        }

        public async Task<UpdateReviewCommandResponse> Handle(UpdateReviewCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Review review = await _reviewReadRepository.GetByIdAsync(request.Id);
            review.Rating = request.Rating;
            review.Comment = request.Comment;

            await _reviewWriteRepository.SaveAsync();
            return new();
        }
    }
}
