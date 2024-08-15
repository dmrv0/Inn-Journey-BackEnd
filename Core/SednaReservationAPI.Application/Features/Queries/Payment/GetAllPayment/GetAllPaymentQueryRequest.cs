using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetAllPayment
{
    public class GetAllPaymentQueryRequest : IRequest<List<GetAllPaymentQueryResponse>>
    {

    }
}
