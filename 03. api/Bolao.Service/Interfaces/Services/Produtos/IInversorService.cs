using Core.Services;
using Bolao.Domain.Entities.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Produtos
{
    public interface IInversorService : IService<Inversor, int>
    {
        Task<Inversor> GetByCodigoAsync(string codigo);
    }
}
