﻿using MediatR;
using System.Threading.Tasks;
using WShopping.Core.Data.EventSourcing;
using WShopping.Core.Messages;
using WShopping.Core.Messages.CommonMessages.DomainEvents;
using WShopping.Core.Messages.CommonMessages.Notifications;

namespace WShopping.Core.Communication.Mediator
{
    public class MediatrHandler : IMediatrHandler
    {
        private readonly IMediator _mediator;
        private IEventSourcingRepository _eventSourcingRepository;

        public MediatrHandler(IMediator mediator, IEventSourcingRepository eventSourcingRepository)
        {
            _mediator = mediator;
            _eventSourcingRepository = eventSourcingRepository;
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
            await _eventSourcingRepository.SalvarEvento(evento);
        }

        public async Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification
        {
            await _mediator.Publish(notificacao);
        }

        public async Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent
        {
            await _mediator.Publish(notificacao);
        }
    }

}
