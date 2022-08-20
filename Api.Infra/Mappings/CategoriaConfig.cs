using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class CategoriaConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categoria");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.description)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("descricao");

            builder.HasMany(b => b.products)
                   .WithOne(b => b.category)
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
