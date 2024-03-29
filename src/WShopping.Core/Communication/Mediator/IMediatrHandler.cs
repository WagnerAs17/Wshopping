﻿using System.Threading.Tasks;
using WShopping.Core.Messages;
using WShopping.Core.Messages.CommonMessages.DomainEvents;
using WShopping.Core.Messages.CommonMessages.Notifications;

namespace WShopping.Core.Communication.Mediator
{
    public interface IMediatrHandler 
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }

}
