using AutoMapper;
using Core.Business.Abstract;
using Core.Domain.Concrete;
using Core.Domain.DTOs;
using Core.Domain.Models;
using Core.Paging;
using Core.Repository.Abstract;
using System.Threading.Tasks;

namespace Core.Business.Concrete
{
    public class BaseManager<TEntity> : IBaseService<TEntity> where TEntity : Entity
    {
        private readonly IAsyncRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public BaseManager(IAsyncRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var result = await _repository.AddAsync(entity);
            return result;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            var result = await _repository.DeleteAsync(entity);
            return result;
        }

        public async Task<PageableListModel<TEntity>> GetAllPaginatedAsync(PageRequest pageRequest)
        {
            var result = await _repository.GetListAsync(index: pageRequest.Page, size: pageRequest.PageSize);
            var response = _mapper.Map<PageableListModel<TEntity>>(result);
            return response;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var result = await _repository.GetAsync(x => x.Id == id);
            return result;
        }
     

        public async Task<PageableListModel<TEntity>> GetDynamicListAsync(
            DynamicPageableListRequestDto dynamicPageableListRequestDto)
        {
            var result = await _repository.GetListByDynamicAsync(
                dynamicPageableListRequestDto.Dynamic,
                size: dynamicPageableListRequestDto.PageRequest.PageSize,
                index: dynamicPageableListRequestDto.PageRequest.Page);
            var response = _mapper.Map<PageableListModel<TEntity>>(result);
            return response;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var result = await _repository.UpdateAsync(entity);
            return result;
        }
    }
}