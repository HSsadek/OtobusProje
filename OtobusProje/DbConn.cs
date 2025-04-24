using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OtobusProje
{
    internal class DbConn
    {

        static string connt = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
       public SqlConnection conn = new SqlConnection(connt);
      



        public SqlConnection connect()
        {
            conn.Open();
            return conn;
        }

        public void Disconnect()
        {
            if (conn.State == ConnectionState.Open == true)
                conn.Close();
        }







    }
}
