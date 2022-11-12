using Core.Repository.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
    {
        Task<List<OperationClaim>> GetClaimsAsync(int userId);
    }
}
