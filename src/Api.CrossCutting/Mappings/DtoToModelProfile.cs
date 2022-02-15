using Api.Domain.Dtos.User;
using AutoMapper;
using Domain.Models;

namespace CrossCutting.Mappings
{
  public class DtoToModelProfile : Profile
  {
    public DtoToModelProfile()
    {
      CreateMap<UserModel, UserDto>().ReverseMap();
    }
  }
}
