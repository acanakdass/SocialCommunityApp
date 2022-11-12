using Core.Repository.Concrete;
using Domain.Entities;
using Repository.Abstract;
using Repository.Contexts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Repository.Concrete
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        private readonly BaseDbContext _context;
        public OperationClaimRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<OperationClaim>> GetAllByUserId(int userId)
        {
            var claims = (from user in _context.Users
                          join userOperationClaims in _context.UserOperationClaims on user.Id equals userOperationClaims.UserId
                          join operationClaim in _context.OperationClaims on userOperationClaims.OperationClaimId equals operationClaim.Id
                          where user.Id == userId
                          select new OperationClaim
                          {
                              Id = operationClaim.Id,
                              Name = operationClaim.Name,
                              CreatedDate = operationClaim.CreatedDate,
                              UpdatedDate = operationClaim.UpdatedDate
                          }).ToList();

            return claims;
        }
    }
}