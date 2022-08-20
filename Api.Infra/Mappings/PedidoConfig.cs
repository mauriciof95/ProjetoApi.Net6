using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PedidoConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("pedido");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.order_status)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("status_pedido");

            builder.Property(b => b.order_date)
                   .HasColumnOrder(3)
                   .HasColumnName("data_pedido");

            builder.Property(b => b.client_id)
                   .HasColumnOrder(4)
                   .HasColumnName("cliente_id");
            builder.HasOne(b => b.cliente)
                   .WithMany(b => b.orders)
                   .HasForeignKey(b => b.client_id);

            builder.Property(b => b.seller_id)
                   .HasColumnOrder(5)
                   .HasColumnName("vendedor_id");
            builder.HasOne(b => b.vendedor)
                   .WithMany(b => b.orders)
                   .HasForeignKey(b => b.seller_id);

            builder.HasMany(b => b.pedido_itens)
                   .WithOne(b => b.order)
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
