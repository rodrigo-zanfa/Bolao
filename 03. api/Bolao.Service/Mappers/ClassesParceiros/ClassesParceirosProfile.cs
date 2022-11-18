using Bolao.Domain.Commands.ClassesParceiros;
using Bolao.Domain.Entities.ClassesParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.ClassesParceiros
{
    public static class ClassesParceirosProfile
    {
        public static MappingProfile AddMappersClassesParceiros(this MappingProfile mapper)
        {
            return mapper
                .AddMapperClasseParceiro()
                .AddMapperClasseParceiroDistribuidor();
        }

        private static MappingProfile AddMapperClasseParceiro(this MappingProfile mapper)
        {
            mapper.CreateMap<UpdateClasseParceiroCommand, ClasseParceiro>();

            return mapper;
        }

        private static MappingProfile AddMapperClasseParceiroDistribuidor(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateClasseParceiroDistribuidorCommand, ClasseParceiroDistribuidor>()
                .ForPath(classeParceiroDistribuidor => classeParceiroDistribuidor.Loja.IdLoja, opt => opt.MapFrom(createClasseParceiroDistribuidorCommand => createClasseParceiroDistribuidorCommand.IdLoja));

            mapper.CreateMap<UpdateClasseParceiroDistribuidorCommand, ClasseParceiroDistribuidor>()
                .ForPath(classeParceiroDistribuidor => classeParceiroDistribuidor.Loja.IdLoja, opt => opt.MapFrom(updateClasseParceiroDistribuidorCommand => updateClasseParceiroDistribuidorCommand.IdLoja));

            return mapper;
        }
    }
}
