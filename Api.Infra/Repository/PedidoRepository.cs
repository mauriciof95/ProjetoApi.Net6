using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;

namespace Api.Infra.Repository
{
    public class PedidoRepository : BaseRepository<Order>
    {
        public PedidoRepository(ApiDbContext context) : base(context) { }

        public async Task<ICollection<PedidoItemVM>> RetornarItensPorPedido(long pedido_id)
        {
            return await _context.PedidoItens.AsNoTracking()
                .Include(x => x.product)
                .Where(x => x.order_id == pedido_id)
                .Select(x => new PedidoItemVM
                {
                    descricao = x.product.description,
                    quantidade = x.amount,
                    valor_unitario_pago = x.unit_value_paid
                }).ToListAsync();
        }
    }
}
