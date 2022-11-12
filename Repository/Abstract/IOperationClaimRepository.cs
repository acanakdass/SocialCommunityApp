using Core.Repository.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
        Task<List<OperationClaim>> GetAllByUserId(int userId);

    }
}
