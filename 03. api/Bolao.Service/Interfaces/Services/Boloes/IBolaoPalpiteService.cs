using Bolao.Domain.Commands.Boloes;
using Bolao.Domain.Entities.Boloes;
using Core.Commands;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Boloes
{
    public interface IBolaoPalpiteService : IService<BolaoPalpite, int>
    {
        Task<ICommandResult> SaveAsync(CreateBolaoPalpiteCommand command);
    }
}
