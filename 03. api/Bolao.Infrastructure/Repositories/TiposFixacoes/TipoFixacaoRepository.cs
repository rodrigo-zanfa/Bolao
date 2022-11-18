using Dapper;
using Bolao.Domain.Entities.MarcasEstruturas;
using Bolao.Domain.Entities.TiposFixacoes;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.TiposFixacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.TiposFixacoes
{
    public class TipoFixacaoRepository : ITipoFixacaoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public TipoFixacaoRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<TipoFixacao>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  t.Id_Telhado IdTipoFixacao,
  t.Desc_Telhado Descricao,
  t.Lg_Us_Inc UsuarioInclusao,
  t.Lg_Dt_Inc DataInclusao,
  t.Lg_Us_Alt UsuarioAlteracao,
  t.Lg_Dt_Alt DataAlteracao,
  t.Id_Marca_Estrutura IdMarcaEstrutura,
  me.Desc_Marca_Estrutura Descricao
from Tc_Sge_Telhado t
  inner join Tc_Sge_Marca_Estrutura me on t.Id_Marca_Estrutura = me.Id_Marca_Estrutura
order by t.Desc_Telhado
";

            var result = await connection.QueryAsync<TipoFixacao, MarcaEstrutura, TipoFixacao>(sql,
                map: (tipoFixacao, marcaEstrutura) =>
                {
                    tipoFixacao.MarcaEstrutura = marcaEstrutura;
                    return tipoFixacao;
                },
                splitOn: "IdMarcaEstrutura");

            return result;
        }

        public async Task<IEnumerable<TipoFixacao>> GetAllByMarcaEstruturaAsync(int idMarcaEstrutura)
        {
            var result = await GetAllAsync();

            return result.Where(x => x.MarcaEstrutura.IdMarcaEstrutura == idMarcaEstrutura);
        }

        public Task<TipoFixacao> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateAsync(TipoFixacao entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(TipoFixacao entity)
        {
            throw new NotImplementedException();
        }
    }
}
