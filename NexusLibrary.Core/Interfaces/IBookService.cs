using NexusLibrary.Core.DTOs;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Interfaces
{
    public interface IBookService
    {
        Task AddBook(BookDto bookDto);
    }
}
