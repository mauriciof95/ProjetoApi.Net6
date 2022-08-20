using Microsoft.EntityFrameworkCore;
using Models;

namespace Api.Infra.Repository
{
    public class MovimentacaoEstoqueRepository : BaseRepository<StockMoviment>
    {
        public MovimentacaoEstoqueRepository(ApiDbContext context) : base(context) { }

        public async Task<int> RetornarQtdPorTipo(long produto_id, string tipo)
        {
            return await _context.MovimentacoesEstoque
                .Where(x => x.product_id == produto_id
                        && x.moviment_type == tipo)
                .SumAsync(x => x.amount);
        }
    }
}
