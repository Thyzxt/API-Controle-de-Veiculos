using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaVeiculos.Models;

public class Venda
{
    [Key]
    public int VendaId { get; set; }

    [Required]
    public string PlacaVeiculo { get; set; }

    [ForeignKey("PlacaVeiculo")]
    public Veiculo Veiculo { get; set; }

    [Required]
    public string Cliente { get; set; }
}

public class Veiculo
{

    [Key]
    public string Placa { get; set; }

    public string Tipo { get; set; }

    public string Marca { get; set; }

    public int Ano { get; set; }

    public string Modelo { get; set; }

    public decimal Preco { get; set; }

    public bool Vendido { get; set; } = false;
}