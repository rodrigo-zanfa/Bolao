using AutoMapper;
using Bolao.Service.Mappers.Campeonatos;
using Bolao.Service.Mappers.ClassesParceiros;
using Bolao.Service.Mappers.Produtos;
using Bolao.Service.Mappers.TabelasConfiguracoes;
using Bolao.Service.Mappers.Usuarios;

namespace Bolao.Service.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this
                .AddMappersProdutos()
                .AddMappersClassesParceiros()
                .AddMappersTabelasConfiguracoes()
                .AddMappersCampeonatos()
                .AddMappersUsuarios();
        }
    }
}
