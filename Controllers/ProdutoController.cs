using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockMarketProducts.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockMarketProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepositorio;

        public ProdutoController(IProdutoRepositorio produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoModel>>> ObterTodosProdutos()
        {
            var produtos = await _produtoRepositorio.ObterTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> ObterProdutoPorId(int id)
        {
            var produto = await _produtoRepositorio.ObterPorId(id);
            if (produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> CadastrarProduto([FromBody] ProdutoModel produto)
        {
            if (produto == null)
            {
                return BadRequest("Produto inválido.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _produtoRepositorio.Adicionar(produto);
            return CreatedAtAction(nameof(ObterProdutoPorId), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarProduto(int id, [FromBody] ProdutoModel produtoAtualizado)
        {
            if (id != produtoAtualizado.Id)
            {
                return BadRequest("IDs não correspondem.");
            }

            var produtoExistente = await _produtoRepositorio.ObterPorId(id);
            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _produtoRepositorio.Atualizar(produtoAtualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            var produtoExistente = await _produtoRepositorio.ObterPorId(id);
            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado.");
            }

            await _produtoRepositorio.Deletar(id);
            return NoContent();
        }
    }
}
