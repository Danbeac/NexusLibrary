using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using NexusLibrary.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Infraestructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetById(int authorId)
        {
            return await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == authorId);
        }

        public async Task Add(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }
    }
}
