using Bolao.Domain.Commands.Campeonatos;
using Bolao.Domain.Entities.Campeonatos;
using Core.Commands;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoPartidaService : IService<CampeonatoPartida, int>
    {
        Task<ICommandResult> UpdatePlacarAsync(UpdatePlacarCampeonatoPartidaCommand command);
    }
}
