using NexusLibrary.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Core.Interfaces
{
    public interface IEditorialRepository
    {
        Task<IEnumerable<Editorial>> GetAll();
        Task<Editorial> GetById(int editorialId);
        Task Add(Editorial editorial);
    }
}
