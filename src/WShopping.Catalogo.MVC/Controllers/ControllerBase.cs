using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WShopping.Core.Communication.Mediator;
using WShopping.Core.Messages.CommonMessages.Notifications;

namespace WShopping.Catalogo.MVC.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatrHandler _mediatorHandler;
        public ControllerBase
        (
            INotificationHandler<DomainNotification> notifications,
            IMediatrHandler mediatrHandler
        )
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatrHandler;
        }

        protected bool OperacaoValida()
        {
            return !_notifications.TemNoticacao();
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediatorHandler.PublicarNoticacao(new DomainNotification(codigo, mensagem));
        }

        protected IEnumerable<string> ObterMensagensDeErro()
        {
            return _notifications.ObterNotificacoes().Select(n => n.Value).ToList();
        }
    }
}
