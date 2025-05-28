using LojaVeiculos.Models;
using Microsoft.EntityFrameworkCore;
using LojaVeiculos.Data;

namespace LojaVeiculos.Rotas;

public static class ROTA_DELETE
{
    public static void MapDeleteRoutes(this WebApplication app)
    {
        app.MapDelete("/api/veiculos/{placa}", async (string placa, VeiculosContext context) =>
        {
            var veiculoParaDeletar = await context.Veiculos
            .FindAsync(placa);
            if (veiculoParaDeletar is null) 
                return Results.NotFound("Veículo não encontrado.");

            var veiculoVendido = await context.Vendas
            .AnyAsync(v => v.PlacaVeiculo == placa);
            if (veiculoVendido)
            {
                return Results.BadRequest("Não é possível excluir o veículo, pois ele foi vendido.");
            }

            context.Veiculos.Remove(veiculoParaDeletar);
            await context.SaveChangesAsync();
            return Results.Ok($"Veículo com placa {placa} removido com sucesso.");
        });
    }
}
