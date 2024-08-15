using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.Abstractions.Token;
using SednaReservationAPI.Application.DTOs;
using SednaReservationAPI.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IAuthService _authService;

        public LoginUserCommandHandler(IAuthService authService)
        {
            _authService = authService;


        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 1);
                return new LoginUserSuccessCommandResponse
                {
                    Token = token
                };
            }
            catch (NotFoundUserException ex)
            {
                // Kullanıcı bulunamadığında dönecek hata mesajı
                return new LoginUserErrorCommandResponse { Message = ex.Message };
            }
            catch (AuthenticationErrorException ex)
            {
                // Şifre yanlış olduğunda dönecek hata mesajı
                return new LoginUserErrorCommandResponse { Message = ex.Message };
            }
        }
    }
}
