using System;
namespace PruebaTecnica.Core.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
