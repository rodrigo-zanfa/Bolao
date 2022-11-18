using Dapper.FluentMap;
using Bolao.Infrastructure.Mappers.Propostas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Mappers
{
    public static class RegisterMappers
    {
        public static void Configure()
        {
            FluentMapper.Initialize(config =>
            {
                config.AddMap(new AuxPropostaMap());
                config.AddMap(new AuxPropostaGridMap());

                //config.ForDommel();
            });
        }
    }
}
