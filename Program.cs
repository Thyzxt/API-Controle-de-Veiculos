using Microsoft.EntityFrameworkCore;
using LojaVeiculos.Data;
using LojaVeiculos.Models;
using LojaVeiculos.Rotas;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<VeiculosContext>(options =>
    options.UseSqlite("Data Source=veiculos.db"));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAll");

app.MapGetRoutes();
app.MapPostRoutes();
app.MapDeleteRoutes();

PopularBancoDeDados(app);

app.Run();

void PopularBancoDeDados(WebApplication app)
{
    using var scope = app.Services.CreateScope();
    var context = scope.ServiceProvider.GetRequiredService<VeiculosContext>();

    context.Database.Migrate(); 

    if (!context.Veiculos.Any())
    {
        var veiculosIniciais = new List<Veiculo>
        {
            new() { Placa = "ABC1234", Tipo = "Carro", Marca = "Toyota", Ano = 2020, Modelo = "Corolla", Preco = 75000 },
            new() { Placa = "XYZ9876", Tipo = "Moto", Marca = "Honda", Ano = 2018, Modelo = "CB 500", Preco = 32000 },
            new() { Placa = "DEF5678", Tipo = "Carro", Marca = "Ford", Ano = 2019, Modelo = "Fiesta", Preco = 48000 },
            new() { Placa = "GHI9012", Tipo = "Caminhão", Marca = "Volvo", Ano = 2017, Modelo = "FH", Preco = 150000 },
            new() { Placa = "YZA4567", Tipo = "Carro", Marca = "Hyundai", Ano = 2020, Modelo = "HB20", Preco = 58000 },
            new() { Placa = "JKL4321", Tipo = "Carro", Marca = "Chevrolet", Ano = 2021, Modelo = "Onix", Preco = 65000 },
            new() { Placa = "MNO6789", Tipo = "Moto", Marca = "Yamaha", Ano = 2019, Modelo = "MT-07", Preco = 42000 },
            new() { Placa = "PQR3456", Tipo = "Carro", Marca = "Volkswagen", Ano = 2018, Modelo = "Golf", Preco = 67000 },
            new() { Placa = "STU7890", Tipo = "Caminhão", Marca = "Scania", Ano = 2020, Modelo = "R450", Preco = 200000 },
            new() { Placa = "VWX1235", Tipo = "Carro", Marca = "Renault", Ano = 2022, Modelo = "Sandero", Preco = 54000 } 
        };

        context.Veiculos.AddRange(veiculosIniciais);
        context.SaveChanges();
    }
}

