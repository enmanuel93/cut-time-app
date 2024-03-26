namespace CutTime.Domain.Contracts
{
    public interface IRepositoryWrapper
    {
        IBarberRepository BarberRepository { get; }
        IClientRepository ClientRepository { get; }
        IAppointmentRepository AppointmentRepository { get; }
        IUserRepository UserRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
