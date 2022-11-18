using Dapper;
using Bolao.Domain.Entities.Produtos;
using Bolao.Domain.Enums.Produtos;
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
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;
        private readonly IEstruturaRepository _estruturaRepository;
        private readonly IInversorRepository _inversorRepository;
        private readonly ICaboRepository _caboRepository;
        private readonly IModuloRepository _moduloRepository;

        public ProdutoRepository(IApiSettingsAccessor apiSettingsAccessor, IEstruturaRepository estruturaRepository, IInversorRepository inversorRepository, ICaboRepository caboRepository, IModuloRepository moduloRepository)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
            _estruturaRepository = estruturaRepository;
            _inversorRepository = inversorRepository;
            _caboRepository = caboRepository;
            _moduloRepository = moduloRepository;
        }

        public async Task<IEnumerable<Produto>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  p.IdProduto IdProduto,
  p.Cod_Produto Codigo,
  p.Desc_Produto Descricao,
  p.Marca Marca,
  p.Modelo Modelo,
  p.Unidade Unidade,
  p.Valor Valor,
  p.Lo_Ativo Ativo,
  p.Lg_Us_Inc UsuarioInclusao,
  p.Lg_Dt_Inc DataInclusao,
  p.Lg_Us_Alt UsuarioAlteracao,
  p.Lg_Dt_Alt DataAlteracao,
  p.IdProdutoTipo IdProdutoTipo,
  pt.DescrProdutoTipo Descricao
from Tc_Sge_Produto p
  inner join Tc_Sge_Produto_Tipo pt on p.IdProdutoTipo = pt.IdProdutoTipo
order by p.Cod_Produto
";

            var result = await connection.QueryAsync<Produto, ProdutoTipo, Produto>(sql,
                map: (produto, produtoTipo) =>
                {
                    produto.ProdutoTipo = produtoTipo;
                    return produto;
                },
                splitOn: "IdProdutoTipo");

            return result;
        }

        public async Task<Produto> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  p.IdProduto IdProduto,
  p.Cod_Produto Codigo,
  p.Desc_Produto Descricao,
  p.Marca Marca,
  p.Modelo Modelo,
  p.Unidade Unidade,
  p.Valor Valor,
  p.Lo_Ativo Ativo,
  p.Lg_Us_Inc UsuarioInclusao,
  p.Lg_Dt_Inc DataInclusao,
  p.Lg_Us_Alt UsuarioAlteracao,
  p.Lg_Dt_Alt DataAlteracao,
  p.IdProdutoTipo IdProdutoTipo,
  pt.DescrProdutoTipo Descricao
from Tc_Sge_Produto p
  inner join Tc_Sge_Produto_Tipo pt on p.IdProdutoTipo = pt.IdProdutoTipo
where p.IdProduto = @IdProduto
order by p.Cod_Produto
";

            var result = await connection.QueryAsync<Produto, ProdutoTipo, Produto>(sql,
                map: (produto, produtoTipo) =>
                {
                    produto.ProdutoTipo = produtoTipo;
                    return produto;
                },
                param: new
                {
                    IdProduto = id
                },
                splitOn: "IdProdutoTipo");

            result = await CarregarDependenciasAsync(result);

            return result.FirstOrDefault();
        }

        public async Task<Produto> GetByCodigoAsync(string codigo)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  p.IdProduto IdProduto,
  p.Cod_Produto Codigo,
  p.Desc_Produto Descricao,
  p.Marca Marca,
  p.Modelo Modelo,
  p.Unidade Unidade,
  p.Valor Valor,
  p.Lo_Ativo Ativo,
  p.Lg_Us_Inc UsuarioInclusao,
  p.Lg_Dt_Inc DataInclusao,
  p.Lg_Us_Alt UsuarioAlteracao,
  p.Lg_Dt_Alt DataAlteracao,
  p.IdProdutoTipo IdProdutoTipo,
  pt.DescrProdutoTipo Descricao
from Tc_Sge_Produto p
  inner join Tc_Sge_Produto_Tipo pt on p.IdProdutoTipo = pt.IdProdutoTipo
