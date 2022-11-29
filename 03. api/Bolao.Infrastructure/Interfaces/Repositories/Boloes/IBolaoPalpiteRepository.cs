using Bolao.Domain.Entities.Boloes;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.Boloes
{
    public interface IBolaoPalpiteRepository : IRepository<BolaoPalpite, int>
    {
        Task<IEnumerable<BolaoPalpite>> GetAllByCampeonatoPartidaAsync(int idCampeonatoPartida);
        Task<BolaoPalpite> GetByUniqueKeyAsync(int idBolaoUsuario, int idCampeonatoPartida);
        Task<int> UpdatePontuacaoAsync(BolaoPalpite entity);
    }
}
