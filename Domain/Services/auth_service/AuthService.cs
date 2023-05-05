using Core.ValueObjects.Account;

namespace Domain.Services;

public class AuthService : IAuthService
{
   public Task<AuthToken?> AuthenticateAsync(Username username, Password password)
   {
      throw new NotImplementedException();
   }

   public Task<AuthToken?> AuthenticateAsync(Email email, Password password)
   {
      throw new NotImplementedException();
   }
}