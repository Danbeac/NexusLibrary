using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using NexusLibrary.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Infraestructure.Repositories
{
    public class EditorialRepository : IEditorialRepository
    {
        private readonly AppDbContext _context;
        public EditorialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Editorial>> GetAll()
        {
            return await _context.Editorials.ToListAsync();
        }

        public async Task<Editorial> GetById(int editorialId)
        {
            return await _context.Editorials.FirstOrDefaultAsync(x => x.EditorialId == editorialId);
        }

        public async Task<Editorial> GetByName(string nameEditorial)
        {
            return await _context.Editorials.FirstOrDefaultAsync(x => x.Name == nameEditorial);
        }

        public async Task Add(Editorial editorial)
        {
            _context.Editorials.Add(editorial);
            await _context.SaveChangesAsync();
        }
    }
}
