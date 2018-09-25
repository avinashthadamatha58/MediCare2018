using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class TestClass
    {
        public bool testGetSql()
        {
            int name = 1;
            SqlConnection connection =
                new SqlConnection(
                    "Data Source = ATHADAMATHA-LT\\SQLEXPRESS; Initial Catalog = MediCare; Integrated Security = SSPI;");
            SqlCommand command = new SqlCommand("SELECT * FROM dbo.Prescriptions where prescriptionId='" + name + "'");
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            //if (reader.Read())
            //{
            //    if (Convert.ToInt32(reader["quantity"]) == 30)
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
           var varri= dt.Rows;

            return false;
        }
    }
}