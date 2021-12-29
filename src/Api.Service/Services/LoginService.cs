using Domain.Entities;
using Domain.Interfaces.Services.Users;
using Domain.Repository;
using System.Threading.Tasks;

namespace Service.Services
{
  public class LoginService : ILoginService
  {
    private IUserRepository _repository;

    public LoginService(IUserRepository repository)
    {
      _repository = repository;
    }

    public async Task<object> FindByLogin(UserEntity user)
    {
      if(user != null && !string.IsNullOrWhiteSpace(user.Email))
      {
        return await _repository.FindByLogin(user.Email);
      }
      return null;
    }

  }
}
