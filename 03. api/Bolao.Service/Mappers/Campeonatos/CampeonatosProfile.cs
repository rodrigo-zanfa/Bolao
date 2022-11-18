using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Entities.Campeonatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.Campeonatos
{
    public static class CampeonatosProfile
    {
        public static MappingProfile AddMappersCampeonatos(this MappingProfile mapper)
        {
            return mapper
                .AddMapperTime()
                .AddMapperCampeonatoPartida();
        }

        private static MappingProfile AddMapperTime(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateTimeCommand, Time>();

            return mapper;
        }

        private static MappingProfile AddMapperCampeonatoPartida(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateCampeonatoPartidaCommand, CampeonatoPartida>();

            return mapper;
        }
    }
}
