using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using NexusLibrary.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
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
            book.DateCreation = DateTime.Now;
            book.State = "A";
            book.AuthorId = 1;
            book.EditorialId = 5;
            book.Editorial = null;

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> BooksByEditorialId(int editorialId)
        {
            return await _context.Books.Where(x => x.EditorialId == editorialId).ToListAsync();
        }
    }
}
