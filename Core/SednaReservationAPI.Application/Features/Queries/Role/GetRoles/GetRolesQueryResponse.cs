using SednaReservationAPI.Application.DTOs.Role;

namespace SednaReservationAPI.Application.Features.Queries.Role.GetRoles
{
    public class GetRolesQueryResponse
    {
        public List<RoleDto> Roles{ get; set; }
    }
}