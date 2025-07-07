using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;


namespace Dapperproduct.Model
{
    public class DbHelper
    {
        public IDbConnection GetDbConnection()
        {
            string connectionString = "Data Source=Anugraheeths_PC\\SQLEXPRESS;Initial Catalog=Dapper;Integrated Security=True;Encrypt=False";
            return new SqlConnection(connectionString);
        }
    }
}
