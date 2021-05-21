using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using NexusLibrary.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NexusLibrary.Infraestructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetById(int bookId)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.BookId == bookId);
        }

        public async Task<Book> GetByName(string bookName)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.Title == bookName);
        }

        public async Task Add(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }
    }
}
