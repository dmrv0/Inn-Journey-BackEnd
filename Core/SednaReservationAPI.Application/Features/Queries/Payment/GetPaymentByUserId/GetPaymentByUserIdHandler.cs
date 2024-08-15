using Iyzipay.Model;
using MediatR;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByUserId
{
    public class GetPaymentByUserIdHandler : IRequestHandler<GetPaymentByUserIdRequest, GetPaymentByUserIdResponse>
    {
        IPaymentReadRepository _paymentReadRepository;

        public GetPaymentByUserIdHandler(IPaymentReadRepository paymentReadRepository)
        {
            _paymentReadRepository = paymentReadRepository;
        }

        public async Task<GetPaymentByUserIdResponse> Handle(GetPaymentByUserIdRequest request, CancellationToken cancellationToken)
        {
            // Sayfalamayı gerçekleştirin ve oda kapasitelerini güncelleyin
            if (request.Size > 0 && request.Page >= 0)
            {
                var paymentsQuery = _paymentReadRepository.GetWhere(r => r.UserId == request.userId);

                // En son eklenene göre sıralama ve sayfalama
                var payments = paymentsQuery
                    .OrderByDescending(p => p.Date) // En son eklenenleri önce al
                    .Skip(request.Page * request.Size) // Sayfayı 0 tabanlı index olarak kullanıyoruz
                    .Take(request.Size) // Sayfa başına öğe sayısını al
                    .Select(payment => new Domain.Entities.Payment
                    {
                        Id = payment.Id,
                        UserId = payment.UserId,
                        ReservationId = payment.ReservationId,
                        HotelId = payment.HotelId,
                        Amount = payment.Amount,
                        Status = payment.Status,
                        PaymentMethod = payment.PaymentMethod,
                        Date = payment.Date,
                    })
                    .ToList();

                var totalCount = paymentsQuery.Count();
                return new(){ Payments = payments, TotalCount = totalCount };
            }




            return new() { };


        }
    }
}
