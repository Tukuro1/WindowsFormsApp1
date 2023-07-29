using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    internal class Modify
    {
        public Modify()
        { 
        }
        SqlCommand SqlCommand;//truy van cau lenh
        SqlDataReader SqlDataReader;// doc du lieu trong bang
        public List<TaiKhoan> TaiKhoans(string query)
        {
            List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
            using (SqlConnection sqlConnection = Connecsion.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand = new SqlCommand(query, sqlConnection);
                SqlDataReader = SqlCommand.ExecuteReader();
                while(SqlDataReader.Read())
                {
                    taiKhoans.Add(new TaiKhoan(SqlDataReader.GetString(0), SqlDataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return taiKhoans;
        }
    }
}
