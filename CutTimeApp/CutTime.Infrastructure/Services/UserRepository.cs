using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Infrastructure.Services
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(CutTimeContext context)
            : base(context)
        {
        }
    }
}
