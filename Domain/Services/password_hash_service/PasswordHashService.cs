using Core.ValueObjects.Account;

namespace Domain.Services;

public class PasswordHashService : IPasswordHashService
{
   public PasswordHash Hash(Password password)
   {
      // TODO implement hash logic
      return new PasswordHash("hahahaha");
   }
}