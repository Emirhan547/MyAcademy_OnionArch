namespace OnionApp.WebUI.Dtos.CommentDtos
{
    public class ResultGetCommentWithBlogDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public int BlogId { get; set; }
    }
}
