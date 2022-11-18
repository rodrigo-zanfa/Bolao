using Core.Commands;
using Bolao.Domain.Commands.Produtos;
using Bolao.Domain.Entities.Produtos;
using Bolao.Infrastructure.Interfaces.Repositories.Produtos;
using Bolao.Service.Interfaces.Services.Produtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Produtos
{
    public class CaboService : ICaboService
    {
        private readonly ICaboRepository _caboRepository;
        private readonly IValidator<CreateCaboCommand> _createCaboCommandValidator;
        private readonly IValidator<UpdateCaboCommand> _updateCaboCommandValidator;

        public CaboService(ICaboRepository caboRepository, IValidator<CreateCaboCommand> createCaboCommandValidator, IValidator<UpdateCaboCommand> updateCaboCommandValidator)
        {
            _caboRepository = caboRepository;
            _createCaboCommandValidator = createCaboCommandValidator;
            _updateCaboCommandValidator = updateCaboCommandValidator;
        }

        public async Task<IEnumerable<Cabo>> GetAllAsync()
        {
            var result = await _caboRepository.GetAllAsync();

            return result;
        }

        public async Task<Cabo> GetByIdAsync(int id)
        {
            var result = await _caboRepository.GetByIdAsync(id);

            return result;
        }

        public async Task<Cabo> GetByCodigoAsync(string codigo)
        {
            var result = await _caboRepository.GetByCodigoAsync(codigo);

            return result;
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
