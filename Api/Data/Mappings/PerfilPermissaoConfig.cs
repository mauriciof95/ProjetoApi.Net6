using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PerfilPermissaoConfig : IEntityTypeConfiguration<PerfilPermissao>
    {
        public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
        {
            builder.ToTable("perfil_permissao");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.permissao)
                   .HasMaxLength(50)
                   .HasColumnName("permissao")
                   .HasColumnOrder(2);

            builder.Property(b => b.perfil_id)
                   .HasColumnName("perfil_id")
                   .HasColumnOrder(3);

            builder.HasOne(b => b.perfil)
                   .WithMany(b => b.permissoes)
                   .HasForeignKey(b => b.perfil_id);

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
