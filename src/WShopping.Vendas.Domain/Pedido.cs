using System;
using System.Collections.Generic;
using System.Linq;
using WShopping.Core.DomainObjects;

namespace WShopping.Vendas.Domain
{
    public class Pedido : Entity, IAggregateRoot
    {
        public int Codigo { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid? VoucherId { get; private set; }
        public bool VoucherUtilizado { get; private set; }
        public decimal Desconto { get; private set; }
        public decimal ValorTotal { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public PedidoStatus Status { get; private set; }
        private readonly List<PedidoItem> _pedidoItems;
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItems;

        //EF 
        public virtual Voucher Voucher { get; private set; }
        protected Pedido() { _pedidoItems = new List<PedidoItem>(); }

        public Pedido(Guid clienteId, bool voucherUtilizado, decimal desconto, decimal valorTotal)
        {
            ClienteId = clienteId;
            VoucherUtilizado = voucherUtilizado;
            Desconto = desconto;
            ValorTotal = valorTotal;
            _pedidoItems = new List<PedidoItem>();
        }

        public void AplicarVoucher(Voucher voucher)
        {
            Voucher = voucher;
            VoucherUtilizado = true;
            CalcularValorPedido();
        }

        public void CalcularValorPedido()
        {
            ValorTotal = _pedidoItems.Sum(p => p.CalcularValor());
            CalcularValorTotalDesconto();
        }

        public void CalcularValorTotalDesconto()
        {
            if (!VoucherUtilizado) return;

            decimal desconto = 0;
            var valor = ValorTotal;

            if(Voucher.TipoDescontoVoucher == TipoDescontoVoucher.Porcentagem)
            {
                if (Voucher.Percentual.HasValue)
                {
                    desconto = (valor * Voucher.Percentual.Value) / 100;
                    valor -= desconto;
                }
            }
            else
            {
                if (Voucher.ValorDesconto.HasValue)
                {
                    desconto = Voucher.ValorDesconto.Value;
                    valor -= desconto;
                }
            }

            Desconto = desconto;
            ValorTotal = valor < 0 ? 0 : valor;
        }

        public bool PedidoItemExitente(PedidoItem item)
        {
            return _pedidoItems.Any(p => p.ProdutoId == item.ProdutoId);
        }

        public void AdicionarItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            item.AssociarPedido(Id);

            if (PedidoItemExitente(item))
            {
                var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

                itemExistente.AdicionarUnidade(item.Quantidade);

                item = itemExistente;

                _pedidoItems.Remove(itemExistente);
            }

            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void RemoverItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

            if (itemExistente == null) 
                throw new DomainException("Item não pertence ao pedido");

            _pedidoItems.Remove(item);

            CalcularValorPedido();
        }

        public void AtualizarItem(PedidoItem item)
        {
            if (!item.EhValido()) return;

            item.AssociarPedido(Id);

            var itemExistente = _pedidoItems.FirstOrDefault(p => p.ProdutoId == item.ProdutoId);

            if (itemExistente == null)
                throw new DomainException("Item não pertence ao pedido");

            _pedidoItems.Remove(itemExistente);
            _pedidoItems.Add(item);

            CalcularValorPedido();
        }

        public void AtualizarUnidades(PedidoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);

            AtualizarItem(item);
        }

        public void TornarRascunho()
        {
            Status = PedidoStatus.Rascunho;
        }

        public void IniciarPedio()
        {
            Status = PedidoStatus.Iniciado;
        }

        public void CancelarPedido()
        {
            Status = PedidoStatus.Cancelado;
        }

        public void FinalizarPedido()
        {
            Status = PedidoStatus.Pago;
        }

        public static class PedidoFactory
        {
            public static Pedido NovoPedidoRascunho(Guid clienteId)
            {
                var pedido = new Pedido
                {
                    ClienteId = clienteId
                };

                pedido.TornarRascunho();

                return pedido;
            }
        }
    }
}
