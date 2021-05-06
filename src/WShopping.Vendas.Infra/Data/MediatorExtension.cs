using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WShopping.Core.Communication.Mediator;
using WShopping.Core.DomainObjects;

namespace WShopping.Vendas.Infra.Data
{
    public static class MediatorExtension
    {
        public static async Task PublicarEvento(this IMediatrHandler mediatrHandler, VendasContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(e => e.Entity.Notificacoes != null && e.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(d => d.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(d => d.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediatrHandler.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
