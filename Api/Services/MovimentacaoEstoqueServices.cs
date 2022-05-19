using Infrastructure.Data.Repository;
using Models;
using Models.Enum;

namespace Api.Services
{
    public class MovimentacaoEstoqueServices : BaseServices<MovimentacaoEstoque>
    {
        private readonly MovimentacaoEstoqueRepository _repository;

        public MovimentacaoEstoqueServices(MovimentacaoEstoqueRepository repository) : base(repository) => _repository = repository;
        
        public async Task<bool> TemEstoque(long produto_id, int qtd)
        {
            var qtd_entradas = await _repository.RetornarQtdPorTipo(produto_id, EstoqueTipo.ENTRADA);
            var qtd_saida = await _repository.RetornarQtdPorTipo(produto_id, EstoqueTipo.SAIDA);

            return (qtd_entradas - qtd_saida) >= qtd;
        }
    }
}
