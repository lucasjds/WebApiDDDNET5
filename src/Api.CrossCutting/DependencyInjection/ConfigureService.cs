using Domain.Interfaces.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.DependencyInjection
{
  public class ConfigureService
  {
    public static void ConfigureDependenciesServices(IServiceCollection serviceCollection)
    {
      serviceCollection.AddTransient<IUserService, UserService>();
      serviceCollection.AddTransient<ILoginService, LoginService>();
    }
  }
}
