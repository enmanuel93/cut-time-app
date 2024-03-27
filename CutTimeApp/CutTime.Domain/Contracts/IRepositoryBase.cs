using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Contracts
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<IEnumerable<T>> FindByCondition(Expression<Func<T, bool>> expression);
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
