using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace Infra.Dados.SqlStorage
{
    public class SqlServerConfigurations : ISqlServerConfigurations
    {
        private readonly SqlServerSettings _sqlServerSettings;
        public SqlServerConfigurations(IOptions<SqlServerSettings> sqlServerSettings)
        {
            _sqlServerSettings = sqlServerSettings.Value;
        }

        public IDbConnection DbConnection => new SqlConnection(_sqlServerSettings.ConnectionString);
    }
}
