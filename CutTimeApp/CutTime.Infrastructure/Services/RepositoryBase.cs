using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Infrastructure.Services
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected CutTimeContext _context { get; set; }
        public RepositoryBase(CutTimeContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> FindAll() => await _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression) =>
            await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}
