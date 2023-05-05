using Core.Entities;
using Core.ValueObjects.Account;

namespace Domain.Services;

public interface IUserAccountFactory
{
   public Task<UserAccount> CreateUserAccountAsync(Username username, Email email, Password password);
}