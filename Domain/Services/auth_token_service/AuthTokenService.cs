using Core.Entities;

namespace Domain.Services;

public class AuthTokenService : IAuthTokenService
{
   public AuthToken CreateAuthToken(UserAccount userAccount)
   {
      // TODO implement logic here
      return new AuthToken(
         accessToken: "this is access token",
         refreshToken: "this is refresh token token"
      );
   }
}