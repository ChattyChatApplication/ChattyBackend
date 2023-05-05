using Core.Entities;
using Core.ValueObjects.Account;

namespace Domain.Contracts.Database.Repositories;

public interface IUserAccountRepository : IBaseRepository<UserAccount>
{
   public bool IsUsernameExistAsync(Username email);

   public bool IsEmailExistAsync(Email email);
}