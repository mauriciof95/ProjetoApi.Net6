using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PedidoItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("pedido_item");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.amount)
                   .HasColumnOrder(2)
                   .HasColumnName("quantidade");

            builder.Property(b => b.unit_value_paid)
                   .HasColumnType("decimal(10, 2)")
                   .HasColumnOrder(3)
                   .HasColumnName("valor_unitario_pago");

            builder.Property(b => b.product_id)
                   .HasColumnOrder(4)
                   .HasColumnName("produto_id");
            builder.HasOne(b => b.product)
                   .WithMany()
                   .HasForeignKey(b => b.product_id);

            builder.Property(b => b.order_id)
                   .HasColumnOrder(5)
                   .HasColumnName("pedido_id");
            builder.HasOne(b => b.order)
                   .WithMany(b => b.pedido_itens)
                   .HasForeignKey(b => b.order_id);

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
