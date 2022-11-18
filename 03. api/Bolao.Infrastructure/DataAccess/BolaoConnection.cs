using Bolao.Domain.Configs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolao.Infrastructure.DataAccess
{
    public static class BolaoConnection
    {
        public static SqlConnection GetConnection(DatabaseSettings databaseSettings)
        {
            //return new SqlConnection($"Data source={Environment.GetEnvironmentVariable("DB_DATA_SOURCE")};" +
            //    $"Initial Catalog={Environment.GetEnvironmentVariable("DB_INITIAL_CATALOG")};" +
            //    $"User Id={Environment.GetEnvironmentVariable("DB_USER_ID")};" +
            //    $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
            //    $"Connect Timeout=30;Trusted_Connection=False;");

            var dataSource = databaseSettings.DB_DATA_SOURCE;
            var initialCatalog = databaseSettings.DB_INITIAL_CATALOG;
            var userId = databaseSettings.DB_USER_ID;
            var password = databaseSettings.DB_PASSWORD;

            return new SqlConnection($"Data source={dataSource};" +
                $"Initial Catalog={initialCatalog};" +
                $"User Id={userId};" +
                $"Password={password};" +
                $"Connect Timeout=30;Trusted_Connection=False;");
        }
    }
}
