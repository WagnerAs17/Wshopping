using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WShopping.Catalogo.Application.DTOs;

namespace WShopping.Catalogo.Application.Services
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoDTO>> ObterProdutos();
        Task<ProdutoDTO> ObterPorId(Guid id);
        Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo);
        Task<IEnumerable<CategoriaDTO>> ObterCategorias();

        Task AdicionarProduto(ProdutoDTO produto);
        Task AtualizarProduto(ProdutoDTO produto);

        Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade);
        Task<ProdutoDTO> ReporEstoque(Guid id, int quantidae);
    }
}
