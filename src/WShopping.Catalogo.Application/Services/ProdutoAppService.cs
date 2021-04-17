using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WShopping.Catalogo.Application.DTOs;
using WShopping.Catalogo.Domain;
using WShopping.Catalogo.Domain.Interfaces;
using WShopping.Catalogo.Domain.Services;
using WShopping.Core.DomainObjects;

namespace WShopping.Catalogo.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEstoqueService _estoqueService;
        private readonly IMapper _mapper;

        public ProdutoAppService
        (
            IProdutoRepository produtoRepository,
            IEstoqueService estoqueService,
            IMapper mapper
        )
        {
            _produtoRepository = produtoRepository;
            _estoqueService = estoqueService;
            _mapper = mapper;
        }

        public async Task<ProdutoDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterProdutos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutos());
        }

        public async Task<IEnumerable<CategoriaDTO>> ObterCategorias()
        {
            return _mapper.Map<IEnumerable<CategoriaDTO>>(await _produtoRepository.ObterCategorias());
        }

        public async Task<IEnumerable<ProdutoDTO>> ObterPorCategoria(int codigo)
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterPorCategoria(codigo));
        }

        public async Task AdicionarProduto(ProdutoDTO produto)
        {
            _produtoRepository.Adicionar(_mapper.Map<Produto>(produto));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task AtualizarProduto(ProdutoDTO produto)
        {
            _produtoRepository.Atualizar(_mapper.Map<Produto>(produto));

            await _produtoRepository.UnitOfWork.Commit();
        }

        public async Task<ProdutoDTO> DebitarEstoque(Guid id, int quantidade)
        {
            if(!await _estoqueService.DebitarEstoque(id, quantidade))
                throw new DomainException("Falha ao debitar estoque");

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id)); 
        }

        public async Task<ProdutoDTO> ReporEstoque(Guid id, int quantidade)
        {
            if (!await _estoqueService.ReporEstoque(id, quantidade))
                throw new DomainException("Falha ao repor estoque");

            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterPorId(id));
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
            _estoqueService?.Dispose();
        }
    }
}
