using OnionApp.WebUI.Dtos.BlogDtos;
using OnionApp.WebUI.Dtos.CommentDtos;

namespace OnionApp.WebUI.Models
{
    public class BlogDetailViewModel
    {
        public int BlogId { get; set; }
        public ResultGetBlogByIdDto Blog { get; set; }
        public ResultCommentCountDto CommentCount { get; set; }
    }
}
