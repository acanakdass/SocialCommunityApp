using Core.Repository.Concrete;
using Domain.Entities;
using Repository.Abstract;
using Repository.Contexts;

namespace Repository.Concrete
{
    public class CommentRepository : EfRepositoryBase<Comment, BaseDbContext>, ICommentRepository
    {
        public CommentRepository(BaseDbContext context) : base(context)
        {
        }
    }
}