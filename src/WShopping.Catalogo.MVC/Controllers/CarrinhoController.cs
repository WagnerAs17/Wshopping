using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WShopping.Catalogo.Application.Services;
using WShopping.Core.Communication.Mediator;
using WShopping.Core.Messages.CommonMessages.Notifications;
using WShopping.Vendas.Application.Commands;

namespace WShopping.Catalogo.MVC.Controllers
{
    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatrHandler _mediatrHandler;

        public CarrinhoController
        (
            IProdutoAppService produtoAppService,
            IMediatrHandler mediatrHandler,
            INotificationHandler<DomainNotification> notifications
        ) : base(notifications, mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatrHandler = mediatrHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id, int quantidade)
        {
            var produto = await _produtoAppService.ObterPorId(id);
            if (produto == null) return NotFound();

            if(produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insuficiente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }

            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);

            await _mediatrHandler.EnviarComando(command);

            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }

            TempData["Erros"] = ObterMensagensDeErro();
            return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
        }
    }
}
