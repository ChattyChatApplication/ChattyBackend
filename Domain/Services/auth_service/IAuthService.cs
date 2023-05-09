using Core.ValueObjects.Account;
using Core.ValueObjects.Commons;

namespace Domain.Services;

public interface IAuthService
{
   public Task<AuthToken?> AuthenticateAsync(Username username, Password password);
   
   public Task<AuthToken?> AuthenticateAsync(Email email, Password password);
}