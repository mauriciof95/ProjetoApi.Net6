using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModel;

namespace Api.Repository.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(ApiContext context) : base(context) { }

        public async Task<ICollection<PedidoItemVM>> RetornarItensPorPedido(long pedido_id)
        {
            return await _context.PedidoItens.AsNoTracking()
                .Include(x => x.produto)
                .Where(x => x.pedido_id == pedido_id)
                .Select(x => new PedidoItemVM
                {
                    descricao = x.produto.descricao,
                    quantidade = x.quantidade,
                    valor_unitario_pago = x.valor_unitario_pago
                }).ToListAsync();
        }
    }
}
