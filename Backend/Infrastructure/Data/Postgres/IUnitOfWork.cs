using Infrastructure.Data.Postgres.Repositories.Interface;

namespace Infrastructure.Data.Postgres;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IUserTokenRepository UserTokens { get; }
    IAppointmentRepository Appointments { get; }
    ICommentsRepository Comments { get; }
    IUserCommentsRepository UserComments { get; }
    IPrescriptionsRepository Prescriptions { get; }

    Task<int> CommitAsync();
}