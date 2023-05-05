using Infra.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Configs;

public static class DependencyInjection
{
   public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddChattyDbContext(configuration);
   }
   
   private static void AddChattyDbContext(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<ChattyDbContext>(
         options => options.UseNpgsql(configuration["ChattyDbConnectionString"]));
   }
}