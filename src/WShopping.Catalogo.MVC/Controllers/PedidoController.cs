using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WShopping.Core.Communication.Mediator;
using WShopping.Core.Messages.CommonMessages.Notifications;
using WShopping.Vendas.Application.Queries;

namespace WShopping.Catalogo.MVC.Controllers
{
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoQueries _pedidoQueries;

        public PedidoController
        (
            IPedidoQueries pedidoQueries,
            INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatrHandler
        ) : base(notifications, mediatrHandler)
        {
            _pedidoQueries = pedidoQueries;
        }

        [Route("meus-pedidos")]
        public async Task<IActionResult> Index()
        {
            return View(await _pedidoQueries.ObterPedidosCliente(ClienteId));
        }
    }
}
