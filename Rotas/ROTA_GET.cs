using Microsoft.EntityFrameworkCore;
using LojaVeiculos.Models;
using LojaVeiculos.Data;

namespace LojaVeiculos.Rotas;

public static class ROTA_GET{

    public static void MapGetRoutes(this WebApplication app)
    {

        app.MapGet("/api/veiculos", async (VeiculosContext context) =>
        {
            var veiculosDisponiveis = await context.Veiculos
            .Where(v => !v.Vendido).
            ToListAsync();

            return Results.Ok(veiculosDisponiveis);
        });

        app.MapGet("/api/veiculos/{placa}", async (VeiculosContext context, string placa) =>
        {
            var veiculoEncontrado = await context.Veiculos
            .FindAsync(placa);

            return veiculoEncontrado != null ? Results.Ok(veiculoEncontrado) : Results
            .NotFound("Veículo não encontrado.");
        });

        app.MapGet("/api/vendas", async (VeiculosContext context) =>
        {
            var veiculosVendidos = await context.Vendas
            .Include(v => v.Veiculo)
            .ToListAsync();

            return Results.Ok(veiculosVendidos);
        });

        app.MapGet("/api/vendas/{placa}", async (VeiculosContext context, string placa) =>
        {
            var vendaEncontrada = await context.Vendas
            .Include(v => v.Veiculo)
            .FirstOrDefaultAsync(v => v.PlacaVeiculo == placa);

            return vendaEncontrada != null ? Results.Ok(vendaEncontrada) : Results.NotFound("Venda não encontrada.");
        });

    }
}