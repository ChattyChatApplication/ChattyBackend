namespace Core.Entities;

public abstract class BaseEntity
{
   public Guid Id { get; init; } = Guid.NewGuid();

   public DateTime Inserted { get; set; }
   
   public DateTime Updated { get; set; }
}