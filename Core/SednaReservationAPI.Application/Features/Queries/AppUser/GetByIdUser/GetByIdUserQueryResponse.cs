using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Queries.AppUser.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string Age { get; set; }
        public bool? Gender { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
