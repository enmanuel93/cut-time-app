using CutTime.Domain.Contracts;
using CutTime.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutTime.Infrastructure.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private CutTimeContext _context;

        private BarberRepository barberRepository;
        private ClientRepository clientRepository;
        private AppointmentRepository appointmentRepository;
        private UserRepository userRepository;



        public IBarberRepository BarberRepository
        {
            get
            {
                if (barberRepository == null)
                {
                    barberRepository = new BarberRepository(_context);
                }
                return barberRepository;
            }
        }

        public IClientRepository ClientRepository
        {
            get
            {
                if (clientRepository == null)
                {
                    clientRepository = new ClientRepository(_context);
                }
                return clientRepository;
            }
        }

        public IAppointmentRepository AppointmentRepository
        {
            get
            {
                if (appointmentRepository == null)
                {
                    appointmentRepository = new AppointmentRepository(_context);
                }
                return appointmentRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(_context);
                }
                return userRepository;
            }
        }

        public RepositoryWrapper(CutTimeContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
