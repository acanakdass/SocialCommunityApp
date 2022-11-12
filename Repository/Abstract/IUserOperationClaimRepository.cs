using Core.Repository.Abstract;
using Domain.Entities;

namespace Repository.Abstract
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
    }
}
