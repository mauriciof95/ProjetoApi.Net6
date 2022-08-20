using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class ProdutoConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.description)
                   .HasMaxLength(50)
                   .HasColumnName("descricao")
                   .HasColumnOrder(2);

            builder.Property(b => b.price)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnName("valor")
                   .HasColumnOrder(3);

            builder.Property(b => b.category_id)
                   .HasColumnName("categoria_id")
                   .HasColumnOrder(4);
            builder.HasOne(b => b.category)
                   .WithMany(b => b.products)
                   .HasForeignKey(b => b.category_id);

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
