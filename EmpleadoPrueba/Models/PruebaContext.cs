using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmpleadoPrueba.Models
{
    public class PruebaContext : DbContext
    {
        public PruebaContext(DbContextOptions<PruebaContext> options)
            : base(options)
        { }

        public DbSet<Empleados> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Empleados>(em => { em.HasNoKey(); });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
