using Microsoft.EntityFrameworkCore;
using StockMarketProducts.Models;

public class AppDbContext : DbContext
{
    public DbSet<ProdutoModel> Produtos { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Configurações adicionais do modelo, se necessário
    }

}