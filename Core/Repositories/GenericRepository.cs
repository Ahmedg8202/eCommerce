﻿
using ECommerce.Core.Data;
using ECommerce.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace ECommerce.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _Dbset;

        public GenericRepository(ApplicationDbContext _context)
        {
            this._context = _context;
            this._Dbset = _context.Set<T>();
        }

        
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _Dbset.ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(int Id)
        {
            return await _Dbset.FindAsync(Id);
        }

        public virtual async Task<bool> AddAsync(T Entity)
        {
            await _Dbset.AddAsync(Entity);
            return true;
        }

        public virtual bool Update(T Entity)
        {
            _Dbset.Update(Entity);
            return true;    
        }

        public virtual async Task<bool> DeleteAsync(int Id)
        {
            T? Entity = await _Dbset.FindAsync(Id);
            if (Entity == null)
                return false;
            _Dbset.Remove(Entity);
            return true;
        }

    }
}
