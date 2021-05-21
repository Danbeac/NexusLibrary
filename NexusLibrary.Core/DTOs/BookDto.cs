using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexusLibrary.Core.DTOs
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Gender { get; set; }
        public int? PageNumber { get; set; }
        public string EditorialName { get; set; }
        public string AuthorName { get; set; }

    }
}
