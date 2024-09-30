using FrannielAriasR_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;

namespace FrannielAriasR_Ap1_P1.DAL;

public class Contexto : DbContext
{
    public Contexto (DbContextOptions<Contexto> options) 
        : base(options){ }

    public DbSet<Prestamo> Registros { get; set; }

}
