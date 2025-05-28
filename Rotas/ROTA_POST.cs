using LojaVeiculos.Models;
using LojaVeiculos.Data;

namespace LojaVeiculos.Rotas;

public static class ROTA_POST
{
    public static void MapPostRoutes(this WebApplication app)
    {
        app.MapPost("/api/veiculos", async (Veiculo veiculo, VeiculosContext context) =>
        {

            var veiculoExistente = await context.Veiculos
            .FindAsync(veiculo.Placa);
            if (veiculoExistente != null)
            {
                return Results.Conflict($"Veículo com placa {veiculo.Placa} já existe.");
            }

            context.Veiculos.Add(veiculo);
            await context.SaveChangesAsync();

            return Results.Created($"/veiculos/{veiculo.Placa}", veiculo);
        });

        app.MapPost("/api/vendas", async (Venda venda, VeiculosContext context) =>
        {
            var veiculoParaVenda = await context.Veiculos
            .FindAsync(venda.PlacaVeiculo);
            if (veiculoParaVenda == null)
            return Results.NotFound("Veículo não encontrado.");

            veiculoParaVenda.Vendido = true;
            context.Veiculos.Update(veiculoParaVenda);
                
            context.Vendas.Add(venda);
            await context.SaveChangesAsync();
            return Results.Created($"/api/vendas/{venda.VendaId}", venda);         
        });
    }
}
