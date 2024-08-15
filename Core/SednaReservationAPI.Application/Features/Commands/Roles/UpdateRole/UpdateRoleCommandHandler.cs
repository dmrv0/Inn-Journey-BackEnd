using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommandRequest, UpdateRoleCommandResponse>
    {
        IRoleServices _roleServices;

        public UpdateRoleCommandHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<UpdateRoleCommandResponse> Handle(UpdateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleServices.UpdateRole(request.Id);

            return new()
            {
                Success = result
            };
        }
    }
}
