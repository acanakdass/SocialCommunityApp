using Core.Domain.Concrete;
using Core.Domain.DTOs;
using Core.Domain.Models;
using Core.Paging;
using System.Threading.Tasks;

namespace Core.Business.Abstract
{
    public interface IBaseService<T> where T : Entity
    {
        Task<PageableListModel<T>> GetAllPaginatedAsync(PageRequest pageRequest);
        Task<T> GetByIdAsync(int id);
        Task<PageableListModel<T>> GetDynamicListAsync(DynamicPageableListRequestDto dynamicPageableListRequestDto);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);

    }
}
