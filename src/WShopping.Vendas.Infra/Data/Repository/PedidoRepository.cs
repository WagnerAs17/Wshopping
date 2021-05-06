using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WShopping.Core.Data;
using WShopping.Vendas.Domain;

namespace WShopping.Vendas.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly VendasContext _context;

        public PedidoRepository(VendasContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Pedido pedido)
        {
            _context.Add(pedido);
        }

        public void AdicionarItem(PedidoItem item)
        {
            _context.PedidoItems.Add(item);
        }

        public void Atualizar(Pedido pedido)
        {
            _context.Update(pedido);
        }

        public void AtualizarItem(PedidoItem item)
        {
            _context.PedidoItems.Update(item);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
           return await _context.PedidoItems.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItems.AsNoTracking()
                .FirstOrDefaultAsync(i => i.PedidoId == pedidoId && i.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos.AsNoTracking()
                .Where(p => p.ClienteId == clienteId).ToListAsync();
        }

        public async Task<Pedido> ObterPedidoRascunhoPorClienteId(Guid clienteId)
        {
            var pedido = await _context.Pedidos
                .FirstOrDefaultAsync(p => p.ClienteId == clienteId && p.Status == PedidoStatus.Rascunho);

            if (pedido is null) return null;

            await _context.Entry(pedido)
                .Collection(i => i.PedidoItems).LoadAsync();

            if(pedido.VoucherId != null)
            {
                await _context.Entry(pedido)
                    .Reference(i => i.Voucher).LoadAsync();
            }

            return pedido;
        }

        public async Task<Pedido> ObterPorId(Guid id)
        {
            return await _context.Pedidos.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.AsNoTracking()
                .FirstOrDefaultAsync(v => v.Codigo == codigo);
        }

        public void RemoverItem(PedidoItem item)
        {
            _context.PedidoItems.Remove(item);
        }
    }
}
