using Domain.Contracts.Database.Repositories;

namespace Domain.Contracts.Database;

public interface IChattyDbContext
{
   public IUserAccountRepository UserAccountRepository();
   public IUserProfileRepository UserProfileRepository();
   
   public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}