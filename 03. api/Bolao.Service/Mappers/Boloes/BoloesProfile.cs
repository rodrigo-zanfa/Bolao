using Bolao.Domain.Commands.Boloes;
using Bolao.Domain.Entities.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.Boloes
{
    public static class BoloesProfile
    {
        public static MappingProfile AddMappersBoloes(this MappingProfile mapper)
        {
            return mapper
                .AddMapperBolaoPalpite();
        }

        private static MappingProfile AddMapperBolaoPalpite(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateBolaoPalpiteCommand, BolaoPalpite>();

            return mapper;
        }
    }
}
