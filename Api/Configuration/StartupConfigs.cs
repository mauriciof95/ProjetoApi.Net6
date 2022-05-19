using Api.Services;
using Infrastructure.Data.Repository;

namespace Api.Configuration
{
    public static class StartupConfigs
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<CategoriaServices>();
            services.AddScoped<ProdutoServices>();
            services.AddScoped<ClienteServices>();
            services.AddScoped<VendedorServices>();
            services.AddScoped<PedidoServices>();
            services.AddScoped<MovimentacaoEstoqueServices>();
            services.AddScoped<PerfilServices>();
            services.AddScoped<UsuarioServices>();
        }

        public static void AddRepositorys(this IServiceCollection services)
        {
            services.AddScoped<CategoriaRepository>();
            services.AddScoped<ProdutoRepository>();
            services.AddScoped<ClienteRepository>();
            services.AddScoped<VendedorRepository>();
            services.AddScoped<PedidoRepository>();
            services.AddScoped<MovimentacaoEstoqueRepository>();
            services.AddScoped<PerfilRepository>();
            services.AddScoped<UsuarioRepository>();
        }
    }
}
