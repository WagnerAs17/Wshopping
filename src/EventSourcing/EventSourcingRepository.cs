using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WShopping.Core.Data.EventSourcing;
using WShopping.Core.Messages;

namespace EventSourcing
{
    public class EventSourcingRepository : IEventSourcingRepository
    {
        private readonly IEventStoreService _eventStoreService;

        public EventSourcingRepository(IEventStoreService eventStoreService)
        {
            _eventStoreService = eventStoreService;
        }

        public async Task<IEnumerable<StoredEvent>> ObterEventos(Guid aggregateId)
        {
            var eventos = await _eventStoreService.GetConnection()
                .ReadStreamEventsBackwardAsync(aggregateId.ToString(), 0, 500, false);

            var listaEventos = new List<StoredEvent>();

            foreach (var resolveEvent in eventos.Events)
            {
                var dataEncoded = Encoding.UTF8.GetString(resolveEvent.Event.Data);

                var jsonData = JsonConvert.DeserializeObject<BaseEvent>(dataEncoded);

                var evento = new StoredEvent(
                        resolveEvent.Event.EventId,
                        resolveEvent.Event.EventType,
                        jsonData.Timestamp,
                        dataEncoded
                    );

                listaEventos.Add(evento);
            }

            return listaEventos;
        }

        public async Task SalvarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            await _eventStoreService.GetConnection().AppendToStreamAsync
                (evento.AggregateId.ToString(),
                ExpectedVersion.Any,
                FormatarEvento(evento));
        }

        private static IEnumerable<EventData> FormatarEvento<TEvent>(TEvent evento) where TEvent : Event
        {
            yield return new EventData(
                Guid.NewGuid(),
                evento.MessageType,
                true,
                Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(evento)),
                null
                );
        }

    }

    internal class BaseEvent
    {
        public DateTime Timestamp { get; set; }
    }
}
