using Bolao.Domain.Entities.Usuarios;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Usuarios
{
    public interface IUsuarioRepository : IRepository<Usuario, int>
    {
        Task<Usuario> GetByEmailAsync(string email);
    }
}
