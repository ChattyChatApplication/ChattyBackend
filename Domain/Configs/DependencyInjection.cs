using Domain.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Configs;

public static class DependencyInjection
{
   public static void AddDomain(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddServices();
   }

   private static void AddServices(this IServiceCollection services)
   {
      services.AddScoped<IUserAccountFactory, UserAccountFactory>();
      services.AddScoped<IPasswordHashService, PasswordHashService>();
      services.AddScoped<IAuthService, AuthService>();
   }
}