using System;
using System.Collections.Generic;

namespace NexusLibrary.Core.Entities
{
    public partial class Editorial
    {
        public Editorial()
        {
            Books = new HashSet<Book>();
        }

        public int EditorialId { get; set; }
        public string Name { get; set; }
        public string CorrespondenceAdress { get; set; }
        public string Phonenumber { get; set; }
        public string Email { get; set; }
        public int MaxBooksRegistered { get; set; }
        public string State { get; set; }
        public DateTime DateCreation { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
