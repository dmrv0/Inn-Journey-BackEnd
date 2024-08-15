using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdsUser
{
    public class GetByIdsUserQueryHandler : IRequestHandler<GetByIdsUserQueryRequest, GetByIdsUserQueryResponse>
    {
        readonly IUserService _userService;

        public GetByIdsUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetByIdsUserQueryResponse> Handle(GetByIdsUserQueryRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcıları ID'ler listesine göre al
            var users = await _userService.getByIdUsers(request.userIds);

            // Kullanıcıları DTO'ya dönüştür
            var userDtos = users.Select(user => new GetUser
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Age = user.Age,
                Gender = user.Gender
            }).ToList();


            return new GetByIdsUserQueryResponse(userDtos);

        }
    }
}
