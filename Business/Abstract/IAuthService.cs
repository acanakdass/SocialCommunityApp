using Business.Security.JWT;
using Core.Utilities.Results.Abstract;
using Domain.DTOs.Auth;
using Domain.DTOs.User;
using Domain.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto);
        Task<IDataResult<User>> Login(UserLoginDto userLoginDto);
        Task<IDataResult<LoginResponseDto>> CreateAccessToken(User user);
    }
}
