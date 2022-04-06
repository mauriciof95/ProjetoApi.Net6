using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PedidoItemConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("pedido_item");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.quantidade)
                   .HasColumnOrder(2)
                   .HasColumnName("quantidade");

            builder.Property(b => b.valor_unitario_pago)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnOrder(3)
                   .HasColumnName("valor_unitario_pago");

            builder.Property(b => b.produto_id)
                   .HasColumnOrder(4)
                   .HasColumnName("produto_id");
            builder.HasOne(b => b.produto)
                   .WithMany()
                   .HasForeignKey(b => b.produto_id);

            builder.Property(b => b.pedido_id)
                   .HasColumnOrder(5)
                   .HasColumnName("pedido_id");
            builder.HasOne(b => b.pedido)
                   .WithMany(b => b.pedido_itens)
                   .HasForeignKey(b => b.pedido_id);

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
