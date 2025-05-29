using System.Collections.Generic;
using System.Data.Entity;

namespace CierreOrdenInspeccion.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<OrdenInspeccion> Ordenes { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<MotivoTipo> Motivos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sismografo> Sismografos { get; set; }

        public DbSet<CambioEstado> CambioEstado { get; set; }

        public AppDbContext() : base("name=DefaultConnection")
        {
        }
    }
}
