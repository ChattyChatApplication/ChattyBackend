namespace Core.Entities;

public abstract class BaseEntity
{
   public Guid Id { get; init; } = Guid.NewGuid();

   public DateTime Created { get; init; }
   
   public DateTime Updated { get; set; }
}