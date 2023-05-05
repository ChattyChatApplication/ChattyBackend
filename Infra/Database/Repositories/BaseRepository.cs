using Core.Entities;
using Domain.Contracts.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
   private readonly ChattyDbContext _dbContext;
   private readonly DbSet<T> _userAccounts;

   public BaseRepository(ChattyDbContext dbContext)
   {
      _dbContext = dbContext;
      _userAccounts = _dbContext.Set<T>();
   }

   public async Task InsertAsync(T entity)
   {
      await _userAccounts.AddAsync(entity);
      await _dbContext.SaveChangesAsync();
   }
}