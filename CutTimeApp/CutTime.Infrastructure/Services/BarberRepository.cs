using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Infrastructure.Services
{
    public class BarberRepository : RepositoryBase<Barber>, IBarberRepository
    {
        public BarberRepository(CutTimeContext context)
            : base(context)
        {
        }
    }
}
