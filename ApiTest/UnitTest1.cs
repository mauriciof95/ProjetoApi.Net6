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
using Infrastructure.Data.Repository;

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
        public void Setup(CategoriaServices categoriaServices)
        {
            var options = new DbContextOptionsBuilder<ApiContext>()
                .UseInMemoryDatabase("ProjetoApiBase")
                .Options;
            var contexto = new ApiContext(options);

            _categoriaService = new CategoriaServices(new CategoriaRepository(contexto));
            _produtoService = new ProdutoServices(new ProdutoRepository(contexto));
            _clienteService = new ClienteServices(new ClienteRepository(contexto));
            _vendedorService = new VendedorServices(new VendedorRepository(contexto));
            _movimentacaoEstoqueService = new MovimentacaoEstoqueServices(new MovimentacaoEstoqueRepository(contexto));
            _pedidoServices = new PedidoServices(new PedidoRepository(contexto), _produtoService, _movimentacaoEstoqueService);
        }

        [Test]
        public async Task IncluirCategoria()
        {
            var cat = new Category
            {
                description = CategoriaDescricao
            };

            var result = await _categoriaService.Create(cat);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirProduto()
        {
            var cat = await _categoriaService.FirstSearchBy_Descricao(CategoriaDescricao);

            var prod = new Product
            {
                category_id = cat.id,
                description = ProdutoDescricao,
                price = 99.90m
            };

            var result = await _produtoService.Create(prod);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirCliente()
        {
            var client = new Client
            {
                name = "Cliente Teste 1",
                document = "1001"
            };

            var result = await _clienteService.Create(client);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task IncluirVendedor()
        {
            var obj = new Seller
            {
                name = "Vendedor Teste 1",
                document = "1001"
            };

            var result = await _vendedorService.Create(obj);

            Assert.Greater(result.id, 0);
        }

        [Test]
        public async Task AdicionarEstoqueProduto()
        {
            var obj = new StockMoviment
            {
                product_id = 1,
                amount = 10,
                moviment_reason = StockMovimentReason.ESTOCAGEM,
                moviment_type = StockType.INPUT
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
            await Task.Yield();

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
            await Task.Yield();

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