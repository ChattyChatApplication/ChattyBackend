using Core.ValueObjects.Account;

namespace Domain.Services;

public interface IPasswordHashService
{
   public PasswordHash Hash(Password password);
}