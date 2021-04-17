using System;
using WShopping.Core.DomainObjects;

namespace WShopping.Catalogo.Domain
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Dimensoes Dimensoes { get; private set; }
        public Guid CategoriaId { get; private set; }
        public Categoria Categoria { get; private set; }

        //EF
        protected Produto() { }
        public Produto
        (
            string nome, 
            string descricao, 
            bool ativo, 
            decimal valor, 
            string imagem, 
            Guid categoriaId,
            Dimensoes dimensoes
        )
        {
            Nome = nome;
            Descricao = descricao;
            Ativo = ativo;
            Valor = valor;
            Imagem = imagem;
            DataCadastro = DateTime.Now;
            CategoriaId = categoriaId;
            Dimensoes = dimensoes;

            Validar();
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Validacoes.ValidarSeVazio(descricao, "O campo Descrição não pode ser vazio");
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0) quantidade *= -1;
            if (!PossuiEstoque(quantidade)) 
                throw new DomainException("O produto não possui estoque");

            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome do produto não pode ser vazio");
            Validacoes.ValidarSeVazio(Descricao, "O campo Descrição do produto não pode ser vazio");
            Validacoes.ValidarSeVazio(Imagem, "O campo Imagem do produto não pode ser vazio");
            Validacoes.ValidarSeMenorQue(Valor, 1, "O campo Valor do produto não pode ser 0");
            Validacoes.ValidarSeIgual(CategoriaId, Guid.Empty, "O campo CategoriaId do produto não pode ser vazio");
        }
    }
}
