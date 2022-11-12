using AutoMapper;
using Business.Abstract;

using Core.Business.Concrete;
using Domain.Entities;
using Repository.Abstract;

namespace Business.Concrete
{
    public class CommentManager : BaseManager<Comment>, ICommentService
    {
        public CommentManager(ICommentRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}