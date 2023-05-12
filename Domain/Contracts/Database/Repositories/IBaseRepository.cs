using Core.Entities;

namespace Domain.Contracts.Database.Repositories;

public interface IBaseRepository<in T> where T : BaseEntity
{
   public Task InsertAsync(T entity);
}