using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
  public class MyContext : DbContext
  {
    public DbSet<UserEntity> Users { get; set; }

    public MyContext(DbContextOptions<MyContext> contextOptions) : base(contextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder model)
    {
      base.OnModelCreating(model);
      model.Entity<UserEntity>(new UserMap().Configure);

    }
  }
}
