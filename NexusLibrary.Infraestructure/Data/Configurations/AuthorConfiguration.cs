using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusLibrary.Core.Entities;

namespace NexusLibrary.Infraestructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Autores");

            builder.HasKey(e => e.AuthorId)
                    .HasName("PK__Autores__F58AE929A1678934");

            builder.Property(e => e.AuthorId)
                .HasColumnName("AutorId");

            builder.Property(e => e.FullName)
                    .HasColumnName("NombreCompleto")
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

            builder.Property(e => e.DateBirthday)
                .HasColumnName("FechaNacimiento")
                .HasColumnType("date");

            builder.Property(e => e.CityBirth)
                    .HasColumnName("CiudadProcedencia")
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .HasColumnName("Estado")
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasDefaultValueSql("('A')");

            builder.Property(e => e.DateCreation)
                .HasColumnName("FechaCreacion")
                .HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
        }
    }
}
