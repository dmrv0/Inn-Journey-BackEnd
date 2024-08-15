using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.Role.GetRoleById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQueryRequest, GetRoleByIdQueryResponse>
    {
        IRoleServices _roleServices;

        public GetRoleByIdQueryHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<GetRoleByIdQueryResponse> Handle(GetRoleByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var resp = await _roleServices.GetRoleById(request.Id);
            return new() { 
                Id = resp.Id, Name = resp.Name };

        }
    }
}
