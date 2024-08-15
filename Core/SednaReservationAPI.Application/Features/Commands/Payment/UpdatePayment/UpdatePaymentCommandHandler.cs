using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Payment.UpdatePayment
{
    public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommandRequest, UpdatePaymentCommandResponse>
    {
        readonly IPaymentReadRepository _paymentReadRepository;
        readonly IPaymentWriteRepository _paymentWriteRepository;

        public UpdatePaymentCommandHandler(IPaymentReadRepository paymentReadRepository, IPaymentWriteRepository paymentWriteRepository)
        {
            _paymentReadRepository = paymentReadRepository;
            _paymentWriteRepository = paymentWriteRepository;
        }

        public async Task<UpdatePaymentCommandResponse> Handle(UpdatePaymentCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Payment payment = await _paymentReadRepository.GetByIdAsync(request.Id);
            
            payment.ReservationId = request.ReservationId;
            payment.Amount = request.Amount;
            payment.Status = request.Status;
            payment.UpdatedDate = DateTime.UtcNow;

            await _paymentWriteRepository.SaveAsync();

            return new();
        }
    }
}
