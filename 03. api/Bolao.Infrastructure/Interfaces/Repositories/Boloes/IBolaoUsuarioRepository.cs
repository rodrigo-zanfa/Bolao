using Bolao.Domain.Entities.Boloes;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Boloes
{
    public interface IBolaoUsuarioRepository : IRepository<BolaoUsuario, int>
    {
        Task<BolaoUsuario> GetByUniqueKeyAsync(int idBolao, int idUsuario);
    }
}
