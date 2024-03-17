using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DapperCrud.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;
        public DapperDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection => new SqlConnection(_connectionstring);
    }
}
