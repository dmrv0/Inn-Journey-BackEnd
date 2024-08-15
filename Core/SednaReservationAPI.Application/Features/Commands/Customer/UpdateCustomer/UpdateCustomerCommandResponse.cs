using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Features.Commands.Customer.UpdateCustomer
{
    public class UpdateCustomerCommandResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public int Age { get; set; }
        public string? Gender { get; set; }
    }
}
