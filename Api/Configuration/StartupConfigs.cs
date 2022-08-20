using Api.Infra.Repository;

namespace Api.Configuration
{
    public static class StartupConfigs
    {
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
