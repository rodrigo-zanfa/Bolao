using Bolao.Domain.Entities.Campeonatos;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoTimeRepository : IRepository<CampeonatoTime, int>
    {
        Task<CampeonatoTime> GetByUniqueKeyAsync(int idCampeonato, int idTime);
    }
}
