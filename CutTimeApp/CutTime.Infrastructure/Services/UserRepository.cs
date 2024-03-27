using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Infrastructure.Services
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private CutTimeContext _context;

        public UserRepository(CutTimeContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserAndRolByCredentials(User user)
        {
            try
            {
                var userModel = await (from u in _context.Users
                                       join ur in _context.UserRoles
                                       on u.ID_User equals ur.ID_User
                                       join r in _context.Roles
                                       on ur.ID_Role equals r.ID_Role
                                       where u.Email == user.Email
                                       && u.Password == user.Password
                                       select new User
                                       {
                                           Name = u.Name,
                                           Email = u.Email,
                                           Roles = new List<Role>
                                           {
                                               new Role {Name = r.Name}
                                           }
                                       }).FirstOrDefaultAsync();

                //var userModel = await _context.UserRoles.Include(x => x.User)

                return userModel;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
