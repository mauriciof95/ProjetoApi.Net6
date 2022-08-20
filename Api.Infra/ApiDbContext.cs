using Api.Data.Seed;
using Api.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Infra
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Category> Categorias { get; set; }
        public DbSet<Product> Produtos { get; set; }
        public DbSet<Client> Clientes { get; set; }

        public DbSet<Order> Pedidos { get; set; }
        public DbSet<OrderItem> PedidoItens { get; set; }
        public DbSet<StockMoviment> MovimentacoesEstoque { get; set; }

        public DbSet<Role> Perfis { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<Permission> PerfilPermissoes { get; set; }

        public ApiDbContext()
        {
            //corrigir problema de incompatibilidade com o DateTime.Now no .net6
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
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
