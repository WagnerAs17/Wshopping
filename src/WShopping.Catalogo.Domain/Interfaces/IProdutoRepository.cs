using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WShopping.Core.Data;

namespace WShopping.Catalogo.Domain.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutos();
        Task<Produto> ObterPorId(Guid id);
        Task<IEnumerable<Produto>> ObterPorCategoria(int codigo);
        Task<IEnumerable<Categoria>> ObterCategorias();

        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
    }
}
