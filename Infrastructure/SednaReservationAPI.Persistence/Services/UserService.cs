using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using SednaReservationAPI.Application.Exceptions;
using SednaReservationAPI.Application.Features.Commands.AppUser.CreateAppUser;
using SednaReservationAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponse> CreateAsync(CreateUser user)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.Phone,
                Age = user.Age,
                Gender = user.Gender
            }, user.Password);

            CreateUserResponse response = new() { Success = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User Created Successfully!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accessTokenDate, int accessTokenAddOn)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpirationDate = accessTokenDate.AddMinutes(accessTokenAddOn);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }

        public async Task<List<GetUser>> GetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<GetUser>();

            foreach (var user in users)
            {
                userDtos.Add(new GetUser
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Age = user.Age,
                    Gender = user.Gender
                });
            }

            return userDtos;
        }

        public async Task<List<ListUser>> GetAllUserAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var listusers = users.Select(users => new ListUser
            {
                Id = users.Id,
                Email = users.Email,
                Name = users.Name,
                UserName = users.UserName
            }).ToList();

            return listusers;
        }

        public Task<AppUser> getByIdUser(string id)
        {
            var user = _userManager.FindByIdAsync(id);

            return user;
        }

        public async Task<List<AppUser>> getByIdUsers(IEnumerable<string> ids)
        {
            var users = new List<AppUser>();

            foreach (var id in ids)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user != null)
                {
                    users.Add(user);
                }
            }

            return users;
        }



        public async Task<AppUser> UpdateUser(UpdateUser user)
        {
            // Kullanıcıyı Id'ye göre bul
            AppUser existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.UserName = user.UserName;
                existingUser.Email = user.Email;
                existingUser.PhoneNumber = user.Phone;
                existingUser.Gender = user.Gender;
                existingUser.Age = user.Age;
            }
            var result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded && !string.IsNullOrEmpty(user.Password) && !string.IsNullOrEmpty(user.PasswordConfirm))
            {
                await _userManager.RemovePasswordAsync(existingUser);  //kullanıcınını parolasını sildik
                await _userManager.AddPasswordAsync(existingUser, user.Password); //modelden gelen passwordu user daki passworda aktardık
            }

            
            if (result.Succeeded)
            {
                return existingUser;
            }
            else
            {
                // Handle update failure
                throw new Exception($"Update failed for user {user.Id}: {string.Join("\n", result.Errors.Select(e => $"{e.Code} - {e.Description}"))}");
            }
        }
    }
    
}
