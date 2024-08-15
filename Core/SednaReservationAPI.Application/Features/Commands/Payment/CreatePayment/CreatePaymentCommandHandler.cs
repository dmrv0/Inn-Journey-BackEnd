using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Payment.CreatePayment
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommandRequest, CreatePaymentCommandResponse>
    {
        readonly IPaymentWriteRepository _paymentWriteRepository;

        public CreatePaymentCommandHandler(IPaymentWriteRepository paymentWriteRepository)
        {
            _paymentWriteRepository = paymentWriteRepository;
        }

        public async Task<CreatePaymentCommandResponse> Handle(CreatePaymentCommandRequest request, CancellationToken cancellationToken)
        {
            await _paymentWriteRepository.AddAsync(new Domain.Entities.Payment()

            {
                ReservationId = request.ReservationId,
                HotelId = request.HotelId,
                UserId = request.UserId,
                Amount = request.Amount,
                Status = request.Status,
              
                PaymentMethod = request.PaymentMethod,
                Date = DateTime.UtcNow,
            });

            await _paymentWriteRepository.SaveAsync();
            return new();
        }
    }
}
