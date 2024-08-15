using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Reservation.GetReservationByUserId
{
    public class GetReservationByUserIdQueryRequest: IRequest<List<GetReservationByUserIdQueryResponse>>
    {
        public string userId { get; set; }
        public int? Page { get; set; }
        public int? Size { get; set; }
    }
}
