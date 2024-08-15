using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string? Name { get; set; }
        public string Age { get; set; }
        public bool? Gender { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpirationDate { get; set; }
        public bool? isAdmin { get; set; } = false;

    }
}
