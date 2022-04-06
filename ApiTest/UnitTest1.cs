using Api.Helpers.Exceptions;
using Api.Services;
using Api.Data.Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enum;
using Models.Request;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest
{
    public class Tests
    {
        private CategoriaServices _categoriaService;
        private ProdutoServices _produtoService;
        private ClienteServices _clienteService;
        private VendedorServices _vendedorService;
        private MovimentacaoEstoqueServices _movimentacaoEstoqueService;
        private PedidoServices _pedidoServices;


        string CategoriaDescricao = "Veiculo";
        string ProdutoDescricao = "Farol Dianteiro";

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("ProjetoApiBase")
                .Options;
            var contexto = new ApiContext(options);

            _categoriaService = new CategoriaServices(contexto);
            _produtoService = new ProdutoServices(contexto);
            _clienteService = new ClienteServices(contexto);
            _vendedorService = new VendedorServices(contexto);
            _movimentacaoEstoqueService = new MovimentacaoEstoqueServices(contexto);
            _pedidoServices = new PedidoServices(contexto);
        }

        [Test]
        public async Task IncluirCategoria()
        {
            var cat = new Categoria
            {
                descricao = CategoriaDescricao
            };

            var result = await _categoriaService.Create(cat);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirProduto()
        {
            var cat = await _categoriaService.FirstSearchBy_Descricao(CategoriaDescricao);

            var prod = new Produto
            {
                categoria_id = cat.id,
                descricao = ProdutoDescricao,
                valor = 99.90m
            };

            var result = await _produtoService.Create(prod);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirCliente()
        {
            var client = new Cliente
            {
                nome = "Cliente Teste 1",
                documento = "1001"
            };

            var result = await _clienteService.Create(client);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirVendedor()
        {
            var obj = new Vendedor
            {
                nome = "Vendedor Teste 1",
                documento = "1001"
            };

            var result = await _vendedorService.Create(obj);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task AdicionarEstoqueProduto()
        {
            var obj = new MovimentacaoEstoque
            {
                produto_id = 1,
                quantidade = 10,
                motivo_movimento = EstoqueMotivoMovimentacao.ESTOCAGEM,
                tipo_movimento = EstoqueTipo.ENTRADA
            };

            var result = await _movimentacaoEstoqueService.Create(obj);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task VerificarDisponibilidadeDeEstoque()
        {
            var result = await _movimentacaoEstoqueService.TemEstoque(1, 1);
            Assert.True(result);
        }

        [Test]
        public async Task TestarValidacaoRealizarPedidoDadosIncompletos()
        {
            var obj = new DadosPedidoRequest
            {
            };

            var itens = new List<ItemPedidoRequest>
            {
            };

            obj.itens = itens;

            Assert.ThrowsAsync<ValidationException>(async () => await _pedidoServices.RealizarPedido(obj));
        }

        [Test]
        public async Task TestarValidacaoRealizarPedidoSemEstoque()
        {
            var obj = new DadosPedidoRequest
            {
                cliente_id = 1,
                vendedor_id = 1,
            };

            var itens = new List<ItemPedidoRequest>
            {
                new ItemPedidoRequest { produto_id = 1, quantidade = 11 }
            };

            obj.itens = itens;

            Assert.ThrowsAsync<ValidationException>(async () => await _pedidoServices.RealizarPedido(obj));
        }


        [Test]
        public async Task RealizarPedido()
        {
            var obj = new DadosPedidoRequest
            {
                cliente_id = 1,
                vendedor_id = 1,
            };

            var itens = new List<ItemPedidoRequest> {
                new ItemPedidoRequest { produto_id = 1, quantidade = 5}
            };

            obj.itens = itens;

            var result = await _pedidoServices.RealizarPedido(obj);
            var result2 = await _pedidoServices.RetornarItensPorPedido(result.id);

            Assert.True(result.id > 0 && result2.Count() > 0);
        }

    }
}