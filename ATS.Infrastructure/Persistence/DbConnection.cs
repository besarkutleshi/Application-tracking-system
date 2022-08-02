using Microsoft.Data.SqlClient;
using System.Data;

namespace ATS.Infrastructure.Persistence
{
    public class DbConnection
    {
        public IDbConnection CreateConnection() => new SqlConnection("");
    }
}
