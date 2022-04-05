using Api.Repository;
using Api.Repository.Repository;
using Models;
using Models.Enum;
using Models.Request;

namespace Api.Services
{
    public class MovimentacaoEstoqueServices : BaseServices<MovimentacaoEstoque, MovimentacaoEstoqueRepository>
    {
        public MovimentacaoEstoqueServices(ApiContext context) : base(context) { }

        /*public async Task<MovimentacaoEstoque> RealizarVenda(DadosVendaRequest venda)
        {

        }*/

        public async Task<bool> TemEstoque(long produto_id, int qtd)
        {
            var qtd_entradas = await _repository.RetornarQtdPorTipo(produto_id, EstoqueTipo.ENTRADA);
            var qtd_saida = await _repository.RetornarQtdPorTipo(produto_id, EstoqueTipo.SAIDA);

            return (qtd_entradas - qtd_saida) >= qtd;
        }
    }
}
