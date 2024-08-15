using SednaReservationAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.DTOs
{
    public class Token
    {
        public string? userId { get; set; }
        public string? AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public string? RefreshToken { get; set; }
        public bool? isAdmin { get; set; }

    }
}
