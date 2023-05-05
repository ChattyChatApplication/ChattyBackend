﻿namespace Core.Entities;

public abstract class BaseEntity
{
   public Guid Id { get; init; }

   public DateTime Created { get; init; }
   
   public DateTime Updated { get; set; }

   private protected BaseEntity(Guid id)
   {
      Id = id;
   }
}