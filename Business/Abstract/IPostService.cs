using Core.Business.Abstract;
using Domain.Entities;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPostService : IBaseService<Post>
    {
        Task<Post> GetByIdIncludedAsync(int id);

    }
}
