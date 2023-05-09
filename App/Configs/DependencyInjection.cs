using App.Features;
using Domain.Contracts.Database;
using Domain.Contracts.Database.Repositories;
using FluentValidation;
using Infra.Database;
using Infra.Database.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace App.Configs;

public static class DependencyInjection
{
   public static void AddApp(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddRepositories();
      services.AddFeatures();
      services.AddValidators();
      services.AddContracts();
   }

   private static void AddRepositories(this IServiceCollection services)
   {
      services.AddScoped<IUserAccountRepository, UserAccountRepository>();
   }
   
   private static void AddValidators(this IServiceCollection services)
   {
      services.AddScoped<IValidator<SignUpRequestDto>, SignUpRequestValidator>();
   }

   private static void AddFeatures(this IServiceCollection services)
   {
      services.AddScoped<ISignUpFeat, SignUpFeat>();
   }
   
   private static void AddContracts(this IServiceCollection services)
   {
      services.AddScoped<IChattyDbContext, ChattyDbContext>();
   }
}