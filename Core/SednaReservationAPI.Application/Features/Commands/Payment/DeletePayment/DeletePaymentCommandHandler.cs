using MediatR;
using SednaReservationAPI.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Payment.DeletePayment
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommandRequest, DeletePaymentCommandResponse>
    {
        readonly IPaymentWriteRepository _paymentWriteRepository;

        public DeletePaymentCommandHandler(IPaymentWriteRepository paymentWriteRepository)
        {
            _paymentWriteRepository = paymentWriteRepository;
        }

        public async Task<DeletePaymentCommandResponse> Handle(DeletePaymentCommandRequest request, CancellationToken cancellationToken)
        {
            await _paymentWriteRepository.RemoveAsync(request.Id);
            await _paymentWriteRepository.SaveAsync();
            return new();
        }
    }
}
