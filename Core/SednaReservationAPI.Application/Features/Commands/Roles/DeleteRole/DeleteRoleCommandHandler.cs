using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Roles.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
    {

        readonly IRoleServices _roleServices;

        public DeleteRoleCommandHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _roleServices.DeleteRole(request.Name);

            return new()
            {
                Success = result
            };
        }
    }
}
