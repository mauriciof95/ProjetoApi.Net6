using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class PerfilPermissaoConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("perfil_permissao");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.permission)
                   .HasMaxLength(50)
                   .HasColumnName("permissao")
                   .HasColumnOrder(2);

            builder.Property(b => b.role_id)
                   .HasColumnName("perfil_id")
                   .HasColumnOrder(3);

            builder.HasOne(b => b.perfil)
                   .WithMany(b => b.permissions)
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
