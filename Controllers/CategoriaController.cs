using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketProducts.Models;

namespace StockMarketProducts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<CategoriaModel> categorias = new List<CategoriaModel>();

        // 1. Cadastrar uma categoria
        [HttpPost]
        public ActionResult<CategoriaModel> CadastrarCategoria([FromBody] CategoriaModel categoria)
        {
            if (categoria == null)
            {
                return BadRequest("Categoria inválida.");
            }

            categoria.Id = categorias.Count + 1; // Simula a geração de um ID
            categorias.Add(categoria);

            return CreatedAtAction(nameof(ObterCategoriaPorId), new { id = categoria.Id }, categoria);
        }

        // 2. Obter uma categoria por Id
        [HttpGet("{id}")]
        public ActionResult<CategoriaModel> ObterCategoriaPorId(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            return Ok(categoria);
        }

        // 3. Obter todas as categorias
        [HttpGet]
        public ActionResult<List<CategoriaModel>> ObterTodasCategorias()
        {
            return Ok(categorias);
        }

        // 4. Atualizar uma categoria por Id
        [HttpPut("{id}")]
        public ActionResult AtualizarCategoria(int id, [FromBody] CategoriaModel categoriaAtualizada)
        {
            var categoriaExistente = categorias.FirstOrDefault(c => c.Id == id);
            if (categoriaExistente == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            categoriaExistente.Name = categoriaAtualizada.Name;
            categoriaExistente.Description = categoriaAtualizada.Description;

            return NoContent();
        }

        // 5. Deletar uma categoria por Id
        [HttpDelete("{id}")]
        public ActionResult DeletarCategoria(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            categorias.Remove(categoria);
            return NoContent();
        }

        // 6. Adicionar produto a uma categoria
        [HttpPost("{id}/produtos")]
        public ActionResult AdicionarProdutoACategoria(int id, [FromBody] ProdutoModel produto)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            categoria.Produtos.Add(produto);
            return Ok(categoria);
        }

        // 7. Obter produtos de uma categoria por Id
        [HttpGet("{id}/produtos")]
        public ActionResult<List<ProdutoModel>> ObterProdutosDaCategoria(int id)
        {
            var categoria = categorias.FirstOrDefault(c => c.Id == id);
            if (categoria == null)
            {
                return NotFound("Categoria não encontrada.");
            }

            return Ok(categoria.Produtos);
        }
    }
}
