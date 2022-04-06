using Api.Data.Seed;
using Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItens { get; set; }
        public DbSet<MovimentacaoEstoque> MovimentacoesEstoque { get; set; }

        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PerfilPermissao> PerfilPermissoes { get; set; }

        public ApiContext()
        {
            //corrigir problema de incompatibilidade com o DateTime.Now no .net6
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaConfig());
            modelBuilder.ApplyConfiguration(new ProdutoConfig());
            modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfiguration(new VendedorConfig());
            modelBuilder.ApplyConfiguration(new PedidoConfig());
            modelBuilder.ApplyConfiguration(new PedidoItemConfig());
            modelBuilder.ApplyConfiguration(new MovimentacaoEstoqueConfig());
            modelBuilder.ApplyConfiguration(new PerfilConfig());
            modelBuilder.ApplyConfiguration(new PerfilPermissaoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            modelBuilder.ApplyPerfilSeed();
        }

    }
}
