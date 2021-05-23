using NexusLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetById(int bookId);
        Task<Book> GetByName(string bookName);
        Task Add(Book book);
        Task<IEnumerable<Book>> BooksByEditorialId(int editorialId);
    }
}
