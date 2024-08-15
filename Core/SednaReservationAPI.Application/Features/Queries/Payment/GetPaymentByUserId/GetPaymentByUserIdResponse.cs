using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByUserId
{
    public class GetPaymentByUserIdResponse
    {

        public List<Domain.Entities.Payment>? Payments { get; set; }
        public int? TotalCount { get; set; }
    }
}
