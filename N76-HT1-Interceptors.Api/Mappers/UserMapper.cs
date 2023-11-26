using AutoMapper;
using N76_HT1_Interceptors.Api.Models.Dtos;
using N76_HT1_Interceptors.Domain.Entities;

namespace N76_HT1_Interceptors.Api.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}
