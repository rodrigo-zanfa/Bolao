using Bolao.Domain.Entities.Regras;
using Bolao.Service.Interfaces.Services.Regras;
using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Regras
{
    public class RegraService : IRegraService
    {
        public Task<IEnumerable<Regra>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Regra> GetByIdAsync(int id)
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
