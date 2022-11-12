using AutoMapper;
using Business.Abstract;

using Core.Business.Concrete;
using Domain.Entities;
using Repository.Abstract;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PostManager : BaseManager<Post>, IPostService
    {
        private readonly IPostRepository _repository;
        public PostManager(IPostRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }
        public async Task<Post> GetByIdIncludedAsync(int id)
        {
            var result = await _repository.GetByIdIncludedAsync(id);
            return result;
        }
    }
}