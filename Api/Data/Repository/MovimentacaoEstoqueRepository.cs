using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Infrastructure.Data.Repository
{
    public class MovimentacaoEstoqueRepository : BaseRepository<MovimentacaoEstoque>
    {
        public MovimentacaoEstoqueRepository(ApiContext context) : base(context) { }

        public async Task<int> RetornarQtdPorTipo(long produto_id, string tipo)
        {
            return await _context.MovimentacoesEstoque
                .Where(x => x.produto_id == produto_id
                        && x.tipo_movimento == tipo)
                .SumAsync(x => x.quantidade);
        }
    }
}
