using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.descricao)
                   .HasMaxLength(50)
                   .HasColumnName("descricao")
                   .HasColumnOrder(2);

            builder.Property(b => b.valor)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("valor")
                   .HasColumnOrder(3);

            builder.Property(b => b.categoria_id)
                   .HasColumnName("categoria_id")
                   .HasColumnOrder(4);
            builder.HasOne(b => b.categoria)
                   .WithMany(b => b.produtos)
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
