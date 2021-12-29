using Domain.Entities;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Users
{
  public interface ILoginService
  {
    Task<object> FindByLogin(UserEntity user);
  }
}
