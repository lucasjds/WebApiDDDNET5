﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Users
{
  public interface IUserService
  {
    Task<UserEntity> Get(Guid id);
    Task<IEnumerable<UserEntity>> GetAll();
    Task<UserEntity> Post(UserEntity userEntity);
    Task<UserEntity> Put(UserEntity user);
    Task<bool> Delete(Guid id);
  }
}