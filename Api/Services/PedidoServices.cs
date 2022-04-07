using Api.Helpers.Exceptions;
using Infrastructure.Data.Repository;
using Api.Data.Context;
using Models;
using Models.Enum;
using Models.Request;
using Models.ViewModel;

namespace Api.Services
{
    public class PedidoServices : BaseServices<Pedido, PedidoRepository>
    {
        ProdutoServices _produtoServices;
        MovimentacaoEstoqueServices _movimentacaoEstoqueServices;


        public PedidoServices(ApiContext context) : base(context) 
        {
            _produtoServices = new ProdutoServices(context);
            _movimentacaoEstoqueServices = new MovimentacaoEstoqueServices(context);
        }

        public async Task<Pedido> RealizarPedido(DadosPedidoRequest obj)
        {
            await ValidarPedido(obj);


            Pedido pedido = new Pedido
            {
                cliente_id = obj.cliente_id,
                vendedor_id = obj.vendedor_id,
                data_pedido = DateTime.Now,
                status_pedido = StatusPedido.RECEBIDO,
                pedido_itens = new List<PedidoItem>()
            };

            List<MovimentacaoEstoque> itensME = new List<MovimentacaoEstoque>();

            foreach(var item in obj.itens)
            {
                Produto prod = await _produtoServices.FindByID(item.produto_id);

                pedido.pedido_itens.Add(new PedidoItem { 
                    produto_id = item.produto_id,
                    quantidade = item.quantidade,
                    valor_unitario_pago = prod.valor,
                });

                itensME.Add(new MovimentacaoEstoque { 
                    motivo_movimento = EstoqueMotivoMovimentacao.VENDA,
                    quantidade = item.quantidade,
                    tipo_movimento = EstoqueTipo.SAIDA,
                    produto_id = item.produto_id,
                });
            }
             

            var retorno = await Create(pedido);
            await _movimentacaoEstoqueServices.Create(itensME);

            return retorno;
        }

        public async Task ValidarPedido(DadosPedidoRequest obj)
        {
            string msg = "";

            if (obj.itens.Count() == 0)
                msg += "Os itens do pedido não podem estar vazia.\r\n";

            foreach(var item in obj.itens)
            {
                if (item.produto_id <= 0)
                {
                    msg += "Alguns Produtos são invalidos. \r\n";
                    break;
                }

                if(item.quantidade <= 0)
                {
                    msg += "A Quantidade de alguns produtos devem ser maior que zero. \r\n";
                    break;
                }

                bool tem_estoque = await _movimentacaoEstoqueServices.TemEstoque(item.produto_id, item.quantidade);

                if (!tem_estoque)
                {
                    msg += $"Estoque insuficiente para o produto #{item.produto_id}.\r\n";
                    break;
                }
            }

            if(obj.vendedor_id <= 0)
                msg += "Vendedor invalido.\r\n";

            if (obj.cliente_id <= 0)
                msg += "Cliente invalido.\r\n";




            if (!string.IsNullOrEmpty(msg))
                throw new ValidationException(msg);
        }

        public async Task<ICollection<PedidoItemVM>> RetornarItensPorPedido(long id)
            => await _repository.RetornarItensPorPedido(id);
        
    }
}
