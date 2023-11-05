using Core.Utilities;
using Infrastructure.Data.Postgres.Entities;
using Infrastructure.Data.Postgres.Entities.Base.Interface;
using Infrastructure.Data.Postgres.EntityFramework;
using Infrastructure.Data.Postgres.Repositories;
using Infrastructure.Data.Postgres.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Postgres;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgresContext _postgresContext;

    private UserRepository? _userRepository;
    private UserTokenRepository? _userTokenRepository;
    private CommentsRepository? _commentsRepository;
    private UserCommentsRepository? _userCommentsRepository;
    private PrescriptionsRepository? _prescriptionsRepository;
    private AppointmentRepository? _appointmentRepository;

    public UnitOfWork(PostgresContext postgresContext)
    {
        _postgresContext = postgresContext;
    }

    public IUserRepository Users => _userRepository ??= new UserRepository(_postgresContext);
    public IUserTokenRepository UserTokens =>
        _userTokenRepository ??= new UserTokenRepository(_postgresContext);

    public IAppointmentRepository Appointments =>
        _appointmentRepository ??= new AppointmentRepository(_postgresContext);

    public ICommentsRepository Comments =>
        _commentsRepository ??= new CommentsRepository(_postgresContext);

    public IUserCommentsRepository UserComments =>
        _userCommentsRepository ??= new UserCommentsRepository(_postgresContext);
    public IPrescriptionsRepository Prescriptions =>
        _prescriptionsRepository ??= new PrescriptionsRepository(_postgresContext);

    public async Task<int> CommitAsync()
    {
        var updatedEntities = _postgresContext.ChangeTracker
            .Entries<IEntity>()
            .Where(e => e.State == EntityState.Modified)
            .Select(e => e.Entity);

        foreach (var updatedEntity in updatedEntities)
        {
            updatedEntity.UpdatedAt = DateTime.UtcNow.ToTimeZone();
        }

        var result = await _postgresContext.SaveChangesAsync();

        return result;
    }

    public void Dispose()
    {
        _postgresContext.Dispose();
    }
}
