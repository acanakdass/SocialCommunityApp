using AutoMapper;
using Business.Abstract;
using Business.Rules;
using Core.Business.Concrete;
using Core.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Domain.DTOs.User;
using Domain.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : BaseManager<User>, IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IOperationClaimService _operationClaimService;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly UserBusinessRules _userBusinessRules;
        private readonly IMapper _mapper;


        public UserManager(IUserRepository repository, IOperationClaimService operationClaimService, UserBusinessRules userBusinessRules, IMapper mapper, IUserOperationClaimRepository userOperationClaimRepository) : base(repository, mapper)
        {
            _repository = repository;
            _operationClaimService = operationClaimService;
            _userBusinessRules = userBusinessRules;
            _mapper = mapper;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        //public async Task<IResult> DeleteAsync(int id)
        //{
        //    //business rules
        //    await _userBusinessRules.AssureThatEntityExistsById(id);

        //    var res = await _repository.DeleteAsync(id);
        //    if (res == 1)
        //        return new SuccessResult(Messages.Deleted("User"));
        //    return new ErrorResult(Messages.FailedDelete("User"));
        //}

        public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync(int userId)
        {
            var claims = await _repository.GetClaimsAsync(userId);
            return new SuccessDataResult<List<OperationClaim>>(claims, Messages.Listed("Claims"));
        }

        public async Task<IDataResult<User>> GetByMailAsync(string email)
        {
            var user = await _repository.GetAsync(u => u.Email == email);
            return new SuccessDataResult<User>(user, Messages.Listed("User"));
        }

        public async Task<bool> AddRoleToUserAsync(AddRoleToUserDto addRoleToUserDto)
        {
            //business rules
            //await _operationClaimBusinessRules.AssureThatOperationClaimExistsById(operationClaimId);
            await _userBusinessRules.AssureThatEntityExistsById(addRoleToUserDto.UserId);
            var userOpClaim = _mapper.Map<UserOperationClaim>(addRoleToUserDto);
            var result = await _userOperationClaimRepository.AddAsync(userOpClaim);
            return result!=null;
        }

        //public async Task<List<User>> GetAllWithRoles()
        //{
            
        //    foreach (var user in usersList)
        //    {
        //        user.
        //    }
        //    var res = await _operationClaimService.GetAllByUserId()
        //}
    }
}
