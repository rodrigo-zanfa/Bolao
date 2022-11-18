using Dapper;
using Bolao.Domain.Entities.ClassesParceiros;
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
    public class ClasseParceiroRepository : IClasseParceiroRepository
    {
        private readonly IApiSettingsAccessor _apiSettingsAccessor;

        public ClasseParceiroRepository(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }

        public async Task<IEnumerable<ClasseParceiro>> GetAllAsync()
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cp.Id IdClasseParceiro,
  cp.Classe Descricao,
  cp.Porcentagem_Elsys PorcentagemElsys
from Tc_Sge_Classe_Parceiro cp
order by cp.Classe
";

            var result = await connection.QueryAsync<ClasseParceiro>(sql);

            return result;
        }

        public async Task<ClasseParceiro> GetByIdAsync(int id)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  cp.Id IdClasseParceiro,
  cp.Classe Descricao,
  cp.Porcentagem_Elsys PorcentagemElsys
from Tc_Sge_Classe_Parceiro cp
where cp.Id = @IdClasseParceiro
order by cp.Classe
";

            var result = await connection.QueryFirstOrDefaultAsync<ClasseParceiro>(sql, new
            {
                IdClasseParceiro = id
            });

            return result;
        }

        public Task<int> CreateAsync(ClasseParceiro entity)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(ClasseParceiro entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
update Tc_Sge_Classe_Parceiro set
  Classe = @Descricao,
  Porcentagem_Elsys = @PorcentagemElsys
where Id = @IdClasseParceiro
";

            var result = await connection.ExecuteAsync(sql, new
            {
                IdClasseParceiro = entity.IdClasseParceiro,
                Descricao = entity.Descricao,
                PorcentagemElsys = entity.PorcentagemElsys
            });

            return result;
        }
    }
}
