using System;
using WShopping.Catalogo.Domain;
using WShopping.Core.DomainObjects;
using Xunit;

namespace WShoppping.Catalogo.Domain.Tests
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_Validar_ValidacoesDevemRetornarException()
        {
            var ex = Assert.Throws<DomainException>(() => new Produto
            (
                string.Empty, "Descricao", false, 100, "produto.jpg", 
                Guid.NewGuid(), new Dimensoes(10, 10, 10))
            );

            Assert.Equal("O campo Nome do produto não pode ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto
            (
                "Nome", string.Empty, false, 100, "produto.jpg",
                Guid.NewGuid(), new Dimensoes(10, 10, 10))
            );

            Assert.Equal("O campo Descrição do produto não pode ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto
            (
                "Nome", "Descricao", false, 100, string.Empty,
                Guid.NewGuid(), new Dimensoes(10, 10, 10))
            );

            Assert.Equal("O campo Imagem do produto não pode ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto
            (
                "Nome", "Descricao", false, 0, "Imagem.jpg",
                Guid.NewGuid(), new Dimensoes(10, 10, 10))
            );

            Assert.Equal("O campo Valor do produto não pode ser 0", ex.Message);

            ex = Assert.Throws<DomainException>(() => new Produto
            (
                "Nome", "Descricao", false, 100, "Imagem.jpg",
                Guid.Empty, new Dimensoes(10, 10, 10))
            );

            Assert.Equal("O campo CategoriaId do produto não pode ser vazio", ex.Message);
        }
    }
}
