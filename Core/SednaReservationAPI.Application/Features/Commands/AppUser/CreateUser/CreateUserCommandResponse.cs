using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateUserCommandResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
}
