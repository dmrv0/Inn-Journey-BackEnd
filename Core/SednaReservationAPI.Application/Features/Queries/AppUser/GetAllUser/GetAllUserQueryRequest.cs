using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryRequest:IRequest<List<GetAllUserQueryResponse>>
    {
    }
}
