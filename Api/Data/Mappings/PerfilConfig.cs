using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("perfil");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.descricao)
                   .HasMaxLength(50)
                   .HasColumnName("descricao")
                   .HasColumnOrder(2);

            builder.Property(b => b.ativo)
                   .HasColumnName("ativo")
                   .HasColumnOrder(3);

            builder.HasMany(b => b.permissoes)
                   .WithOne(b => b.perfil)
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
