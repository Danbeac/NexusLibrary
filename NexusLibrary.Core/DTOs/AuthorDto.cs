using System;

namespace NexusLibrary.Core.DTOs
{
    public class AuthorDto
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
        public DateTime DateBirthday { get; set; }
        public string CityBirth { get; set; }
        public string Email { get; set; }
    }
}
