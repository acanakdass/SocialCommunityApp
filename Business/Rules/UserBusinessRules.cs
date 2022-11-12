using Core.BusinessRules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class UserBusinessRules : BusinessRulesBase<User>
    {
        private readonly IUserRepository _repository;
        public UserBusinessRules(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }
        public async Task AssureThatUserWithEmailNotExists(string email)
        {
            var result = await _repository.GetAsync(x => x.Email== email);
            if (result != null) throw new BusinessException($"{typeof(User).Name} with email:{email} already exists!");
        }
        public async Task AssureThatUserWithNicknameNotExists(string nickname)
        {
            var result = await _repository.GetAsync(x => x.NickName == nickname);
            if (result != null) throw new BusinessException($"{typeof(User).Name} with nickname:{nickname} already exists!");
        }
        public async Task AssureThatUserWithPhoneNumberNotExists(string phoneNumber)
        {
            var result = await _repository.GetAsync(x => x.PhoneNumber == phoneNumber);
            if (result != null) throw new BusinessException($"{typeof(User).Name} with phone number:{phoneNumber} already exists!");
        }
    }
}
