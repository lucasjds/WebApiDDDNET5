using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
  public class UserService : IUserService
  {
    private readonly IRepository<UserEntity> _repository;
    public UserService(IRepository<UserEntity> repository)
    {
      _repository = repository;
    }

    public async Task<bool> Delete(Guid id)
    {
      return await _repository.DeleteAsync(id);
    }

    public async Task<UserEntity> Get(Guid id)
    {
      return await _repository.SelectAsync(id);
    }

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
      return await _repository.SelectAsync();
    }

    public async Task<UserEntity> Post(UserEntity userEntity)
    {
      return await _repository.InsertAsync(userEntity);
    }

    public async Task<UserEntity> Put(UserEntity user)
    {
      return await _repository.UpdateAsync(user);
    }
  }
}
