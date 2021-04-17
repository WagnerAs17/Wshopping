﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WShopping.Catalogo.Application.DTOs
{
    public class ProdutoDTO
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Imagem { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; private set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {1} precisar ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Largura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {1} precisar ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Altura { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "O campo {1} precisar ter o valor mínimo de {1}")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Profundidade { get; set; }
        public IEnumerable<CategoriaDTO> Categoria { get; private set; }
    }
}
