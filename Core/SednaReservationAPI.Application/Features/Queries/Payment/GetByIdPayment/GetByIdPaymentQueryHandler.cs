using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetByIdPayment
{
    public class GetByIdPaymentQueryHandler : IRequestHandler<GetByIdPaymentQueryRequest, GetByIdPaymentQueryResponse>
    {
        readonly IPaymentReadRepository _paymentReadRepository;

        public GetByIdPaymentQueryHandler(IPaymentReadRepository paymentReadRepository)
        {
            _paymentReadRepository = paymentReadRepository;
        }

        public async Task<GetByIdPaymentQueryResponse> Handle(GetByIdPaymentQueryRequest request, CancellationToken cancellationToken)
        {
            var payment = await _paymentReadRepository.GetByIdAsync(request.Id, false);


            var response = new GetByIdPaymentQueryResponse
            {
                Id = payment.Id.ToString(),
                ReservationId = payment.ReservationId,
                Amount = payment.Amount,
                Status = payment.Status,
                PaymentMethod = payment.PaymentMethod,
                Date = payment.Date
            };

            return response;
        }
    }
}
