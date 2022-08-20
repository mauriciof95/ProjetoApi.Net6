using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class MovimentacaoEstoqueConfig : IEntityTypeConfiguration<StockMoviment>
    {
        public void Configure(EntityTypeBuilder<StockMoviment> builder)
        {
            builder.ToTable("movimentacao_estoque");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.moviment_reason)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("motivo_movimento");

            builder.Property(b => b.moviment_type)
                   .HasMaxLength(50)
                   .HasColumnOrder(3)
                   .HasColumnName("tipo_movimento");

            builder.Property(b => b.amount)
                   .HasColumnOrder(4)
                   .HasColumnName("quantidade");

            builder.Property(b => b.product_id)
                   .HasColumnOrder(6)
                   .HasColumnName("produto_id");
            builder.HasOne(b => b.product)
                   .WithMany(b => b.moviments)
                   .HasForeignKey(b => b.product_id);

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
