using Core.Commands;
using Bolao.Domain.Entities.MarcasEstruturas;
using Bolao.Infrastructure.Interfaces.Repositories.MarcasEstruturas;
using Bolao.Service.Interfaces.Services.MarcasEstruturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.MarcasEstruturas
{
    public class MarcaEstruturaService : IMarcaEstruturaService
    {
        private readonly IMarcaEstruturaRepository _marcaEstruturaRepository;

        public MarcaEstruturaService(IMarcaEstruturaRepository marcaEstruturaRepository)
        {
            _marcaEstruturaRepository = marcaEstruturaRepository;
        }

        public async Task<IEnumerable<MarcaEstrutura>> GetAllAsync()
        {
            var result = await _marcaEstruturaRepository.GetAllAsync();

            return result;
        }

        public Task<MarcaEstrutura> GetByIdAsync(int id)
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
