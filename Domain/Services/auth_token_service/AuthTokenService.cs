using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Services;

public class AuthTokenService : IAuthTokenService
{
   private const int AccessTokenExpireMinute = 20;
   private const int RefreshTokenExpireDay = 30;
   
   private readonly IConfiguration _configuration;

   public AuthTokenService(IConfiguration configuration)
   {
      _configuration = configuration;
   }

   public AuthToken CreateAuthToken(Guid accountId)
   {
      var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSecret"]!)),
         SecurityAlgorithms.HmacSha256);
      
      var accessTokenDescriptor = new SecurityTokenDescriptor()
      {
         Claims = new Dictionary<string, object>() { {AuthTokenClaimNames.AccountId, accountId} },
         Expires = DateTime.Now.AddMinutes(AccessTokenExpireMinute),
         SigningCredentials = signingCredentials
      };
      
      var refreshTokenDescriptor = new SecurityTokenDescriptor()
      {
         Claims = new Dictionary<string, object>() { {AuthTokenClaimNames.AccountId, accountId} },
         Expires = DateTime.Now.AddDays(RefreshTokenExpireDay),
         SigningCredentials = signingCredentials
      };

      var handler = new JwtSecurityTokenHandler();
      
      return new AuthToken(
         accessToken: handler.CreateEncodedJwt(accessTokenDescriptor),
         refreshToken: handler.CreateEncodedJwt(refreshTokenDescriptor)
      );
   }
}