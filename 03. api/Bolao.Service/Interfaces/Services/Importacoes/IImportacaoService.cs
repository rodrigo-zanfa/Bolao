using Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Service.Interfaces.Services.Importacoes
{
    public interface IImportacaoService
    {
        Task<ICommandResult> ImportarCopa2022Async();
        Task<ICommandResult> ImportarPalpitesCopa2022Async();
    }
}
