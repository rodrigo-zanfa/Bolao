using Bolao.Domain.Entities.Boloes;
using Bolao.Domain.Entities.Campeonatos;
using Bolao.Domain.Entities.Regras;
using Bolao.Infrastructure.Interfaces.Repositories.Boloes;
using Bolao.Infrastructure.Interfaces.Repositories.Campeonatos;
using Bolao.Infrastructure.Interfaces.Repositories.Regras;
using Bolao.Service.Interfaces.Services.Pontuacoes;
using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Pontuacoes
{
    public class PontuacaoService : IPontuacaoService
    {
        private readonly ICampeonatoPartidaRepository _campeonatoPartidaRepository;
        private readonly IBolaoPalpiteRepository _bolaoPalpiteRepository;
        private readonly IRegraRepository _regraRepository;

        public PontuacaoService(ICampeonatoPartidaRepository campeonatoPartidaRepository, IBolaoPalpiteRepository bolaoPalpiteRepository, IRegraRepository regraRepository)
        {
            _campeonatoPartidaRepository = campeonatoPartidaRepository;
            _bolaoPalpiteRepository = bolaoPalpiteRepository;
            _regraRepository = regraRepository;
        }

        public async Task<ICommandResult> GerarPontuacaoPorPartidaAsync(int idCampeonatoPartida)
        {
            // retornar o placar real da partida
            var partida = await _campeonatoPartidaRepository.GetByIdAsync(idCampeonatoPartida);

            // retornar todos os palpites que possuam a partida
            var palpites = await _bolaoPalpiteRepository.GetAllByCampeonatoPartidaAsync(idCampeonatoPartida);

            // retornar todas as regras de uma bolão
            var regras = await _regraRepository.GetAllByBolaoAsync(1);  // TODO: alterar para o bolão do usuário

            foreach (var palpite in palpites)
            {
                if (
                    palpite.PlacarTime1 == partida.PlacarTime1 &&  // placar exato
                    palpite.PlacarTime2 == partida.PlacarTime2  // placar exato
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Placar exato"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    (partida.PlacarTime1 > partida.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 > palpite.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 == partida.PlacarTime1)  // número de gols do vencedor
                    ||
                    (partida.PlacarTime2 > partida.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 > palpite.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 == partida.PlacarTime2)  // número de gols do vencedor
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Vencedor e número de gols do vencedor"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    (partida.PlacarTime1 > partida.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 > palpite.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 - palpite.PlacarTime2 == partida.PlacarTime1 - partida.PlacarTime2)  // diferença de gols
                    ||
                    (partida.PlacarTime2 > partida.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 > palpite.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 - palpite.PlacarTime1 == partida.PlacarTime2 - partida.PlacarTime1)  // diferença de gols
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Vencedor e diferença de gols"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    partida.PlacarTime1 == partida.PlacarTime2 &&  // empate
                    palpite.PlacarTime1 == palpite.PlacarTime2  // empate
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Empate"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    (partida.PlacarTime1 > partida.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 > palpite.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime2 == partida.PlacarTime2)  // número de gols do perdedor
                    ||
                    (partida.PlacarTime2 > partida.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 > palpite.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime1 == partida.PlacarTime1)  // número de gols do perdedor
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Vencedor e número de gols do perdedor"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    (partida.PlacarTime1 > partida.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 > palpite.PlacarTime2 &&  // Time 1 venceu
                    palpite.PlacarTime1 > palpite.PlacarTime2)  // Time 1 venceu
                    ||
                    (partida.PlacarTime2 > partida.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 > palpite.PlacarTime1 &&  // Time 2 venceu
                    palpite.PlacarTime2 > palpite.PlacarTime1)  // Time 2 venceu
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Apenas o vencedor"));

                    await SaveAsync(palpite, regra, partida);
                }
                else if (
                    palpite.PlacarTime1 == palpite.PlacarTime2  // empate
                    )
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Empate garantido"));

                    await SaveAsync(palpite, regra, partida);
                }
                else
                {
                    var regra = regras.FirstOrDefault(x => x.Descricao.Contains("Sem pontuação"));

                    await SaveAsync(palpite, regra, partida);
                }
            }

            // retornar o resultado
            return new CommandResult(true, "Geração da Pontuação da Partida concluída com sucesso.", /*result*/ null);
        }

        public async Task/*<ICommandResult>*/ SaveAsync(BolaoPalpite palpite, Regra regra, CampeonatoPartida partida)
        {
            // alterar os atributos necessários
            palpite.IdRegra = regra.IdRegra;
            palpite.Pontuacao = regra.Pontuacao * partida.Peso;

            // salvar
            var result = await _bolaoPalpiteRepository.UpdatePontuacaoAsync(palpite);
        }
    }
}
