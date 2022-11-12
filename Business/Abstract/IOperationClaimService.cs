using Core.Business.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOperationClaimService : IBaseService<OperationClaim>
    {
        Task<List<OperationClaim>> GetAllByUserId(int userId);
    }
}
