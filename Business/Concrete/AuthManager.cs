using AutoMapper;
using Business.Abstract;
using Business.Rules;
using Business.Security.JWT;
using Core.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Domain.DTOs.Auth;
using Domain.DTOs.User;
using Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _userBusinessRules;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
        }

        public async Task<IDataResult<User>> Register(UserRegisterDto userRegisterDto)
        {
            await _userBusinessRules.AssureThatUserWithEmailNotExists(userRegisterDto.Email);

            string passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var userEntity = _mapper.Map<User>(userRegisterDto);
            userEntity.PasswordHash = passwordHash;
            userEntity.PasswordSalt = passwordSalt;

            await _userService.CreateAsync(userEntity);
            return new SuccessDataResult<User>(userEntity, Messages.UserRegisteredSuccessfully());
        }

        public async Task<IDataResult<User>> Login(UserLoginDto userLoginDto)
        {
            //await _userBusinessRules.AssureThatUserExistsByEmail(userLoginDto.Email);
            var userToCheck = await _userService.GetByMailAsync(userLoginDto.Email);
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.LoginFailed());
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.UserLoggedInSuccessfully());
        }


        private async Task<IResult> IsUserExist(string email)
        {
            var user = await _userService.GetByMailAsync(email);
            if (user.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists());
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<LoginResponseDto>> CreateAccessToken(User user)
        {
            var claims = await _userService.GetClaimsAsync(user.Id);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            var result = new LoginResponseDto
            {
                Expiration = accessToken.Expiration,
                Roles = claims.Data,
                Token = accessToken.Token
            };
            return new SuccessDataResult<LoginResponseDto>(result, Messages.AccessTokenCreated());
        }
    }
}
