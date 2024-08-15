using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryHandler : IRequestHandler<GetRolesQueryRequest, GetRolesQueryResponse>
    {

        IRoleServices _roleServices;

        public GetRolesQueryHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<GetRolesQueryResponse> Handle(GetRolesQueryRequest request, CancellationToken cancellationToken)
        {
            var data =await _roleServices.GetAllRoles();
            return new()
            {
                Roles = data
            };
           
        }
    }
}
