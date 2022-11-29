using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Pontuacoes
{
    public interface IPontuacaoService
    {
        Task<ICommandResult> GerarPontuacaoPorPartidaAsync(int idCampeonatoPartida);
    }
}
