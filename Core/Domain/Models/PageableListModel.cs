using Core.Domain.Concrete;
using Core.Paging.Concrete;
using System.Collections.Generic;

namespace Core.Domain.Models
{

    public class PageableListModel<TEntity> : BasePageableModel where TEntity : Entity
    {
        public IList<TEntity> Items { get; set; }
    }
}
