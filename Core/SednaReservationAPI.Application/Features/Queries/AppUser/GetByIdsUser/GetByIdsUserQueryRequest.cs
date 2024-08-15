using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdsUser
{
    public class GetByIdsUserQueryRequest: IRequest<GetByIdsUserQueryResponse>
    {
        public IEnumerable<string> userIds { get; set; } // Otel ID'leri
    }
}
