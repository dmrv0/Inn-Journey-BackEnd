using SednaReservationAPI.Application.DTOs.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Abstractions.Services
{
    public interface IRoleServices
    {
        Task<bool> CreateRole(string name);
        Task<bool> DeleteRole(string name);
       Task<bool> UpdateRole(string id);
        Task<List<RoleDto>> GetAllRoles();
        Task<RoleDto> GetRoleById(string id);

    }
}
