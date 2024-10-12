using FrannielAriasR_Ap1_P1.DAL;
using FrannielAriasR_Ap1_P1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Update;
using System.Linq.Expressions;

namespace FrannielAriasR_Ap1_P1.Services;

public class PrestamosServices(Contexto _contexto)
{
    public async Task<bool> Guardar(Prestamos prestamo)
    {
        if (!await Existe(prestamo.PrestamoId))
        {
            return await Insertar(prestamo);
        }
        else
        {
            return await Modificar(prestamo);
        }
    }

    private async Task<bool> Modificar(Prestamos prestamo)
    {
        _contexto.Prestamos.Update(prestamo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Insertar(Prestamos prestamo)
    {
        _contexto.Prestamos.Add(prestamo);
        return await _contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Existe(int prestamoId)
    {
        return await _contexto.Prestamos
            .AnyAsync(p => p.PrestamoId == prestamoId);
    }

    public async Task<bool> Eliminar(Prestamos prestamo)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .Where(p => p.PrestamoId == prestamo.PrestamoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<Prestamos?> Buscar(int prestamosId)
    {
        return await _contexto.Prestamos
            .AsNoTracking()
            .FirstOrDefaultAsync(p=> p.PrestamoId == prestamosId);
    }

    public async Task<List<Prestamos>> Listar(Expression<Func<Prestamos, bool>> criterio)
    {
        return await _contexto.Prestamos
            .Include(p => p.Cobros)
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }

}
