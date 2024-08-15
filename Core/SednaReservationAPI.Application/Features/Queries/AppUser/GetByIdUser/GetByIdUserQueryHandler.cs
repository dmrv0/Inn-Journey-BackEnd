//using MediatR;
//using SednaReservationAPI.Application.Abstractions.Services;
//using SednaReservationAPI.Application.Features.Queries.AppUser.GetAllUser;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using MediatR;
using SednaReservationAPI.Application.Abstractions.Services;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly IUserService _userService;

        public GetByIdUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await _userService.getByIdUser(request.Id);


            if (user != null)
            {
                return new GetByIdUserQueryResponse
                {
                    Id = request.Id,
                    UserName = user.UserName,
                    Name = user.Name,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Age = user.Age,
                    Gender = user.Gender,
                    IsAdmin = user.isAdmin,
                    // Diğer özellikleri varsayılan değerleriyle doldurabilirsiniz veya isteğe bağlı olarak atayabilirsiniz.
                };
            }
            return null;
        }
    }

}
