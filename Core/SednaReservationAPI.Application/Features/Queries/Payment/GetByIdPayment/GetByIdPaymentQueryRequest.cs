using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetByIdPayment
{
    public class GetByIdPaymentQueryRequest : IRequest<GetByIdPaymentQueryResponse>
    {
        public string? Id { get; set; }
    }
}
