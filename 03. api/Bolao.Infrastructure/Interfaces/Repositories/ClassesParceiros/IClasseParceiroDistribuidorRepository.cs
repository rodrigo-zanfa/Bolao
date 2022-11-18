using Core.Repositories;
using Bolao.Domain.Entities.ClassesParceiros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Interfaces.Repositories.ClassesParceiros
{
    public interface IClasseParceiroDistribuidorRepository : IRepository<ClasseParceiroDistribuidor, int>
    {
        Task<ClasseParceiroDistribuidor> GetByLojaAsync(int idLoja);
    }
}
