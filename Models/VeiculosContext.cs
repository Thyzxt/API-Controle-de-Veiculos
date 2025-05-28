using Microsoft.EntityFrameworkCore;
using LojaVeiculos.Models;

namespace LojaVeiculos.Data
{

    public class VeiculosContext : DbContext
    {

        public VeiculosContext(DbContextOptions<VeiculosContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }
        
        public DbSet<Venda> Vendas { get; set; }
    }
}