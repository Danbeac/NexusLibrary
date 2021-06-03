using NexusLibrary.Core.DTOs;
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
