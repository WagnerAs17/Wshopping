using System.Threading.Tasks;
using WShopping.Core.DomainObjects.DTO;

namespace WShopping.Pagamentos.Business
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoPedido(PagamentoPedido pagamentoPedido);
    }
}