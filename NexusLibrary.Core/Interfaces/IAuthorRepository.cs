using NexusLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> GetById(int authorId);
        Task Add(Author author);
    }
}
