using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Core.Interfaces;
using NexusLibrary.Infrastructure.Data;
using System;
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

        public Task<Book> GetById(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task Add(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
