using Core.Entities;
using Domain.Contracts.Database.Repositories;

namespace Infra.Database.Repositories;

public class UserProfileRepository : BaseRepository<UserProfile>, IUserProfileRepository
{
   public UserProfileRepository(ChattyDbContext dbContext) : base(dbContext)
   {
   }
}