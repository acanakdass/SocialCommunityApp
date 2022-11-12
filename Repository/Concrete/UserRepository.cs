using Core.Repository.Concrete;
using Domain.Entities;
using Repository.Abstract;
using Repository.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Repository.Concrete
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        private readonly BaseDbContext _context;
        public UserRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OperationClaim>> GetClaimsAsync(int userId)
        {
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == userId
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
