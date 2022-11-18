using Dapper;
using Bolao.Domain.Entities.MarcasEstruturas;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.MarcasEstruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.MarcasEstruturas
{
    public class MarcaEstruturaRepository : IMarcaEstruturaRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public MarcaEstruturaRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<MarcaEstrutura>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  me.Id_Marca_Estrutura IdMarcaEstrutura,
  me.Desc_Marca_Estrutura Descricao,
  me.Lo_Ativo Ativo,
  me.Lg_Us_Inc UsuarioInclusao,
  me.Lg_Dt_Inc DataInclusao,
  me.Lg_Us_Alt UsuarioAlteracao,
  me.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Marca_Estrutura me
order by me.Desc_Marca_Estrutura
";

            var result = await connection.QueryAsync<MarcaEstrutura>(sql);

            return result;
        }

        public Task<MarcaEstrutura> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(MarcaEstrutura entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(MarcaEstrutura entity)
        {
            throw new NotImplementedException();
        }
    }
}
