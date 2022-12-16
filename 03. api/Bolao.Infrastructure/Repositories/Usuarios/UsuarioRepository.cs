using Bolao.Domain.Entities.Usuarios;
using Bolao.Domain.Interfaces.Configs;
using Bolao.Infrastructure.DataAccess;
using Bolao.Infrastructure.Interfaces.Repositories.Usuarios;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories.Usuarios
{
    public class UsuarioRepository : RepositoryBase, IUsuarioRepository
    {
        public UsuarioRepository(IApiSettingsAccessor apiSettingsAccessor) : base(apiSettingsAccessor)
        {

        }

        public Task<IEnumerable<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetByNomeAsync(string nome)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  u.IdUsuario,
  u.Nome,
  u.Email,
  u.Senha,
  u.UrlImagem,
  u.DtCadastro
from Usuario u
where u.Nome = @Nome
order by u.IdUsuario
";

            var result = await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new
            {
                Nome = nome
            });

            return result;
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  u.IdUsuario,
  u.Nome,
  u.Email,
  u.Senha,
  u.UrlImagem,
  u.DtCadastro
from Usuario u
where u.Email = @Email
order by u.IdUsuario
";

            var result = await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new
            {
                Email = email
            });

            return result;
        }

        public async Task<Usuario> GetByNomeEmailAsync(string nome, string email)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
select
  u.IdUsuario,
  u.Nome,
  u.Email,
  u.Senha,
  u.UrlImagem,
  u.DtCadastro
from Usuario u
where u.Nome = @Nome
  and u.Email = @Email
order by u.IdUsuario
";

            var result = await connection.QueryFirstOrDefaultAsync<Usuario>(sql, new
            {
                Nome = nome,
                Email = email
            });

            return result;
        }

        public async Task<int> CreateAsync(Usuario entity)
        {
            using var connection = BolaoConnection.GetConnection(_apiSettingsAccessor.GetSettings().Database);

            var sql = @"
insert into Usuario
(
  Nome,
  Email,
  Senha,
  UrlImagem,
  DtCadastro
)
values
(
  @Nome,
  @Email,
  @Senha,
  @UrlImagem,
  @DtCadastro
)
";

            var result = await connection.ExecuteAsync(sql, new
            {
                Nome = entity.Nome,
                Email = entity.Email,
                Senha = entity.Senha,
                UrlImagem = entity.UrlImagem,
                DtCadastro = DateTime.Now  // entity.DtCadastro
            });

            return result;
        }

        public Task<int> UpdateAsync(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
