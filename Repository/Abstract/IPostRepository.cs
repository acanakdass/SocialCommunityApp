using Core.Repository.Abstract;
using Domain.Entities;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IPostRepository : IAsyncRepository<Post>, IRepository<Post>
    {
        Task<Post> GetByIdIncludedAsync(int id);
    }
}
