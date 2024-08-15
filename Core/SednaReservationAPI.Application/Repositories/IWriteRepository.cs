using SednaReservationAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntitity
    {
        Task<bool> AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T entity);
        bool RemoveRange(List<T> datas);
        Task<bool> RemoveAsync(string id);
        bool Update(T entity);
        bool UpdateRange(List<T> datas);
        Task<bool> UpdateAsync(string id);
        Task<int> SaveAsync();
        Task<float> SaveAsync2();

    }
}
