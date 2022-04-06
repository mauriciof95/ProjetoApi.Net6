using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.descricao)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("descricao");

            builder.HasMany(b => b.produtos)
                   .WithOne(b => b.categoria)
                   .HasForeignKey(b => b.categoria_id);

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
