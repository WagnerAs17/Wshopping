using System;
using System.Threading.Tasks;
using WShopping.Catalogo.Domain.Events;
using WShopping.Catalogo.Domain.Interfaces;
using WShopping.Core.Communication.Mediator;

namespace WShopping.Catalogo.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _mediator;

        public EstoqueService
        (
            IProdutoRepository produtoRepository,
            IMediatrHandler mediator
        )
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            // TODO: Parametrizar a quantidade
            if(produto.QuantidadeEstoque < 10)
            {
                await _mediator.PublicarDomainEvent
                (
                    new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque)
                );
            }

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);

            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}
