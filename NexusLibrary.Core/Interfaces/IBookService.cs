using NexusLibrary.Core.DTOs;
using NexusLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Interfaces
{
    public interface IBookService
    {
        Task AddBook(BookDto bookDto);
        Task<IEnumerable<BookEditorialDto>> GetBooksByEditorialName(string name);
    }
}
