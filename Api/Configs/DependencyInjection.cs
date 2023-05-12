using App.Features;
using Domain.Contracts.Database;
using Domain.Contracts.Database.Repositories;
using Domain.Services;
using FluentValidation;
using Infra.Database;
using Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Configs;

public static class DependencyInjection
{
   public static void AddAllDependencies(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddControllers();
      // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();

      services.AddInfra(configuration);
      services.AddDomain();
      services.AddApp();

      services.AddDomainInfraContract();
   }

   private static void AddInfra(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<ChattyDbContext>(
         options => options.UseNpgsql(configuration["ChattyDbConnectionString"]));
   }

   private static void AddDomain(this IServiceCollection services)
   {
      // services
      services.AddScoped<IUserAccountFactory, UserAccountFactory>();
      services.AddScoped<IPasswordHashService, PasswordHashService>();
      services.AddScoped<IAuthService, AuthService>();
      services.AddScoped<IAuthTokenService, AuthTokenService>();
   }

   private static void AddApp(this IServiceCollection services)
   {
      services.AddScoped<IValidator<SignUpRequestDto>, SignUpRequestDtoValidator>();

      services.AddScoped<ISignUpFeat, SignUpFeat>();
   }

   private static void AddDomainInfraContract(this IServiceCollection services)
   {
      services.AddScoped<IChattyDbContext, ChattyDbContext>();

      services.AddScoped<IUserAccountRepository, UserAccountRepository>();
   }
}