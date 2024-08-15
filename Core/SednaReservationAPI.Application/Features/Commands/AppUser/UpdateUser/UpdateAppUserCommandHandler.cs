using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using System.Threading;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.AppUser.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommandRequest, UpdateAppUserCommandResponse>
    {
        private readonly IUserService _userService;

        public UpdateAppUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<UpdateAppUserCommandResponse> Handle(UpdateAppUserCommandRequest request, CancellationToken cancellationToken)
        {
            var updateUser = new UpdateUser
            {
                Id = request.Id,
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Phone = request.Phone,
                Age = request.Age,
                Gender = request.Gender
            };

            // Şifre girilmişse ve confirmPassword değişkeni boş değilse, şifre güncellemesi yapılacak
            if (!string.IsNullOrEmpty(request.Password) && !string.IsNullOrEmpty(request.ConfirmPassword) && request.Password == request.ConfirmPassword)
            {
                updateUser.Password = request.Password;
                updateUser.PasswordConfirm = request.ConfirmPassword;
           

            try
            {
                var updatedUser = await _userService.UpdateUser(updateUser);

                return new UpdateAppUserCommandResponse
                {
                    IsUpdated = updatedUser != null
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"User update failed: {ex.Message}", ex);
            }

            }

            throw new Exception($"User update failed");
        }
    }
}
