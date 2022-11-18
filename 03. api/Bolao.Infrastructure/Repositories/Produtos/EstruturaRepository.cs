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
    public class EstruturaRepository : IEstruturaRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public EstruturaRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<Estrutura>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  e.Id_Proposta IdEstrutura,
  e.SKY Codigo,
  e.Descricao Descricao,
  e.Marca Marca,
  e.Modelo Modelo,
  e.Unidade Unidade,
  e.Quantidade Quantidade,
  e.Lg_Us_Inc UsuarioInclusao,
  e.Lg_Dt_Inc DataInclusao,
  e.Lg_Us_Alt UsuarioAlteracao,
  e.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Estrutura_Proposta e
order by e.SKY
";

            var result = await connection.QueryAsync<Estrutura>(sql);

            result = await CarregarDependenciasAsync(result);

            return result;
        }

        public async Task<Estrutura> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  e.Id_Proposta IdEstrutura,
  e.SKY Codigo,
  e.Descricao Descricao,
  e.Marca Marca,
  e.Modelo Modelo,
  e.Unidade Unidade,
  e.Quantidade Quantidade,
  e.Lg_Us_Inc UsuarioInclusao,
  e.Lg_Dt_Inc DataInclusao,
  e.Lg_Us_Alt UsuarioAlteracao,
  e.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Estrutura_Proposta e
where e.Id_Proposta = @IdEstrutura
order by e.SKY
";

            var result = await connection.QueryAsync<Estrutura>(sql, new
            {
                IdEstrutura = id
            });

            result = await CarregarDependenciasAsync(result);

            return result.FirstOrDefault();
        }

        public async Task<Estrutura> GetByCodigoAsync(string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select top 1
  e.Id_Proposta IdEstrutura,
  e.SKY Codigo,
  e.Descricao Descricao,
  e.Marca Marca,
  e.Modelo Modelo,
  e.Unidade Unidade,
  e.Quantidade Quantidade,
  e.Lg_Us_Inc UsuarioInclusao,
  e.Lg_Dt_Inc DataInclusao,
  e.Lg_Us_Alt UsuarioAlteracao,
  e.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Estrutura_Proposta e
where e.SKY = @Codigo
order by e.SKY
";

            var result = await connection.QueryAsync<Estrutura>(sql, new
            {
                Codigo = codigo
            });

            result = await CarregarDependenciasAsync(result);

            return result.FirstOrDefault();
        }

        private async Task<IEnumerable<Estrutura>> CarregarDependenciasAsync(IEnumerable<Estrutura> estruturas)
        {
            foreach (var estrutura in estruturas)
            {
                estrutura.IdTelhado = (List<int>)await GetIdsTelhadosByIdEstruturaAsync(estrutura.IdEstrutura);
            }

            return estruturas;
        }

        private async Task<IEnumerable<int>> GetIdsTelhadosByIdEstruturaAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  e.Id_Telhados IdTelhado
from Tc_Sge_Estrutura_Proposta e
where e.SKY = (
               select e.SKY
               from Tc_Sge_Estrutura_Proposta e
               where e.Id_Proposta = @IdEstrutura
              )
order by e.Id_Telhados
";

            var result = await connection.QueryAsync<int>(sql, new
            {
                IdEstrutura = id
            });

            return result;
        }

        private async Task<int> GetByIdEIdTelhadoAsync(int id, int idTelhado)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  e.Id_Proposta IdEstrutura
from Tc_Sge_Estrutura_Proposta e
where e.SKY = (
               -- localizando o Código original pelo Id do item, pois pode ter sido alterado
               select e.SKY
               from Tc_Sge_Estrutura_Proposta e
               where e.Id_Proposta = @IdEstrutura
              )
  and e.Id_Telhados = @IdTelhado
";

            var result = await connection.QueryFirstOrDefaultAsync<int>(sql, new
            {
                IdEstrutura = id,
                IdTelhado = idTelhado
            });

            return result;
        }

        public async Task<int> SaveAsync(Produto entity)
        {
            var result = 0;

            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            foreach (var idTelhado in entity.Estrutura.IdTelhado)
            {
                // verificar se já existe cadastrado (Codigo + IdTelhado)
                var id = await GetByIdEIdTelhadoAsync(entity.Estrutura.IdEstrutura, idTelhado);

                if (id == 0)  // se não existir, inserir
                {
                    result = await CreateAsync(entity, idTelhado);
                }
                else  // se existir, atualizar
                {
                    result = await UpdateAsync(entity, id, idTelhado);
                }
            }

            // remover tudo que não estava na lista
            result = await DeleteAsync(entity.Estrutura.IdEstrutura, entity.Estrutura.IdTelhado);

            return result;
        }

        public Task<int> CreateAsync(Estrutura entity)
        {
            throw new NotImplementedException();
        }

        private async Task<int> CreateAsync(Produto entity, int idTelhado)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Estrutura_Proposta
(
  SKY,
  Descricao,
  Marca,
  Modelo,
  Unidade,
  Quantidade,
  Id_Telhados,
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
  @Quantidade,
  @IdTelhado,
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
                Quantidade = entity.Estrutura.Quantidade,
                IdTelhado = idTelhado,  // entity.Estrutura.IdTelhado
                UsuarioInclusao = entity.UsuarioInclusao,
                DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }

        public Task<int> UpdateAsync(Estrutura entity)
        {
            throw new NotImplementedException();
        }

        private async Task<int> UpdateAsync(Produto entity, int id, int idTelhado)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Estrutura_Proposta set
  SKY = @Codigo,
  Descricao = @Descricao,
  Marca = @Marca,
  Modelo = @Modelo,
  Unidade = @Unidade,
  Quantidade = @Quantidade,
  Id_Telhados = @IdTelhado,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao
where Id_Proposta = @IdEstrutura
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdEstrutura = id,  // entity.Estrutura.IdEstrutura
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                Quantidade = entity.Estrutura.Quantidade,
                IdTelhado = idTelhado,  // entity.Estrutura.IdTelhado
                //UsuarioInclusao = entity.UsuarioInclusao,
                //DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }

        private async Task<int> DeleteAsync(int id, List<int> idTelhado)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
delete from Tc_Sge_Estrutura_Proposta
where SKY = (
             -- localizando o Código original pelo Id do item, pois pode ter sido alterado
             select e.SKY
             from Tc_Sge_Estrutura_Proposta e
             where e.Id_Proposta = @IdEstrutura
            )
  and Id_Telhados not in @IdTelhado
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdEstrutura = id,
                IdTelhado = idTelhado,  // entity.Estrutura.IdTelhado
            });

            return result;
        }
    }
}
