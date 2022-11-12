using Core.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment:Entity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public User User { get; set; }
        public int UserId{ get; set; }
        public string TextContent { get; set; }
        public string ImagePath { get; set; }
        public int PostId { get; set; }
        [JsonIgnore]
        public Post Post { get; set; }
    }
}
