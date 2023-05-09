using Core.Entities;
using Core.ValueObjects.Account;
using Core.ValueObjects.Commons;

namespace Domain.Services;

public interface IUserAccountFactory
{
   public Task<UserAccount> CreateUserAccountAsync(Username username, Email email, Password password);
}