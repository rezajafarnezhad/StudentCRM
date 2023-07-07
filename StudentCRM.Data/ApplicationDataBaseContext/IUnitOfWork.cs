using Microsoft.EntityFrameworkCore;

namespace StudentCRM.Data.ApplicationDataBaseContext;

public interface IUnitOfWork : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();
  
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}