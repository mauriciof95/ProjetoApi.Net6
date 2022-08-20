using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PerfilConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("perfil");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.name)
                   .HasMaxLength(50)
                   .HasColumnName("descricao")
                   .HasColumnOrder(2);

            builder.Property(b => b.active)
                   .HasColumnName("ativo")
                   .HasColumnOrder(3);

            builder.HasMany(b => b.permissions)
                   .WithOne(b => b.perfil)
                   .HasForeignKey(b => b.role_id);

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
