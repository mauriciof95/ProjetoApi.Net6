using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class ClienteConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.name)
                   .HasMaxLength(70)
                   .HasColumnName("nome")
                   .HasColumnOrder(2);

            builder.Property(b => b.document)
                   .HasColumnName("documento")
                   .HasColumnOrder(3);
            builder.HasIndex(b => b.document)
                   .IsUnique();

            //Base Model
            builder.Property(b => b.created_at)
                   .HasColumnName("data_criacao")
                   .HasColumnOrder(100);
            builder.Property(b => b.updated_at)
                   .HasColumnName("data_edicao")
                   .HasColumnOrder(101);

        }
    }
}
