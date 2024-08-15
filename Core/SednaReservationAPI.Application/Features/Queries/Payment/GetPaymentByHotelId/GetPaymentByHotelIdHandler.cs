

using MediatR;
using SednaReservationAPI.Application.Repositories;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByHotelId
{
    public class GetPaymentByHotelIdHandler : IRequestHandler<GetPaymentByHotelIdRequest, List<GetPaymentByHotelIdResponse>>
    {
        IPaymentReadRepository _paymentReadRepository;

        public GetPaymentByHotelIdHandler(IPaymentReadRepository paymentReadRepository)
        {
            _paymentReadRepository = paymentReadRepository;
        }

        public async Task<List<GetPaymentByHotelIdResponse>> Handle(GetPaymentByHotelIdRequest request, CancellationToken cancellationToken)
        {   var totalCount =  _paymentReadRepository.GetWhere(r => r.HotelId == request.hotelId).Count();
            var payments = _paymentReadRepository.GetWhere(r => r.HotelId == request.hotelId)
                .OrderByDescending(p=> p.CreatedDate)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .Select(payments => new GetPaymentByHotelIdResponse
            {
                Id = payments.Id.ToString(),
                userId= payments.UserId,
                ReservationId = payments.ReservationId,
                hotelId = payments.HotelId,
                Amount = payments.Amount,
                Status = payments.Status,
                PaymentMethod = payments.PaymentMethod,
                Date = payments.Date,
                TotalCount = totalCount,
            }).ToList();

            return await Task.FromResult(payments);
        }
    }
}
