using Core.Repository.Abstract;
using Domain.Entities;

namespace Repository.Abstract
{
    public interface ICommentRepository : IAsyncRepository<Comment>, IRepository<Comment>
    {
    }
}
