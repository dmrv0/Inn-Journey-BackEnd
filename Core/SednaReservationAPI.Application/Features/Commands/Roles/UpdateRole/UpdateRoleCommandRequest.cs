using MediatR;

namespace SednaReservationAPI.Application.Features.Commands.Roles.UpdateRole
{
    public class UpdateRoleCommandRequest:IRequest<UpdateRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}