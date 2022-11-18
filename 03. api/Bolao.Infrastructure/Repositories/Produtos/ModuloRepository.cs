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
    public class ModuloRepository : IModuloRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public ModuloRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<Modulo>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  m.Id_Modulo IdModulo,
  m.Cod_Produto Codigo,
  m.Desc_Modulo Descricao,
  m.Desc_Modulo_Grid DescricaoGrid,
  m.Marca Marca,
  m.Modelo Modelo,
  m.Unidade Unidade,
  m.Potencia_Wp Potencia,
  m.CorrenteMaxPotencia_Imp CorrenteMaxima,
  m.TensaoMaxPotencia_Vmp TensaoMaxima,
  m.CorrenteCurtoCircuito_Isc CorrenteCurtoCircuito,
  m.TensaoCircuitoAberto_Voc TensaoCircuitoAberto,
  m.Coef_porcentagem Coeficiente,
  m.Comprimento_mm Comprimento,
  m.Largura_mm Largura,
  m.Espessura_mm Espessura,
  m.Lo_Ativo Ativo,
  m.Lg_Us_Inc UsuarioInclusao,
  m.Lg_Dt_Inc DataInclusao,
  m.Lg_Us_Alt UsuarioAlteracao,
  m.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Modulo_Nova m
order by m.Cod_Produto
";

            var result = await connection.QueryAsync<Modulo>(sql);

            return result;
        }

        public async Task<Modulo> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  m.Id_Modulo IdModulo,
  m.Cod_Produto Codigo,
  m.Desc_Modulo Descricao,
  m.Desc_Modulo_Grid DescricaoGrid,
  m.Marca Marca,
  m.Modelo Modelo,
  m.Unidade Unidade,
  m.Potencia_Wp Potencia,
  m.CorrenteMaxPotencia_Imp CorrenteMaxima,
  m.TensaoMaxPotencia_Vmp TensaoMaxima,
  m.CorrenteCurtoCircuito_Isc CorrenteCurtoCircuito,
  m.TensaoCircuitoAberto_Voc TensaoCircuitoAberto,
  m.Coef_porcentagem Coeficiente,
  m.Comprimento_mm Comprimento,
  m.Largura_mm Largura,
  m.Espessura_mm Espessura,
  m.Lo_Ativo Ativo,
  m.Lg_Us_Inc UsuarioInclusao,
  m.Lg_Dt_Inc DataInclusao,
  m.Lg_Us_Alt UsuarioAlteracao,
  m.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Modulo_Nova m
