namespace OnionApp.WebUI.Dtos.BlogDtos
{
    public class ResultLast3BlogsWithAuthorsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName { get; set; }
    }
}
