using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.Produtos
{
    public static class ProdutosProfile
    {
        public static MappingProfile AddMappersProdutos(this MappingProfile mapper)
        {
            return mapper
                .AddMapperProduto()
                .AddMapperProdutoTipo()
                .AddMapperEstrutura()
                .AddMapperInversor()
                .AddMapperCabo()
                .AddMapperModulo();
        }

        private static MappingProfile AddMapperProduto(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateProdutoCommand, Produto>();
            mapper.CreateMap<UpdateProdutoCommand, Produto>();

            return mapper;
        }

        private static MappingProfile AddMapperProdutoTipo(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateProdutoTipoCommand, ProdutoTipo>();
            mapper.CreateMap<UpdateProdutoTipoCommand, ProdutoTipo>();

            return mapper;
        }

        private static MappingProfile AddMapperEstrutura(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateEstruturaCommand, Estrutura>();
            mapper.CreateMap<UpdateEstruturaCommand, Estrutura>();

            return mapper;
        }

        private static MappingProfile AddMapperInversor(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateInversorCommand, Inversor>();
            mapper.CreateMap<UpdateInversorCommand, Inversor>();

            return mapper;
        }

        private static MappingProfile AddMapperCabo(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateCaboCommand, Cabo>();
            mapper.CreateMap<UpdateCaboCommand, Cabo>();

            return mapper;
        }

        private static MappingProfile AddMapperModulo(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateModuloCommand, Modulo>();
            mapper.CreateMap<UpdateModuloCommand, Modulo>();

            return mapper;
        }
    }
}
