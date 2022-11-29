using Bolao.Domain.Entities.Regras;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Regras
{
    public interface IRegraRepository : IRepository<Regra, int>
    {
        Task<IEnumerable<Regra>> GetAllByBolaoAsync(int idBolao);
    }
}
