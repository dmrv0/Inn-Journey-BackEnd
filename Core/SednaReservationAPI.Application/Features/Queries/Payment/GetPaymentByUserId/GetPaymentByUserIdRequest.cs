
using MediatR;

namespace SednaReservationAPI.Application.Features.Queries.Payment.GetPaymentByUserId
{
    public class GetPaymentByUserIdRequest: IRequest<GetPaymentByUserIdResponse>
    {
        public int Page { get; set; }
        public int Size { get; set; }
        public string userId { get; set; }
    }
}
