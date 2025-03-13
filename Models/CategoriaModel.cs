namespace StockMarketProducts.Models
{
    public class CategoriaModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<ProdutoModel> Produtos { get; set; } = new List<ProdutoModel>();
    }
}

