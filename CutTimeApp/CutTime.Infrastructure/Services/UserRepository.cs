using CutTime.Domain.Contracts;
using CutTime.Domain.Models;

namespace CutTime.Infrastructure.Services
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CutTimeContext context) : base(context) {  }
    }
}
