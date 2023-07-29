using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    class Connecsion
    {
        private static string stringConnecsion = @"Data Source=DESKTOP-60GOQLD\SQLEXPRESS;Initial Catalog=SalesManagementData;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnecsion);
        }
    }
}
