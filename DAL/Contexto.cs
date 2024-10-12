using FrannielAriasR_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace FrannielAriasR_Ap1_P1.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            : base(options) { }

        public DbSet<Cobros> Cobro { get; set; }
        public DbSet<CobrosDetalle> CobroDetalle { get; set; }
        public DbSet<Prestamos> Prestamos { get; set; }
        public DbSet<Deudores> Deudores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Deudores>().HasData(new List<Deudores>()
            {
                new Deudores() { DeudorId=1, Nombres="Lia"},
                new Deudores() { DeudorId=2, Nombres="DjMarte"},
                new Deudores() { DeudorId=3, Nombres="Franniel"},
                new Deudores() {DeudorId=4, Nombres="Ronel" }

            });
        }
    }
}
