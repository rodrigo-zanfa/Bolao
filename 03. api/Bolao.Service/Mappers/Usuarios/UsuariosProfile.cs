using Bolao.Domain.Commands.Usuarios;
using Bolao.Domain.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Mappers.Usuarios
{
    public static class UsuariosProfile
    {
        public static MappingProfile AddMappersUsuarios(this MappingProfile mapper)
        {
            return mapper
                .AddMapperUsuario();
        }

        private static MappingProfile AddMapperUsuario(this MappingProfile mapper)
        {
            mapper.CreateMap<CreateUsuarioCommand, Usuario>();

            return mapper;
        }
    }
}
