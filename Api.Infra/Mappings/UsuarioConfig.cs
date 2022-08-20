using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models;

namespace Api.Data.Mappings
{
    public class UsuarioConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(b => b.id);
            builder.Property(b => b.id)
                   .HasColumnName("id")
                   .HasColumnOrder(1)
                   .ValueGeneratedOnAdd();

            builder.Property(b => b.name)
                   .HasMaxLength(50)
                   .HasColumnName("nome")
                   .HasColumnOrder(2);

            builder.Property(b => b.password)
                   .HasMaxLength(50)
                   .HasColumnName("senha")
                   .HasColumnOrder(3);

            builder.Property(b => b.email)
                   .HasMaxLength(100)
                   .HasColumnName("email")
                   .HasColumnOrder(4);

            builder.Property(b => b.refresh_token)
                   .HasMaxLength(200)
                   .HasColumnName("refresh_token")
                   .HasColumnOrder(5);

            builder.Property(b => b.refresh_token_expiry_time)
                   .HasColumnName("refresh_token_expiry_time")
                   .HasColumnOrder(6);


            builder.Property(b => b.active)
                   .HasColumnName("ativo")
                   .HasColumnOrder(7);

            builder.Property(b => b.role_id)
                   .HasColumnName("perfil_id")
                   .HasColumnOrder(8);
            builder.HasOne(b => b.role)
                   .WithMany(b => b.users)
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
