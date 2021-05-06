using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WShopping.Vendas.Application.Queries.ViewModels;

namespace WShopping.Vendas.Application.Queries
{
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}