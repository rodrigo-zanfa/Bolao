using Dapper;
using Bolao.Domain.Entities.Produtos;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Produtos
{
    public class CaboRepository : ICaboRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public CaboRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<Cabo>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdCabo,
  c.Codigo Codigo,
  c.Descricao Descricao,
  c.Marca Marca,
  c.Modelo Modelo,
  c.Unidade Unidade,
  c.Id_Tipo_Inversor IdTipoInversor,
  c.Obs Observacao,
  c.Lg_Us_Inc UsuarioInclusao,
  c.Lg_Dt_Inc DataInclusao,
  c.Lg_Us_Alt UsuarioAlteracao,
  c.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Acessorios_Cabos_Proposta c
order by c.Codigo
";

            var result = await connection.QueryAsync<Cabo>(sql);

            return result;
        }

        public async Task<Cabo> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdCabo,
  c.Codigo Codigo,
  c.Descricao Descricao,
  c.Marca Marca,
  c.Modelo Modelo,
  c.Unidade Unidade,
  c.Id_Tipo_Inversor IdTipoInversor,
  c.Obs Observacao,
  c.Lg_Us_Inc UsuarioInclusao,
  c.Lg_Dt_Inc DataInclusao,
  c.Lg_Us_Alt UsuarioAlteracao,
  c.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Acessorios_Cabos_Proposta c
where c.Id = @IdCabo
order by c.Codigo
";

            var result = await connection.QueryFirstOrDefaultAsync<Cabo>(sql, new
            {
                IdCabo = id
            });

            return result;
        }

        public async Task<Cabo> GetByCodigoAsync(string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  c.Id IdCabo,
  c.Codigo Codigo,
  c.Descricao Descricao,
  c.Marca Marca,
  c.Modelo Modelo,
  c.Unidade Unidade,
  c.Id_Tipo_Inversor IdTipoInversor,
  c.Obs Observacao,
  c.Lg_Us_Inc UsuarioInclusao,
  c.Lg_Dt_Inc DataInclusao,
  c.Lg_Us_Alt UsuarioAlteracao,
  c.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Acessorios_Cabos_Proposta c
where c.Codigo = @Codigo
order by c.Codigo
";

            var result = await connection.QueryFirstOrDefaultAsync<Cabo>(sql, new
            {
                Codigo = codigo
            });

            return result;
        }

        public Task<int> CreateAsync(Cabo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Acessorios_Cabos_Proposta
(
  Codigo,
  Descricao,
  Marca,
  Modelo,
  Unidade,
  Id_Tipo_Inversor,
  Obs,
  Lg_Us_Inc,
  Lg_Dt_Inc,
  Lg_Us_Alt,
  Lg_Dt_Alt
)
values
(
  @Codigo,
  @Descricao,
  @Marca,
  @Modelo,
  @Unidade,
  @IdTipoInversor,
  @Observacao,
  @UsuarioInclusao,
  @DataInclusao,
  @UsuarioAlteracao,
  @DataAlteracao
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                IdTipoInversor = entity.Cabo.IdTipoInversor,
                Observacao = entity.Cabo.Observacao,
                UsuarioInclusao = entity.UsuarioInclusao,
                DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }

        public Task<int> UpdateAsync(Cabo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Acessorios_Cabos_Proposta set
  Codigo = @Codigo,
  Descricao = @Descricao,
  Marca = @Marca,
  Modelo = @Modelo,
  Unidade = @Unidade,
  Id_Tipo_Inversor = @IdTipoInversor,
  Obs = @Observacao,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao
where Id = @IdCabo
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdCabo = entity.Cabo.IdCabo,
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                IdTipoInversor = entity.Cabo.IdTipoInversor,
                Observacao = entity.Cabo.Observacao,
                //UsuarioInclusao = entity.UsuarioInclusao,
                //DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }
    }
}
