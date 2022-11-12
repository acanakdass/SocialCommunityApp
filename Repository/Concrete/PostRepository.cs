using Core.Repository.Concrete;
using Domain.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Repository.Abstract;
using Repository.Contexts;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class PostRepository : EfRepositoryBase<Post, BaseDbContext>, IPostRepository
    {
        private readonly BaseDbContext _context;
        public PostRepository(BaseDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Post> GetByIdIncludedAsync(int id)
        {
            var data = await _context.Set<Post>().Where(x=>x.Id==id).Include(x => x.Comments).Include(x => x.User).FirstOrDefaultAsync();
            return data;
        }
    }
}