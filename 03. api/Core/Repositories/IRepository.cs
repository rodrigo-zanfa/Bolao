using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IRepository<TEntity, TKeyDataType> where TEntity : Entity where TKeyDataType : struct
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKeyDataType id);
        Task<int> CreateAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
    }
}
