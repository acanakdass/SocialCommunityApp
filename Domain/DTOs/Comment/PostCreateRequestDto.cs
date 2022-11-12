using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Comment
{
    public class PostCreateRequestDto
    {
        public int UserId { get; set; }
        public List<string> ImagePaths { get; set; }
        public string TextContent { get; set; }
    }
}
