using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordConfirm { get; set; }
        public string? Phone { get; set; }
        public string Age { get; set; }
        public bool Gender { get; set; }
    }
}
