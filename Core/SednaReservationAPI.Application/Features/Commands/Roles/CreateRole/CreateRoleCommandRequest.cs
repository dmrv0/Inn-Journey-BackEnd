﻿using MediatR;

namespace SednaReservationAPI.Application.Features.Commands.Roles.CreateRole
{
    public class CreateRoleCommandRequest:IRequest<CreateRoleCommandResponse>
    {
        public string Name { get; set; }
    }
}