using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WShopping.Core.Messages;

namespace WShopping.Core.Data.EventSourcing
{
    public interface IEventSourcingRepository
    {
        Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event;
        Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId);
    }
}
