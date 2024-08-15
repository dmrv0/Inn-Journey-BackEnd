using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdsUser
{
    public class GetByIdsUserQueryResponse
    {
        public List<Application.DTOs.User.GetUser> Users { get; set; }

        public GetByIdsUserQueryResponse(List<Application.DTOs.User.GetUser> users)
        {
            Users = users;
        }
    }
}
