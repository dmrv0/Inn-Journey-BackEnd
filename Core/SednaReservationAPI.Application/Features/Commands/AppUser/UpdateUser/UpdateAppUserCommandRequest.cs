using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.UpdateAppUser
{
    public class UpdateAppUserCommandRequest : IRequest<UpdateAppUserCommandResponse>
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
  
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Age { get; set; }
        public bool Gender { get; set; }
    }
}
