using Core.Entities;
using Core.ValueObjects.Account;
using Domain.Contracts.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.Repositories;

public class UserAccountRepository : BaseRepository<UserAccount>, IUserAccountRepository
{
   public UserAccountRepository(ChattyDbContext dbContext) : base(dbContext)
   {
   }

   public async Task<bool> IsUsernameExistAsync(Username username)
   {
      var matchingUsername = await DataAccess
         .SingleOrDefaultAsync(uac => uac.Username == username);

      return matchingUsername is not null;
   }

   public async Task<bool> IsEmailExistAsync(Email email)
   {
      var matchingEmail = await DataAccess
         .SingleOrDefaultAsync(uac => uac.Email == email);

      return matchingEmail is not null;
   }
}