using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class MovimentacaoEstoqueConfig : IEntityTypeConfiguration<MovimentacaoEstoque>
    {
        public void Configure(EntityTypeBuilder<MovimentacaoEstoque> builder)
        {
            builder.ToTable("movimentacao_estoque");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.motivo_movimento)
                   .HasMaxLength(50)
                   .HasColumnOrder(2)
                   .HasColumnName("motivo_movimento");

            builder.Property(b => b.tipo_movimento)
                   .HasMaxLength(50)
                   .HasColumnOrder(3)
                   .HasColumnName("tipo_movimento");

            builder.Property(b => b.quantidade)
                   .HasColumnOrder(4)
                   .HasColumnName("quantidade");

            builder.Property(b => b.produto_id)
                   .HasColumnOrder(6)
                   .HasColumnName("produto_id");
            builder.HasOne(b => b.produto)
                   .WithMany(b => b.movimentacoes)
                   .HasForeignKey(b => b.produto_id);

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
