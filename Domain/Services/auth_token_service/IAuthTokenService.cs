using Core.Entities;

namespace Domain.Services;

public interface IAuthTokenService
{
   public AuthToken CreateAuthToken(UserAccount userAccount);
}