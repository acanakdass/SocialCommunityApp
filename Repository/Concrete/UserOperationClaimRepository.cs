using Core.Repository.Concrete;
using Domain.Entities;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete
{
    public class UserOperationClaimRepository : EfRepositoryBase<UserOperationClaim, BaseDbContext>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}