where p.Cod_Produto = @Codigo
order by p.Cod_Produto
";

            var result = await connection.QueryAsync<Produto, ProdutoTipo, Produto>(sql,
                map: (produto, produtoTipo) =>
                {
                    produto.ProdutoTipo = produtoTipo;
                    return produto;
                },
                param: new
                {
                    Codigo = codigo
                },
                splitOn: "IdProdutoTipo");

            result = await CarregarDependenciasAsync(result);

            return result.FirstOrDefault();
        }

        private async Task<IEnumerable<Produto>> CarregarDependenciasAsync(IEnumerable<Produto> produtos)
        {
            foreach (var produto in produtos)
            {
                switch (produto.ProdutoTipo.IdProdutoTipo)
                {
                    case (int)ProdutoTipoEnum.Estrutura:
                        produto.Estrutura = await _estruturaRepository.GetByCodigoAsync(produto.Codigo);
                        break;
                    case (int)ProdutoTipoEnum.Inversor:
                        produto.Inversor = await _inversorRepository.GetByCodigoAsync(produto.Codigo);
                        break;
                    case (int)ProdutoTipoEnum.Cabo:
                        produto.Cabo = await _caboRepository.GetByCodigoAsync(produto.Codigo);
                        break;
                    case (int)ProdutoTipoEnum.Modulo:
                        produto.Modulo = await _moduloRepository.GetByCodigoAsync(produto.Codigo);
                        break;
                }
            }

            return produtos;
        }

        public async Task<int> CreateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Produto
(
  IdProdutoTipo,
  Cod_Produto,
  Desc_Produto,
  Marca,
  Modelo,
  Unidade,
  Valor,
  Lo_Ativo,
  Lg_Us_Inc,
  Lg_Dt_Inc,
  Lg_Us_Alt,
  Lg_Dt_Alt
)
values
(
  @IdProdutoTipo,
  @Codigo,
  @Descricao,
  @Marca,
  @Modelo,
  @Unidade,
  @Valor,
  @Ativo,
  @UsuarioInclusao,
  @DataInclusao,
  @UsuarioAlteracao,
  @DataAlteracao
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdProdutoTipo = entity.ProdutoTipo.IdProdutoTipo,
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                Valor = entity.Valor,
                Ativo = entity.Ativo,
                UsuarioInclusao = entity.UsuarioInclusao,
                DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            switch (entity.ProdutoTipo.IdProdutoTipo)
            {
                case (int)ProdutoTipoEnum.Estrutura:
                    result = await _estruturaRepository.SaveAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Inversor:
                    result = await _inversorRepository.CreateAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Cabo:
                    result = await _caboRepository.CreateAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Modulo:
                    result = await _moduloRepository.CreateAsync(entity);
                    break;
            }

            return result;
        }

        public async Task<int> UpdateAsync(Produto entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Produto set
  --IdProdutoTipo = @IdProdutoTipo,
  Cod_Produto = @Codigo,
  Desc_Produto = @Descricao,
  Marca = @Marca,
  Modelo = @Modelo,
  Unidade = @Unidade,
  Valor = @Valor,
  Lo_Ativo = @Ativo,
  --Lg_Us_Inc = @UsuarioInclusao,
  --Lg_Dt_Inc = @DataInclusao,
  Lg_Us_Alt = @UsuarioAlteracao,
  Lg_Dt_Alt = @DataAlteracao
where IdProduto = @IdProduto
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdProduto = entity.IdProduto,
                //IdProdutoTipo = entity.IdProdutoTipo,
                Codigo = entity.Codigo,
                Descricao = entity.Descricao,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Unidade = entity.Unidade,
                Valor = entity.Valor,
                Ativo = entity.Ativo,
                //UsuarioInclusao = entity.UsuarioInclusao,
                //DataInclusao = DateTime.Now,  // entity.DataInclusao
                UsuarioAlteracao = entity.UsuarioAlteracao,
                DataAlteracao = DateTime.Now  // entity.DataAlteracao
            });

            switch (entity.ProdutoTipo.IdProdutoTipo)
            {
                case (int)ProdutoTipoEnum.Estrutura:
                    result = await _estruturaRepository.SaveAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Inversor:
                    result = await _inversorRepository.UpdateAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Cabo:
                    result = await _caboRepository.UpdateAsync(entity);
                    break;
                case (int)ProdutoTipoEnum.Modulo:
                    result = await _moduloRepository.UpdateAsync(entity);
                    break;
            }

            return result;
        }
    }
}
