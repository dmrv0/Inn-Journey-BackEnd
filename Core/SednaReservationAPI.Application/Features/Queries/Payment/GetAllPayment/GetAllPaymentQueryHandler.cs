using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetAllPayment
{
    public class GetAllPaymentQueryHandler : IRequestHandler<GetAllPaymentQueryRequest, List<GetAllPaymentQueryResponse>>
    {
        readonly IPaymentReadRepository _paymentReadRepository;

        public GetAllPaymentQueryHandler(IPaymentReadRepository paymentReadRepository)
        {
            _paymentReadRepository = paymentReadRepository;
        }

        public Task<List<GetAllPaymentQueryResponse>> Handle(GetAllPaymentQueryRequest request, CancellationToken cancellationToken)
        {
            var payments = _paymentReadRepository.GetAll(false)
               .Select(payment => new GetAllPaymentQueryResponse
               {
                   Id = payment.Id.ToString(),
                   ReservationId = payment.ReservationId,
                   Amount = payment.Amount,
                   Status = payment.Status,
                   PaymentMethod = payment.PaymentMethod,
                   Date = payment.Date
               })
               .ToList();

            return Task.FromResult(payments);
        }
    }
}
