namespace Domain.Services;

public readonly struct AuthToken
{
   public AuthToken(string accessToken, string refreshToken)
   {
      AccessToken = accessToken;
      RefreshToken = refreshToken;
   }

   public string AccessToken { get; init; }
   public string RefreshToken { get; init; }
}