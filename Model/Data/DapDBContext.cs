using Microsoft.Data.SqlClient;
using System.Data;

namespace crudd.Model.Data
{
    public class DapDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;

        public DapDBContext(IConfiguration configuration) {
            this._configuration = configuration;
            this.connectionstring = this._configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection()=>new SqlConnection(connectionstring);
    }
}
