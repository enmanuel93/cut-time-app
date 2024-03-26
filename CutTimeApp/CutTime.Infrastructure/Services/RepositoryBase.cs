using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CutTime.Infrastructure.Services
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly CutTimeContext _context;

        public RepositoryBase(CutTimeContext context) => _context = context;

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();

        public Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression) => Task.FromResult(_context.Set<T>().Where(expression).AsNoTracking());
            
        public Task<List<T>> ToListAsync() => _context.Set<T>().ToListAsync();

        public T2? Max<T2>(Expression<Func<T, T2>> expression) =>  _context.Set<T>().Max(expression) ?? default;

        public int Count() => _context.Set<T>().Count();

        public bool Any(Expression<Func<T, bool>> expression) => _context.Set<T>().Any(expression);

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

    }
}
