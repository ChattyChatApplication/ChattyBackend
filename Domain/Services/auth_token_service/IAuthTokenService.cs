namespace Domain.Services;

public interface IAuthTokenService
{
   public AuthToken CreateAuthToken(Guid accountId);
}