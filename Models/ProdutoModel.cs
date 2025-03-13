using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace StockMarketProducts.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        public int amount { get; set; }
    }
}
