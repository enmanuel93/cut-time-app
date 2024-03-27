using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Domain.Contracts
{
    public interface IRepositoryWrapper
    {
        IBarberRepository BarberRepository { get; }
        IClientRepository ClientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IUserRepository UserRepository { get; }
        IRolRepository RolRepository { get; }
    }
}
