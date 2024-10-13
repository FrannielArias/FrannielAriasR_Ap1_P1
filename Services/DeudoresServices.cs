using FrannielAriasR_Ap1_P1.DAL;
using FrannielAriasR_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrannielAriasR_Ap1_P1.Services
{
    public class DeudoresServices(Contexto _contexto)
    {
        public async Task<List<Deudores>> Listar(Expression<Func<Deudores, bool>> criterio)
        {
            return await _contexto.Deudores
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

    }
}
