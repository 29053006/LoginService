using Microsoft.Data.SqlClient;
using System.Data;

namespace LoginService.Core.Conection
{
    public class DapperContext
    {
        private readonly string _connectionString;

        public DapperContext(IConfiguration _configuration) => _connectionString = _configuration.GetConnectionString("DefaultConnection");

        public IDbConnection CreateConection()
            => new SqlConnection(_connectionString);
    }
}
