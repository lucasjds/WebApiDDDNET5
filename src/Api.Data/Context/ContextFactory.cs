using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      var connectionString = "Data Source=127.0.0.1; User ID=root; Password=admin123; Initial Catalog=webapi_ddd; ";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
      return new MyContext(optionsBuilder.Options);
    }
  }
}