where m.Id_Modulo = @IdModulo
order by m.Cod_Produto
";

            var result = await connection.QueryFirstOrDefaultAsync<Modulo>(sql, new
            {
                IdModulo = id
            });

            return result;
        }

        public async Task<Modulo> GetByCodigoAsync(string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  m.Id_Modulo IdModulo,
  m.Cod_Produto Codigo,
  m.Desc_Modulo Descricao,
  m.Desc_Modulo_Grid DescricaoGrid,
  m.Marca Marca,
  m.Modelo Modelo,
  m.Unidade Unidade,
  m.Potencia_Wp Potencia,
  m.CorrenteMaxPotencia_Imp CorrenteMaxima,
  m.TensaoMaxPotencia_Vmp TensaoMaxima,
  m.CorrenteCurtoCircuito_Isc CorrenteCurtoCircuito,
  m.TensaoCircuitoAberto_Voc TensaoCircuitoAberto,
  m.Coef_porcentagem Coeficiente,
  m.Comprimento_mm Comprimento,
  m.Largura_mm Largura,
  m.Espessura_mm Espessura,
  m.Lo_Ativo Ativo,
  m.Lg_Us_Inc UsuarioInclusao,
  m.Lg_Dt_Inc DataInclusao,
  m.Lg_Us_Alt UsuarioAlteracao,
  m.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Modulo_Nova m
where m.Cod_Produto = @Codigo
order by m.Cod_Produto
";

            var result = await connection.QueryFirstOrDefaultAsync<Modulo>(sql, new
            {
                Codigo = codigo
            });

            return result;
        }

        public Task<int> CreateAsync(Modulo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Modulo_Nova
(
  Cod_Produto,
  Desc_Modulo,
  Desc_Modulo_Grid,
  Marca,
  Modelo,
  Unidade,
  Potencia_Wp,
  CorrenteMaxPotencia_Imp,
  TensaoMaxPotencia_Vmp,
  CorrenteCurtoCircuito_Isc,
  TensaoCircuitoAberto_Voc,
  Coef_porcentagem,
  Comprimento_mm,
  Largura_mm,
  Espessura_mm,
  Lo_Ativo,
  Lg_Us_Inc,
  Lg_Dt_Inc,
  Lg_Us_Alt,
  Lg_Dt_Alt
)
values
(
  @Codigo,
  @Descricao,
  @DescricaoGrid,
  @Marca,
  @Modelo,
  @Unidade,
  @Potencia,
  @CorrenteMaxima,
  @TensaoMaxima,
  @CorrenteCurtoCircuito,
  @TensaoCircuitoAberto,
  @Coeficiente,
  @Comprimento,
  @Largura,
  @Espessura,
  @Ativo,
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
                DescricaoGrid = entity.Modulo.DescricaoGrid,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                Potencia = entity.Modulo.Potencia,
                CorrenteMaxima = entity.Modulo.CorrenteMaxima,
                TensaoMaxima = entity.Modulo.TensaoMaxima,
                CorrenteCurtoCircuito = entity.Modulo.CorrenteCurtoCircuito,
                TensaoCircuitoAberto = entity.Modulo.TensaoCircuitoAberto,
                Coeficiente = entity.Modulo.Coeficiente,
                Comprimento = entity.Modulo.Comprimento,
                Largura = entity.Modulo.Largura,
                Espessura = entity.Modulo.Espessura,
                Ativo = entity.Ativo,
                UsuarioInclusao = entity.UsuarioInclusao,
                DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }

        public Task<int> UpdateAsync(Modulo entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Modulo_Nova set
  Cod_Produto = @Codigo,
  Desc_Modulo = @Descricao,
  Desc_Modulo_Grid = @DescricaoGrid,
  Marca = @Marca,
  Modelo = @Modelo,
  Unidade = @Unidade,
  Potencia_Wp = @Potencia,
  CorrenteMaxPotencia_Imp = @CorrenteMaxima,
  TensaoMaxPotencia_Vmp = @TensaoMaxima,
  CorrenteCurtoCircuito_Isc = @CorrenteCurtoCircuito,
  TensaoCircuitoAberto_Voc = @TensaoCircuitoAberto,
  Coef_porcentagem = @Coeficiente,
  Comprimento_mm = @Comprimento,
  Largura_mm = @Largura,
  Espessura_mm = @Espessura,
  Lo_Ativo = @Ativo,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao
where Id_Modulo = @IdModulo
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdModulo = entity.Modulo.IdModulo,
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                DescricaoGrid = entity.Modulo.DescricaoGrid,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                Potencia = entity.Modulo.Potencia,
                CorrenteMaxima = entity.Modulo.CorrenteMaxima,
                TensaoMaxima = entity.Modulo.TensaoMaxima,
                CorrenteCurtoCircuito = entity.Modulo.CorrenteCurtoCircuito,
                TensaoCircuitoAberto = entity.Modulo.TensaoCircuitoAberto,
                Coeficiente = entity.Modulo.Coeficiente,
                Comprimento = entity.Modulo.Comprimento,
                Largura = entity.Modulo.Largura,
                Espessura = entity.Modulo.Espessura,
                Ativo = entity.Ativo,
                //UsuarioInclusao = entity.UsuarioInclusao,
                //DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }
    }
}
