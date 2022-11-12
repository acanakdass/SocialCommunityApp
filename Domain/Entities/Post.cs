using Core.Domain.Concrete;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Post: Entity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<string> ImagePaths { get; set; }
        public string TextContent { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}