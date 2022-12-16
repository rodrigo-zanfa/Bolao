using Bolao.Domain.Entities.Boloes;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Boloes
{
    public interface IBolaoUsuarioService : IService<BolaoUsuario, int>
    {
        Task<BolaoUsuario> GetByUniqueKeyAsync(int idBolao, int idUsuario);
    }
}
