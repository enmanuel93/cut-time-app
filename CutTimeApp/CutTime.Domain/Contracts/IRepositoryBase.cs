using System.Linq.Expressions;

namespace CutTime.Domain.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        Task<IQueryable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression);

        Task<List<T>> ToListAsync();

        T2? Max<T2>(Expression<Func<T, T2>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        int Count();

        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
