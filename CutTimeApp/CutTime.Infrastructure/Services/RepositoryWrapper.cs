using CutTime.Domain.Contracts;
using CutTime.Domain.Models;

namespace CutTime.Infrastructure.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly CutTimeContext _context;

        private BarberRepository? barberRepository;
        private ClientRepository? clientRepository;
        private AppointmentRepository? appointmentRepository;
        private UserRepository? userRepository;

        public IBarberRepository BarberRepository
        {
            get
            {
                barberRepository ??= new BarberRepository(_context);
                return barberRepository;
            }
        }

        public IClientRepository ClientRepository
        {
            get
            {
                clientRepository ??= new ClientRepository(_context);
                return clientRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                appointmentRepository ??= new AppointmentRepository(_context);
                return appointmentRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                userRepository ??= new UserRepository(_context);
                return userRepository;
            }
        }

        public RepositoryWrapper(CutTimeContext context) => _context = context;

        public void Save() => _context.SaveChanges();

        public Task SaveAsync() => _context.SaveChangesAsync();

    }
}
