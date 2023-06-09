﻿using Core.Entities;

namespace Domain.Contracts.Database.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
   public Task InsertAsync(T entity);
}