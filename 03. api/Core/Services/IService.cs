using Core.Commands;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<TEntity, TKeyDataType> where TEntity : Entity where TKeyDataType : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKeyDataType id);
        Task<ICommandResult> CreateAsync(ICommand command);
        Task<ICommandResult> UpdateAsync(ICommand command);
    }
}
