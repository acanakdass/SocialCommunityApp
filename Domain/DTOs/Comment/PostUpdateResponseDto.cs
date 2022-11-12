using System.Collections.Generic;

namespace Domain.DTOs.Comment
{
    public class PostUpdateResponseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<string> ImagePaths { get; set; }
        public string TextContent { get; set; }
    }

}
