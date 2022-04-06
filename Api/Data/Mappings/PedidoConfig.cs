using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("pedido");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.status_pedido)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("status_pedido");

            builder.Property(b => b.data_pedido)
                   .HasColumnOrder(3)
                   .HasColumnName("data_pedido");

            builder.Property(b => b.cliente_id)
                   .HasColumnOrder(4)
                   .HasColumnName("cliente_id");
            builder.HasOne(b => b.cliente)
                   .WithMany(b => b.pedidos)
                   .HasForeignKey(b => b.cliente_id);

            builder.Property(b => b.vendedor_id)
                   .HasColumnOrder(5)
                   .HasColumnName("vendedor_id");
            builder.HasOne(b => b.vendedor)
                   .WithMany(b => b.pedidos)
                   .HasForeignKey(b => b.vendedor_id);

            builder.HasMany(b => b.pedido_itens)
                   .WithOne(b => b.pedido)
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
