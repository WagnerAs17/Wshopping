using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WShopping.Catalogo.Application.Services;
using WShopping.Catalogo.Domain.Events;
using WShopping.Catalogo.Domain.Interfaces;
using WShopping.Catalogo.Domain.Services;
using WShopping.Catalogo.Infra.Data;
using WShopping.Core.Communication.Mediator;
using WShopping.Core.Messages.CommonMessages.Notifications;
using WShopping.Vendas.Application.Commands;
using WShopping.Vendas.Domain;
using WShopping.Vendas.Infra.Data;
using WShopping.Vendas.Infra.Data.Repository;

namespace WShopping.Catalogo.MVC.Extensions
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //(Mediator)
            services.AddScoped<IMediatrHandler, MediatrHandler>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Catalogo
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<CatalogoContext>();

            services.AddScoped<INotificationHandler<ProdutoAbaixoEstoqueEvent>, ProdutoEventHandler>();

            //Vendas
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<VendasContext>();
            services.AddScoped<IRequestHandler<AdicionarItemPedidoCommand, bool>, PedidoCommandHandler>();



        }
    }
}
