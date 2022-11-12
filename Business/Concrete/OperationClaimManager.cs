using AutoMapper;
using Business.Abstract;

using Core.Business.Concrete;
using Core.Repository.Abstract;
using Domain.Entities;
using Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : BaseManager<OperationClaim>, IOperationClaimService
    {
        private readonly IOperationClaimRepository _repository;
        public OperationClaimManager(IOperationClaimRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<List<OperationClaim>> GetAllByUserId(int userId)
        {
            var result = await _repository.GetAllByUserId(userId);
            return result;
        }
    }
}