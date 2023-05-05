using Core.Entities;
using Core.ValueObjects.Account;

namespace Domain.Contracts.Database.Repositories;

public interface IUserAccountRepository : IBaseRepository<UserAccount>
{
   public Task<bool> IsUsernameExistAsync(Username username);

   public Task<bool> IsEmailExistAsync(Email email);
}