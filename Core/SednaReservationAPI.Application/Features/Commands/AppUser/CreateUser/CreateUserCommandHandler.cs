using MediatR;
using Microsoft.AspNetCore.Identity;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using SednaReservationAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            CreateUserResponse createUserResponse = await _userService.CreateAsync(new()
            {
                UserName = request.UserName,
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
                PasswordConfirm = request.PasswordConfirm,
                Phone = request.Phone,
                Age = request.Age,
                Gender = request.Gender,
                IsAdmin = false,
                
            });

            return new()
            {
                Message = createUserResponse.Message,
                Success = createUserResponse.Success
            };

            //throw new UserCreateFailedException();
        }
    }
}
