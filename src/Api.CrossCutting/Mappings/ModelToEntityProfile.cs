using AutoMapper;
using Domain.Entities;
using Domain.Models;

namespace Api.CrossCutting.Mappings
{
  public class ModelToEntityProfile : Profile
  {
    public ModelToEntityProfile()
    {
      CreateMap<UserModel, UserEntity>()
         .ReverseMap();
    }
  }
}
