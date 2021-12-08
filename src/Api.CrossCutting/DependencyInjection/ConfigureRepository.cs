using Data.Context;
using Data.Repository;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.DependencyInjection
{
  public class ConfigureRepository
  {
    public static void ConfigureDependenciesRepositories(IServiceCollection serviceCollection)
    {
      var conn = "Data Source=127.0.0.1; User ID=root; Password=admin123; Initial Catalog=webapi_ddd; ";
      serviceCollection.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
      serviceCollection.AddDbContext<MyContext>(
                opt => opt.UseMySql(conn, ServerVersion.AutoDetect(conn))
            );
    }
  }
}
