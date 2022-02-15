﻿using Api.Domain.Dtos.User;
using AutoMapper;
using Domain.Entities;

namespace CrossCutting.Mappings
{
  public class EntityToDtoProfile : Profile
  {
    public EntityToDtoProfile()
    {
      CreateMap<UserDto, UserEntity>().ReverseMap();
      CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();
      CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap();
    }
  }
}
