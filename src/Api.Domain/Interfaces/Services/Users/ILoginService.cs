using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Users
{
  public interface ILoginService
  {
    Task<object> FindByLogin(string email);
  }
}
