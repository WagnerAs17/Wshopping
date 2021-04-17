using AutoMapper;
using WShopping.Catalogo.Application.DTOs;
using WShopping.Catalogo.Domain;

namespace WShopping.Catalogo.Application.AutoMapper
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(d => d.Largura, o => o.MapFrom(p => p.Dimensoes.Largura))
                .ForMember(d => d.Altura, o => o.MapFrom(p => p.Dimensoes.Altura))
                .ForMember(d => d.Profundidade, o => o.MapFrom(p => p.Dimensoes.Profundidade));

            CreateMap<Categoria, CategoriaDTO>();
        }
    }
}
