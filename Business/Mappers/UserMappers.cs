using AutoMapper;
using Core.Domain.Models;
using Core.Paging.Abstract;
using Domain.DTOs.User;
using Domain.Entities;

namespace Business.Mappers
{
    public class UserMappers : Profile
    {
        public UserMappers()
        {

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<IPaginate<User>, PageableListModel<User>>().ReverseMap();
            CreateMap<UserRegisterDto, User>().ReverseMap();
            CreateMap<AddRoleToUserDto, UserOperationClaim>().ReverseMap();
        }
    }
}