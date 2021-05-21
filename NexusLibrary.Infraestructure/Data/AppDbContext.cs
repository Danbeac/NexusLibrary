using Microsoft.EntityFrameworkCore;
using NexusLibrary.Core.Entities;
using NexusLibrary.Infraestructure.Data.Configurations;

namespace NexusLibrary.Infrastructure.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new EditorialConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
    }
}
