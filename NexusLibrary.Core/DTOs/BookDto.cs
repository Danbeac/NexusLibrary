namespace NexusLibrary.Core.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int? PageNumber { get; set; }
        public string NameEditorial { get; set; }
        public string NameAuthor { get; set; }

    }
}
