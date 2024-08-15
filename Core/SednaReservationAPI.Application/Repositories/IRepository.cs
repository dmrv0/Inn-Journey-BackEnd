using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SednaReservationAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntitity
    {
        DbSet<T> Table { get; }
    }
}
