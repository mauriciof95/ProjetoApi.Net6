using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data.Seed
{
    public static class PerfilSeed
    {
        public static void ApplyPerfilSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Perfil>().HasData(
                new Perfil
                {
                    id = 1,
                    descricao = "Admin",
                    ativo = true,
                    data_criacao = DateTime.Now
                },
                new Perfil
                {
                    id = 2,
                    descricao = "Colaborador",
                    ativo = true,
                    data_criacao = DateTime.Now
                }
            );
        }
    }
}
