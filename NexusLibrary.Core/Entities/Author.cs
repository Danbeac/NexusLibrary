using System;
using System.Collections.Generic;

namespace NexusLibrary.Core.Entities
{
    public partial class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirthday { get; set; }
        public string CityBirth { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
