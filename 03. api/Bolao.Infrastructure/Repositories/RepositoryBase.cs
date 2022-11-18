using Bolao.Domain.Interfaces.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly IApiSettingsAccessor _apiSettingsAccessor;

        protected RepositoryBase(IApiSettingsAccessor apiSettingsAccessor)
        {
            _apiSettingsAccessor = apiSettingsAccessor;
        }
    }
}
