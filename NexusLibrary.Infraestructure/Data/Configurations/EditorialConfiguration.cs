using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexusLibrary.Core.Entities;

namespace NexusLibrary.Infraestructure.Data.Configurations
{
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.ToTable("Editoriales");

            builder.HasKey(e => e.EditorialId)
                    .HasName("PK__Editoria__D54C82EE5FCD8F42");

            builder.Property(e => e.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.CorrespondenceAdress)
                .HasColumnName("DireccionCorrespondencia")
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Phonenumber)
                .HasColumnName("Telefono")
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.MaxBooksRegistered)
                .HasColumnName("MaxLibrosRegistrados")
                .IsRequired();

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
