using Bolao.Domain.Entities.Campeonatos;
using Bolao.Service.Interfaces.Services.Campeonatos;
using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Services.Campeonatos
{
    public class TimeService : ITimeService
    {
        public Task<IEnumerable<Time>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Time> GetByIdAsync(int id)
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
