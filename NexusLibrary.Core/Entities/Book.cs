using System;

namespace NexusLibrary.Core.Entities
{
    public partial class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int? PageNumber { get; set; }
        public int EditorialId { get; set; }
        public int AuthorId { get; set; }
        public string State { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual Author Author { get; set; }
        public virtual Editorial Editorial { get; set; }
    }
}
