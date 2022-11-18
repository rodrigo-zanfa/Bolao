using Core.Commands;
using Core.Services;
using Bolao.Domain.Entities.ClassesParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.ClassesParceiros
{
    public interface IClasseParceiroDistribuidorService : IService<ClasseParceiroDistribuidor, int>
    {
        Task<ICommandResult> UpdateClasseAsync(int idClasseParceiroDistribuidor, int idClasseParceiro);
    }
}
