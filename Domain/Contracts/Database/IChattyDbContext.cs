namespace Domain.Contracts.Database;

public interface IChattyDbContext
{
   public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}