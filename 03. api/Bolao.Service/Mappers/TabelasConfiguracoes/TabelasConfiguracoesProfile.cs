using Bolao.Domain.Commands.TabelasConfiguracoes;
using Bolao.Domain.Entities.TabelasConfiguracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.TabelasConfiguracoes
{
    public static class TabelasConfiguracoesProfile
    {
        public static MappingProfile AddMappersTabelasConfiguracoes(this MappingProfile mapper)
        {
            return mapper
                .AddMapperCartaoCredito()
                .AddMapperConfiguracao();
        }

        private static MappingProfile AddMapperCartaoCredito(this MappingProfile mapper)
        {
            mapper.CreateMap<UpdateCartaoCreditoCommand, CartaoCredito>();

            return mapper;
        }

        private static MappingProfile AddMapperConfiguracao(this MappingProfile mapper)
        {
            mapper.CreateMap<UpdateConfiguracaoCommand, Configuracao>();

            return mapper;
        }
    }
}
