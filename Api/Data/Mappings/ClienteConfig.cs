using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.nome)
                   .HasMaxLength(70)
                   .HasColumnName("nome")
                   .HasColumnOrder(2);

            builder.Property(b => b.documento)
                   .HasColumnName("documento")
                   .HasColumnOrder(3);
            builder.HasIndex(b => b.documento)
                   .IsUnique();

            //Base Model
            builder.Property(b => b.data_criacao)
                   .HasColumnName("data_criacao")
                   .HasColumnOrder(100);
            builder.Property(b => b.data_edicao)
                   .HasColumnName("data_edicao")
                   .HasColumnOrder(101);

        }
    }
}
