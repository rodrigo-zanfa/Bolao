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
    public class InversorRepository : IInversorRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public InversorRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<Inversor>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  i.Id_Inversor IdInversor,
  i.Cod_Produto Codigo,
  --i.Desc_Inversor Descricao,
  i.Id_Marca IdMarca,
  i.Desc_Modelo Modelo,
  i.Unidade Unidade,
  i.Id_Fase IdFase,
  i.Vca TensaoCA,
  i.Vcc TensaoCC,
  i.Pout PotenciaSaida,
  i.PotenciaMinima PotenciaMinima,
  i.PotenciaMaxima PotenciaMaxima,
  i.PotenciaRecomendada PotenciaRecomendada,
  i.Vinmin TensaoMinimaEntrada,
  i.Vstart TensaoMinimaLigar,
  i.MPPT QuantidadeMPPT,
  i.STG QuantidadeStrings,
  i.Ica CorrenteCA,
  i.Flg_Tipo Tipo,
  i.Id_Fase_Conjugada IdFaseConjugada,
  i.Id_Fase_Conjugada2 IdFaseConjugada2,
  i.Id_Fase_Conjugada3_Trifasica_380V IdFaseConjugada3Trifasica380V,
  i.ModuloMinimo ModuloMinimo,
  i.ModuloMaximo ModuloMaximo,
  i.CorrenteCurtoCircuito CorrenteCurtoCircuito,
  i.Lo_Ativo Ativo,
  i.Lg_Us_Inc UsuarioInclusao,
  i.Lg_Dt_Inc DataInclusao,
  i.Lg_Us_Alt UsuarioAlteracao,
  i.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Inversor_Nova i
order by i.Cod_Produto
";

            var result = await connection.QueryAsync<Inversor>(sql);

            return result;
        }

        public async Task<Inversor> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  i.Id_Inversor IdInversor,
  i.Cod_Produto Codigo,
  --i.Desc_Inversor Descricao,
  i.Id_Marca IdMarca,
  i.Desc_Modelo Modelo,
  i.Unidade Unidade,
  i.Id_Fase IdFase,
  i.Vca TensaoCA,
  i.Vcc TensaoCC,
  i.Pout PotenciaSaida,
  i.PotenciaMinima PotenciaMinima,
  i.PotenciaMaxima PotenciaMaxima,
  i.PotenciaRecomendada PotenciaRecomendada,
  i.Vinmin TensaoMinimaEntrada,
  i.Vstart TensaoMinimaLigar,
  i.MPPT QuantidadeMPPT,
  i.STG QuantidadeStrings,
  i.Ica CorrenteCA,
  i.Flg_Tipo Tipo,
  i.Id_Fase_Conjugada IdFaseConjugada,
  i.Id_Fase_Conjugada2 IdFaseConjugada2,
  i.Id_Fase_Conjugada3_Trifasica_380V IdFaseConjugada3Trifasica380V,
  i.ModuloMinimo ModuloMinimo,
  i.ModuloMaximo ModuloMaximo,
  i.CorrenteCurtoCircuito CorrenteCurtoCircuito,
  i.Lo_Ativo Ativo,
  i.Lg_Us_Inc UsuarioInclusao,
  i.Lg_Dt_Inc DataInclusao,
  i.Lg_Us_Alt UsuarioAlteracao,
  i.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Inversor_Nova i
