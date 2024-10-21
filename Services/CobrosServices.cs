using FrannielAriasR_Ap1_P1.DAL;
using FrannielAriasR_Ap1_P1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FrannielAriasR_Ap1_P1.Services;

public class CobrosServices(Contexto _contexto)
{
    public async Task<bool> Guardar(Cobros cobro)
    {
        if (!await Existe(cobro.CobroId)) 
        {
            return await Insertar(cobro);
        }
        else
        {
            return await Modificar(cobro);
        }
}

    private async Task<bool> Modificar(Cobros cobro)
    {
        _contexto.Cobro.Update(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Insertar(Cobros cobro)
    {
        _contexto.Cobro.Add(cobro);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int cobroId)
    {
        return await _contexto.Cobro
            .AnyAsync(c => c.CobroId == cobroId);
    }
    public async Task<bool> Eliminar(Cobros cobro)
    {
        return await _contexto.Cobro
            .AsNoTracking()
            .Where(c=> c.CobroId == cobro.CobroId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Cobros?> Buscar(int cobroId)
    {
        return await _contexto.Cobro
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.CobroId == cobroId);
    }

    public async Task<List<Cobros>> Listar(Expression<Func<Cobros, bool>> criterio)
    {
        return await _contexto.Cobro
            .Include(c => c.Deudores)
            .Include(c => c.CobroDetalle)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}