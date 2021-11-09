using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog=webapi_ddd; Integrated Security=True;";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString);
      return new MyContext(optionsBuilder.Options);
    }
  }
}
