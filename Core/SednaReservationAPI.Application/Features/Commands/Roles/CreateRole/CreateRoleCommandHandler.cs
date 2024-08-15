using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, CreateRoleCommandResponse>
    {
        readonly IRoleServices _roleServices;

        public CreateRoleCommandHandler(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }

        public async Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
           var result = await _roleServices.CreateRole(request.Name);


            return new CreateRoleCommandResponse()
            {
                Success = result
            };
        }
    }
}
