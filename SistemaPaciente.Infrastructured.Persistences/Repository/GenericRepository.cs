using Microsoft.EntityFrameworkCore;
using SistemaPacientes.Infrastructure.Persistence.Context;
using SistemaPacientes.Core.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPacientes.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly SistemaPacienteContext _context;
        public GenericRepository(SistemaPacienteContext context)
        {
            _context = context;
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            await _context.Set<T>().FindAsync(entity);
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<ICollection<T>> GetAllAsyncInclude(List<string> properties)
        {
            var query = _context.Set<T>().AsQueryable();
            foreach (var item in properties)
            {
                query = query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