where i.Id_Inversor = @IdInversor
order by i.Cod_Produto
";

            var result = await connection.QueryFirstOrDefaultAsync<Inversor>(sql, new
            {
                IdInversor = id
            });

            return result;
        }

        public async Task<Inversor> GetByCodigoAsync(string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  i.Id_Inversor IdInversor,
  i.Cod_Produto Codigo,
  --i.Desc_Inversor Descricao,
  i.Id_Marca IdMarca,
  i.Desc_Modelo Modelo,
  i.Unidade Unidade,
  i.Id_Fase IdFase,
  i.Vca TensaoCA,
  i.Vcc TensaoCC,
  i.Pout PotenciaSaida,
  i.PotenciaMinima PotenciaMinima,
  i.PotenciaMaxima PotenciaMaxima,
  i.PotenciaRecomendada PotenciaRecomendada,
  i.Vinmin TensaoMinimaEntrada,
  i.Vstart TensaoMinimaLigar,
  i.MPPT QuantidadeMPPT,
  i.STG QuantidadeStrings,
  i.Ica CorrenteCA,
  i.Flg_Tipo Tipo,
  i.Id_Fase_Conjugada IdFaseConjugada,
  i.Id_Fase_Conjugada2 IdFaseConjugada2,
  i.Id_Fase_Conjugada3_Trifasica_380V IdFaseConjugada3Trifasica380V,
  i.ModuloMinimo ModuloMinimo,
  i.ModuloMaximo ModuloMaximo,
  i.CorrenteCurtoCircuito CorrenteCurtoCircuito,
  i.Lo_Ativo Ativo,
  i.Lg_Us_Inc UsuarioInclusao,
  i.Lg_Dt_Inc DataInclusao,
  i.Lg_Us_Alt UsuarioAlteracao,
  i.Lg_Dt_Alt DataAlteracao
from Tc_Sge_Inversor_Nova i
where i.Cod_Produto = @Codigo
order by i.Cod_Produto
";

            var result = await connection.QueryFirstOrDefaultAsync<Inversor>(sql, new
            {
                Codigo = codigo
            });

            return result;
        }

        public Task<int> CreateAsync(Inversor entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Inversor_Nova
(
  Cod_Produto,
  --Desc_Inversor,
  Id_Marca,
  Desc_Modelo,
  Unidade,
  Id_Fase,
  Vca,
  Vcc,
  Pout,
  PotenciaMinima,
  PotenciaMaxima,
  PotenciaRecomendada,
  Vinmin,
  Vstart,
  MPPT,
  STG,
  Ica,
  Flg_Tipo,
  Id_Fase_Conjugada,
  Id_Fase_Conjugada2,
  Id_Fase_Conjugada3_Trifasica_380V,
  ModuloMinimo,
  ModuloMaximo,
  CorrenteCurtoCircuito,
  Lo_Ativo,
  Lg_Us_Inc,
  Lg_Dt_Inc,
  Lg_Us_Alt,
  Lg_Dt_Alt
)
values
(
  @Codigo,
  --@Descricao,
  @IdMarca,
  @Modelo,
  @Unidade,
  @IdFase,
  @TensaoCA,
  @TensaoCC,
  @PotenciaSaida,
  @PotenciaMinima,
  @PotenciaMaxima,
  @PotenciaRecomendada,
  @TensaoMinimaEntrada,
  @TensaoMinimaLigar,
  @QuantidadeMPPT,
  @QuantidadeStrings,
  @CorrenteCA,
  @Tipo,
  @IdFaseConjugada,
  @IdFaseConjugada2,
  @IdFaseConjugada3Trifasica380V,
  @ModuloMinimo,
  @ModuloMaximo,
  @CorrenteCurtoCircuito,
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
                //Descricao = entity.Descricao,
                IdMarca = entity.Inversor.IdMarca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                IdFase = entity.Inversor.IdFase,
                TensaoCA = entity.Inversor.TensaoCA,
                TensaoCC = entity.Inversor.TensaoCC,
                PotenciaSaida = entity.Inversor.PotenciaSaida,
                PotenciaMinima = entity.Inversor.PotenciaMinima,
                PotenciaMaxima = entity.Inversor.PotenciaMaxima,
                PotenciaRecomendada = entity.Inversor.PotenciaRecomendada,
                TensaoMinimaEntrada = entity.Inversor.TensaoMinimaEntrada,
                TensaoMinimaLigar = entity.Inversor.TensaoMinimaLigar,
                QuantidadeMPPT = entity.Inversor.QuantidadeMPPT,
                QuantidadeStrings = entity.Inversor.QuantidadeStrings,
                CorrenteCA = entity.Inversor.CorrenteCA,
                Tipo = entity.Inversor.Tipo,
                IdFaseConjugada = entity.Inversor.IdFaseConjugada,
                IdFaseConjugada2 = entity.Inversor.IdFaseConjugada2,
                IdFaseConjugada3Trifasica380V = entity.Inversor.IdFaseConjugada3Trifasica380V,
                ModuloMinimo = entity.Inversor.ModuloMinimo,
                ModuloMaximo = entity.Inversor.ModuloMaximo,
                CorrenteCurtoCircuito = entity.Inversor.CorrenteCurtoCircuito,
                Ativo = entity.Ativo,
                UsuarioInclusao = entity.UsuarioInclusao,
                DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            return result;
        }

        public Task<int> UpdateAsync(Inversor entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Inversor_Nova set
  Cod_Produto = @Codigo,
  --Desc_Inversor = @Descricao,
  Id_Marca = @IdMarca,
  Desc_Modelo = @Modelo,
  Unidade = @Unidade,
  Id_Fase = @IdFase,
  Vca = @TensaoCA,
  Vcc = @TensaoCC,
  Pout = @PotenciaSaida,
  PotenciaMinima = @PotenciaMinima,
  PotenciaMaxima = @PotenciaMaxima,
  PotenciaRecomendada = @PotenciaRecomendada,
  Vinmin = @TensaoMinimaEntrada,
  Vstart = @TensaoMinimaLigar,
  MPPT = @QuantidadeMPPT,
  STG = @QuantidadeStrings,
  Ica = @CorrenteCA,
  Flg_Tipo = @Tipo,
  Id_Fase_Conjugada = @IdFaseConjugada,
  Id_Fase_Conjugada2 = @IdFaseConjugada2,
  Id_Fase_Conjugada3_Trifasica_380V = @IdFaseConjugada3Trifasica380V,
  ModuloMinimo = @ModuloMinimo,
  ModuloMaximo = @ModuloMaximo,
  CorrenteCurtoCircuito = @CorrenteCurtoCircuito,
  Lo_Ativo = @Ativo,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao
where Id_Inversor = @IdInversor
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdInversor = entity.Inversor.IdInversor,
                Codigo = entity.Codigo,
                //Descricao = entity.Descricao,
                IdMarca = entity.Inversor.IdMarca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                IdFase = entity.Inversor.IdFase,
                TensaoCA = entity.Inversor.TensaoCA,
                TensaoCC = entity.Inversor.TensaoCC,
                PotenciaSaida = entity.Inversor.PotenciaSaida,
                PotenciaMinima = entity.Inversor.PotenciaMinima,
                PotenciaMaxima = entity.Inversor.PotenciaMaxima,
                PotenciaRecomendada = entity.Inversor.PotenciaRecomendada,
                TensaoMinimaEntrada = entity.Inversor.TensaoMinimaEntrada,
                TensaoMinimaLigar = entity.Inversor.TensaoMinimaLigar,
                QuantidadeMPPT = entity.Inversor.QuantidadeMPPT,
                QuantidadeStrings = entity.Inversor.QuantidadeStrings,
                CorrenteCA = entity.Inversor.CorrenteCA,
                Tipo = entity.Inversor.Tipo,
                IdFaseConjugada = entity.Inversor.IdFaseConjugada,
                IdFaseConjugada2 = entity.Inversor.IdFaseConjugada2,
                IdFaseConjugada3Trifasica380V = entity.Inversor.IdFaseConjugada3Trifasica380V,
                ModuloMinimo = entity.Inversor.ModuloMinimo,
                ModuloMaximo = entity.Inversor.ModuloMaximo,
                CorrenteCurtoCircuito = entity.Inversor.CorrenteCurtoCircuito,
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
