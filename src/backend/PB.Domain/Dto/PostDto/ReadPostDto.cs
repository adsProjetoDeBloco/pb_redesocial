using PB.Domain.Entities;

namespace PB.Domain.Dto.PostDto
{
    public class ReadPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostText { get; set; }
        public string UserName { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}