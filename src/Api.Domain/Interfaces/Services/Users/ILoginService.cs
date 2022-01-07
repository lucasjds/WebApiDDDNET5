using Domain.Dtos;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Users
{
  public interface ILoginService
  {
    Task<object> FindByLogin(LoginDto user);
  }
}
