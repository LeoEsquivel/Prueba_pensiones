using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prueba_Nomina.Entities;

namespace Prueba_Nomina
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

       

        public DbSet<Estado_civil> Estados_Civiles { get; set; }
        public DbSet<Movimientos>  Movimientos { get; set; }
        public DbSet<Tipo_Pension> Tipo_Pensiones { get; set; }
        public DbSet<Pensionado> Pensionados { get; set; }
        public DbSet<Movimiento_pension> Movimientos_Pensionados { get; set; }

    }
}
