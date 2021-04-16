using System.Collections.Generic;
using WShopping.Core.DomainObjects;

namespace WShopping.Catalogo.Domain
{
    public class Categoria : Entity
    {
        public string Nome { get; private set; }
        public int Codigo { get; private set; }
        //EF Relational
        public ICollection<Produto> Produtos { get; set; }
        public Categoria(string nome, int codigo)
        {
            Nome = nome;
            Codigo = codigo;
        }

        protected Categoria()
        {
        }

        public override string ToString()
        {
            return $"{Nome} - {Codigo}";
        }

        public void Validar()
        {
            Validacoes.ValidarSeVazio(Nome, "O campo Nome da categoria não pode ser vazio");
            Validacoes.ValidarSeIgual(Codigo, 0, "O campo código da categoria não pode ser igual a zero");
        }
    }
}
