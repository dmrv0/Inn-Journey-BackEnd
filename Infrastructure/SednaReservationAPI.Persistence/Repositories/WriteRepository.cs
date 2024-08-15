using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SednaReservationAPI.Application.Repositories;
using SednaReservationAPI.Domain.Entities.Common;
using SednaReservationAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SednaReservationAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntitity
    {
        private readonly SednaReservationAPIDbContext _context;
        public WriteRepository(SednaReservationAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        public bool Remove(T entity)
        {
            EntityEntry<T> entityEntry = Table.Remove(entity);
            return entityEntry.State == EntityState.Deleted;

        }
        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Remove(entity);
        }
        public bool Update(T entity)
        {
            Table.Update(entity);
            return true;
        }
        public bool UpdateRange(List<T> datas)
        {
            Table.UpdateRange(datas);
            return true;
        }
        public async Task<bool> UpdateAsync(string id)
        {
            T entity = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            return Update(entity);
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
        public async Task<float> SaveAsync2()
         => await _context.SaveChangesAsync();
    }
}
