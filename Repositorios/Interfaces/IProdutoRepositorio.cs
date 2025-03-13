using Microsoft.EntityFrameworkCore;
using StockMarketProducts.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IProdutoRepositorio
{
    Task<List<ProdutoModel>> ObterTodos();
    Task<ProdutoModel> ObterPorId(int id);
    Task Adicionar(ProdutoModel produto);
    Task Atualizar(ProdutoModel produto);
    Task Deletar(int id);
}

public class ProdutoRepositorio : IProdutoRepositorio
{
    private static List<ProdutoModel> produtos = new List<ProdutoModel>();

    public async Task<List<ProdutoModel>> ObterTodos()
    {
        return await Task.FromResult(produtos);
    }

    public async Task<ProdutoModel> ObterPorId(int id)
    {
        return await Task.FromResult(produtos.FirstOrDefault(p => p.Id == id));
    }

    public async Task Adicionar(ProdutoModel produto)
    {
        produtos.Add(produto);
        await Task.CompletedTask;
    }

    public async Task Atualizar(ProdutoModel produto)
    {
        var produtoExistente = produtos.FirstOrDefault(p => p.Id == produto.Id);
        if (produtoExistente != null)
        {
            produtos.Remove(produtoExistente);
            produtos.Add(produto);
        }
        await Task.CompletedTask;
    }

    public async Task Deletar(int id)
    {
        var produto = produtos.FirstOrDefault(p => p.Id == id);
        if (produto != null)
        {
            produtos.Remove(produto);
        }
        await Task.CompletedTask;
    }
}
