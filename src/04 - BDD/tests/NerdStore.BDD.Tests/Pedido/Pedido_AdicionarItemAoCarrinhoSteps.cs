﻿using NerdStore.BDD.Tests.Config;
using NerdStore.BDD.Tests.Usuario;
using TechTalk.SpecFlow;
using Xunit;

namespace NerdStore.BDD.Tests.Pedido
{
    [Binding]
    [CollectionDefinition(nameof(AutomacaoWebFixtureCollection))]
    public class Pedido_AdicionarItemAoCarrinhoSteps
    {
        private readonly AutomacaoWebTestsFixture _testsFixture;
        private readonly PedidoTela _pedidoTela;
        private readonly LoginUsuarioTela _loginUsuarioTela;

        private string _urlProduto;

        public Pedido_AdicionarItemAoCarrinhoSteps(AutomacaoWebTestsFixture testsFixture)
        {
            _testsFixture = testsFixture;
            _pedidoTela = new PedidoTela(testsFixture.BrowserHelper);
            _loginUsuarioTela = new LoginUsuarioTela(testsFixture.BrowserHelper);
        }

        [Given(@"O usuario esteja logado")]
        public void DadoOUsuarioEstejaLogado()
        {
            // Arrange
            var usuario = new Usuario.Usuario
            {
                Email = "teste@teste.com",
                Senha = "Teste@123"
            };
            _testsFixture.Usuario = usuario;

            // Act
            var login = _loginUsuarioTela.Login(usuario);

            // Assert
            Assert.True(login);
        }

        [Given(@"Que um produto esteja na vitrine")]
        public void DadoQueUmProdutoEstejaNaVitrine()
        {
            // Arrange
            _pedidoTela.AcessarVitrineDeProdutos();
            _urlProduto = _pedidoTela.ObterUrl();

            // Act
            _pedidoTela.ObterDetalhesDoProduto();

            // Assert
            Assert.True(_pedidoTela.ValidarProdutoDisponivel());
        }

        [Given(@"Esteja disponivel no estoque")]
        public void DadoEstejaDisponivelNoEstoque()
        {
            // Assert
            Assert.True(_pedidoTela.ObterQuantidadeNoEstoque() > 0);
        }

        [When(@"O usuário adicionar uma unidade ao carrinho")]
        public void QuandoOUsuarioAdicionarUmaUnidadeAoCarrinho()
        {
            // Act
            _pedidoTela.ClicarEmComprarAgora();
        }

        [Then(@"O usuário será redirecionado ao resumo da compra")]
        public void EntaoOUsuarioSeraRedirecionadoAoResumoDaCompra()
        {
            // Assert
            Assert.True(_pedidoTela.ValidarSeEstaNoCarrinhoDeCompras());
        }

        [Then(@"O valor total do pedido será exatamente o valor do item adicionado")]
        public void EntaoOValorTotalDoPedidoSeraExatamenteOValorDoItemAdicionado()
        {
            // Arrange
            var valorUnitario = _pedidoTela.ObterValorUnitarioProdutoCarrinho();
            var valorCarrinho = _pedidoTela.ObterValorTotalCarrinho();

            // Assert
            Assert.Equal(valorUnitario, valorCarrinho);
        }

        [When(@"O usuário adicionar um item acima da quantidade máxima permitida")]
        public void QuandoOUsuarioAdicionarUmItemAcimaDaQuantidadeMaximaPermitida()
        {
            // Arrange
            _pedidoTela.ClicarAdicionarQuantidadeItens(Vendas.Domain.Pedido.MAX_UNIDADES_ITEM + 1);

            // Act
            _pedidoTela.ClicarEmComprarAgora();
        }

        [Then(@"Receberá uma mensagem de erro mencionando que foi ultrapassada a quantidade limite")]
        public void EntaoReceberaUmaMensagemDeErroMencionandoQueFoiUltrapassadaAQuantidadeLimite()
        {
            // Arrange
            var mensagem = _pedidoTela.ObterMensagemDeErroProduto();

            // Assert
            Assert.Contains($"A quantidade máxima de um item é {Vendas.Domain.Pedido.MAX_UNIDADES_ITEM}", mensagem);
        }




        [Given(@"Não tenha nenhum produto adicionado ao carrinho")]
        public void DadoNaoTenhaNenhumProdutoAdicionadoAoCarrinho()
        {
            // Arrange

            // Act

            // Assert
        }

        [Given(@"O mesmo produto já tenha sido adicionado ao carrinho anteriormente")]
        public void DadoOMesmoProdutoJaTenhaSidoAdicionadoAoCarrinhoAnteriormente()
        {
            // Arrange

            // Act

            // Assert
        }

        [When(@"O usuário adicionar a quantidade máxima permitida ao carrinho")]
        public void QuandoOUsuarioAdicionarAQuantidadeMaximaPermitidaAoCarrinho()
        {
            // Arrange

            // Act

            // Assert
        }

        [Then(@"A quantidade de itens daquele produto terá sido acrescida em uma unidade a mais")]
        public void EntaoAQuantidadeDeItensDaqueleProdutoTeraSidoAcrescidaEmUmaUnidadeAMais()
        {
            // Arrange

            // Act

            // Assert
        }

        [Then(@"O valor total do pedido será a multiplicação da quantidade de itens pelo valor unitario")]
        public void EntaoOValorTotalDoPedidoSeraAMultiplicacaoDaQuantidadeDeItensPeloValorUnitario()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
