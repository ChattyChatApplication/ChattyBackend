using Core.Entities;
using Domain.Contracts.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
   protected readonly DbSet<T> DataAccess;

   protected BaseRepository(ChattyDbContext dbContext)
   {
      DataAccess = dbContext.Set<T>();
   }

   public async Task InsertAsync(T entity)
   {
      await DataAccess.AddAsync(entity);
   }
}