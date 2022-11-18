using Dapper;
using Bolao.Domain.Entities.ClassesParceiros;
using Bolao.Domain.Entities.Lojas;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.ClassesParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.ClassesParceiros
{
    public class ClasseParceiroDistribuidorRepository : IClasseParceiroDistribuidorRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public ClasseParceiroDistribuidorRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<ClasseParceiroDistribuidor>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cpd.Id IdClasseParceiroDistribuidor,
  cpd.Id_Classe_Parceiro IdClasseParceiro,
  cpd.Porcentagem_Parceiro PorcentagemParceiro,
  cpd.Id_Loja IdLoja,
  l.RSocial RazaoSocial,
  l.NomeFantasia NomeFantasia,
  dbo.Mascara_CGC(l.CNPJ) Cnpj,
  l.Endereco Endereco,
  l.Num_Endereco NumEndereco,
  l.Bairro Bairro,
  c.Cidade Cidade,
  l.Id_Estado Estado,
  dbo.Mascara_CEP(l.Cep) Cep,
  dbo.Mascara_Fone(l.Fone_DDD, l.Fone) Fone
from Tc_Sge_Classe_Parceiro_Distribuidor cpd
  inner join Tc_Sge_Loja l on cpd.Id_Loja = l.Id_Loja
  inner join Tc_Sge_Cidade c on l.Id_Cidade = c.Id_Cidade
order by cpd.Id
";

            var result = await connection.QueryAsync<ClasseParceiroDistribuidor, Loja, ClasseParceiroDistribuidor>(sql,
                map: (classeParceiroDistribuidor, loja) =>
                {
                    classeParceiroDistribuidor.Loja = loja;
                    return classeParceiroDistribuidor;
                },
                splitOn: "IdLoja");

            return result;
        }

        public async Task<ClasseParceiroDistribuidor> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cpd.Id IdClasseParceiroDistribuidor,
  cpd.Id_Classe_Parceiro IdClasseParceiro,
  cpd.Porcentagem_Parceiro PorcentagemParceiro,
  cpd.Id_Loja IdLoja,
  l.RSocial RazaoSocial,
  l.NomeFantasia NomeFantasia,
  dbo.Mascara_CGC(l.CNPJ) Cnpj,
  l.Endereco Endereco,
  l.Num_Endereco NumEndereco,
  l.Bairro Bairro,
  c.Cidade Cidade,
  l.Id_Estado Estado,
  dbo.Mascara_CEP(l.Cep) Cep,
  dbo.Mascara_Fone(l.Fone_DDD, l.Fone) Fone
from Tc_Sge_Classe_Parceiro_Distribuidor cpd
  inner join Tc_Sge_Loja l on cpd.Id_Loja = l.Id_Loja
  inner join Tc_Sge_Cidade c on l.Id_Cidade = c.Id_Cidade
where cpd.Id = @IdClasseParceiroDistribuidor
order by cpd.Id
";

            var result = await connection.QueryAsync<ClasseParceiroDistribuidor, Loja, ClasseParceiroDistribuidor>(sql,
                map: (classeParceiroDistribuidor, loja) =>
                {
                    classeParceiroDistribuidor.Loja = loja;
                    return classeParceiroDistribuidor;
                },
                param: new
                {
                    IdClasseParceiroDistribuidor = id
                },
                splitOn: "IdLoja");

            return result.FirstOrDefault();
        }

        public async Task<ClasseParceiroDistribuidor> GetByLojaAsync(int idLoja)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cpd.Id IdClasseParceiroDistribuidor,
  cpd.Id_Classe_Parceiro IdClasseParceiro,
  cpd.Porcentagem_Parceiro PorcentagemParceiro,
  cpd.Id_Loja IdLoja,
  l.RSocial RazaoSocial,
  l.NomeFantasia NomeFantasia,
  dbo.Mascara_CGC(l.CNPJ) Cnpj,
  l.Endereco Endereco,
  l.Num_Endereco NumEndereco,
  l.Bairro Bairro,
  c.Cidade Cidade,
  l.Id_Estado Estado,
  dbo.Mascara_CEP(l.Cep) Cep,
  dbo.Mascara_Fone(l.Fone_DDD, l.Fone) Fone
from Tc_Sge_Classe_Parceiro_Distribuidor cpd
  inner join Tc_Sge_Loja l on cpd.Id_Loja = l.Id_Loja
  inner join Tc_Sge_Cidade c on l.Id_Cidade = c.Id_Cidade
where cpd.Id_Loja = @IdLoja
order by cpd.Id
";

            var result = await connection.QueryAsync<ClasseParceiroDistribuidor, Loja, ClasseParceiroDistribuidor>(sql,
                map: (classeParceiroDistribuidor, loja) =>
                {
                    classeParceiroDistribuidor.Loja = loja;
                    return classeParceiroDistribuidor;
                },
                param: new
                {
                    IdLoja = idLoja
                },
                splitOn: "IdLoja");

            return result.FirstOrDefault();
        }

        public async Task<int> CreateAsync(ClasseParceiroDistribuidor entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Tc_Sge_Classe_Parceiro_Distribuidor
(
  Id_Loja,
  Id_Classe_Parceiro,
  Porcentagem_Parceiro
)
values
(
  @IdLoja,
  @IdClasseParceiro,
  @PorcentagemParceiro
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdLoja = entity.Loja.IdLoja,
                IdClasseParceiro = entity.IdClasseParceiro,
                PorcentagemParceiro = entity.PorcentagemParceiro
            });

            return result;
        }

        public async Task<int> UpdateAsync(ClasseParceiroDistribuidor entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Classe_Parceiro_Distribuidor set
  Id_Loja = @IdLoja,
  Id_Classe_Parceiro = @IdClasseParceiro,
  Porcentagem_Parceiro = @PorcentagemParceiro
where Id = @IdClasseParceiroDistribuidor
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdClasseParceiroDistribuidor = entity.IdClasseParceiroDistribuidor,
                IdLoja = entity.Loja.IdLoja,
                IdClasseParceiro = entity.IdClasseParceiro,
                PorcentagemParceiro = entity.PorcentagemParceiro
            });

            return result;
        }
    }
}
