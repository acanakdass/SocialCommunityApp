using Core.Business.Abstract;
using Core.Utilities.Results.Abstract;
using Domain.DTOs.User;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService : IBaseService<User>
    {
        Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(int userId);
        //Task<List<User>> GetAllWithRoles();

        Task<IDataResult<User>> GetByMailAsync(string email);
        Task<bool> AddRoleToUserAsync(AddRoleToUserDto addRoleToUserDto);
    }
}
