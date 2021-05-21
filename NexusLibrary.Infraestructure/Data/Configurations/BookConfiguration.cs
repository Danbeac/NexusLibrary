using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusLibrary.Core.Entities;

namespace NexusLibrary.Infraestructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Libros");

            builder.HasKey(e => e.BookId);

            builder.Property(e => e.BookId)
                .HasColumnName("LibroId");

            builder.Property(e => e.Title)
                .HasColumnName("Titulo")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(e => e.Year);

            builder.Property(e => e.Gender)
                .HasColumnName("Genero")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PageNumber)
                .HasColumnName("NumeroPaginas");

            builder.Property(e => e.State)
                .HasColumnName("Estado")
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.AuthorId)
                .HasColumnName("AutorId");

            builder.Property(e => e.EditorialId);

            builder.Property(e => e.DateCreation)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.Author)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libros__AutorId__1A14E395");

            builder.HasOne(d => d.Editorial)
                .WithMany(p => p.Books)
                .HasForeignKey(d => d.EditorialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Libros__Editoria__1B0907CE");
        }
    }
}
