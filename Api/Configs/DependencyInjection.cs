using Domain.Configs;
using Infra.Configs;

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
      services.AddDomain(configuration);
   }
}