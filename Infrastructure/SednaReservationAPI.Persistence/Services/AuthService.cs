using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.Abstractions.Token;
using SednaReservationAPI.Application.DTOs;
using SednaReservationAPI.Application.Exceptions;
using SednaReservationAPI.Application.Features.Commands.AppUser.LoginUser;
using SednaReservationAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        readonly ITokenHandler _tokenHandler;
        readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
        }

        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
          Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);
            if (user == null)
                throw new NotFoundUserException("Böyle bir kullanıcı bulunamadı.");

            SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (signInResult.Succeeded)
            {

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60);

                if (user.isAdmin == true)
                {

                    var response = new Application.DTOs.Token
                    {


                        Expiration = token.Expiration,
                        AccessToken = token.AccessToken,
                        RefreshToken = token.RefreshToken,
                        userId = user.Id,
                        isAdmin=user.isAdmin
                    };

                    return response;
                }
                var authResponse = new Application.DTOs.Token
                {

                    Expiration = token.Expiration,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    userId = user.Id,

                };
                return authResponse;


            }
            else
                throw new AuthenticationErrorException("Kullanıcı adı veya şifre yanlış");
        }

        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(user => user.RefreshToken == refreshToken);


                if (user != null && user?.RefreshTokenExpirationDate > DateTime.UtcNow)
                {
                    Token token = _tokenHandler.CreateAccessToken(1);


                try
                {
                    await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 50);
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Error in RefreshTokenLoginAsync: {ex.Message}");
                    throw;
                }

                if (user.isAdmin == true)
                {
                    var response = new Application.DTOs.Token
                    {


                        Expiration = token.Expiration,
                        AccessToken = token.AccessToken,
                        RefreshToken = token.RefreshToken,
                        userId = user.Id,
                        isAdmin = user.isAdmin
                    };

                    return response;
                }
                var authResponse = new Application.DTOs.Token
                {

                    Expiration = token.Expiration,
                    AccessToken = token.AccessToken,
                    RefreshToken = token.RefreshToken,
                    userId = user.Id,

                };
                return authResponse;
            }
                else
                    throw new NotFoundUserException();
            
    
            
        }



    }
}
