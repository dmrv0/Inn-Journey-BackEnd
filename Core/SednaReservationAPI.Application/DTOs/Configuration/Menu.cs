using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.DTOs.Configuration
{
    public class Menu
    {
        public string MenuName { get; set; }
        public List<Action> Actions { get; set; } = new();
    }
}
