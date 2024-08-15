using MediatR;
using Microsoft.AspNetCore.Identity;
using SednaReservationAPI.Application.Abstractions.Services;
using SednaReservationAPI.Application.DTOs.User;
using SednaReservationAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryHandler:IRequestHandler<GetAllUserQueryRequest, List<GetAllUserQueryResponse>>
    {

        readonly IUserService _userService;

        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<ListUser> userList = await _userService.GetAllUserAsync();

            List<GetAllUserQueryResponse> responseList = userList.Select(user => new GetAllUserQueryResponse
            {
                Id = user.Id,
                UserName = user.UserName,
                Name = user.Name,
                Email = user.Email,
                Age = user.Age,
                Phone = user.Phone,
                Gender = user.Gender,
            }).ToList();

            return responseList;

        }
    }
}
