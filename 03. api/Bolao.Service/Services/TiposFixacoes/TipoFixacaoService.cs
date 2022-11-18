using Core.Commands;
using Bolao.Domain.Entities.TiposFixacoes;
using Bolao.Infrastructure.Interfaces.Repositories.TiposFixacoes;
using Bolao.Service.Interfaces.Services.TiposFixacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.TiposFixacoes
{
    public class TipoFixacaoService : ITipoFixacaoService
    {
        private readonly ITipoFixacaoRepository _tipoFixacaoRepository;

        public TipoFixacaoService(ITipoFixacaoRepository tipoFixacaoRepository)
        {
            _tipoFixacaoRepository = tipoFixacaoRepository;
        }

        public async Task<IEnumerable<TipoFixacao>> GetAllAsync()
        {
            var result = await _tipoFixacaoRepository.GetAllAsync();

            return result;
        }

        public async Task<IEnumerable<TipoFixacao>> GetAllByMarcaEstruturaAsync(int idMarcaEstrutura)
        {
            var result = await _tipoFixacaoRepository.GetAllByMarcaEstruturaAsync(idMarcaEstrutura);

            return result;
        }

        public Task<TipoFixacao> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> CreateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ICommandResult> UpdateAsync(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
