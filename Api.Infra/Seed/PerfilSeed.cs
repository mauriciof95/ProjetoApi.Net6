using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Data.Seed
{
    public static class PerfilSeed
    {
        public static void ApplyPerfilSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    id = new Guid(),
                    name = "Admin",
                    active = true,
                    created_at = DateTime.Now
                },
                new Role
                {
                    id = new Guid(),
                    name = "Colaborador",
                    active = true,
                    created_at = DateTime.Now
                }
            );
        }
    }
}
