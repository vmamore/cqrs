using System.Data;

namespace Infra.Dados.SqlStorage
{
    public interface ISqlServerConfigurations
    {
        IDbConnection DbConnection { get; }
    }
}
