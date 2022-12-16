using Bolao.Domain.Entities.Campeonatos;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoPartidaRepository : IRepository<CampeonatoPartida, int>
    {
        Task<CampeonatoPartida> GetByUniqueKeyAsync(DateTime dtPartida, int idCampeonatoTime1, int idCampeonatoTime2);
        Task<CampeonatoPartida> GetByUniqueKeyAsync(int idCampeonatoTime1, int idCampeonatoTime2);
    }
}
