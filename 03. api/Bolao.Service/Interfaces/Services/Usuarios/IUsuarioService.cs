using Bolao.Domain.Entities.Usuarios;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Usuarios
{
    public interface IUsuarioService : IService<Usuario, int>
    {
        Task<Usuario> GetByNomeAsync(string nome);
        Task<Usuario> GetByEmailAsync(string email);
        Task<Usuario> GetByNomeEmailAsync(string nome, string email);
    }
}
