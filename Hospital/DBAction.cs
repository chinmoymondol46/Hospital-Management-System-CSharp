using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Hospital
{
    static class DBAction
    {
        static SqlConnection con;
        static public SqlConnection ConnectDB()
        {
            con = new SqlConnection(@"Data Source=INFINITE\SQLEXPRESS;Initial Catalog=Hospital;Integrated Security=True");
            con.Open();
            return con;
        }

        static public DataSet SelectDB(string query)
        {
            con = ConnectDB();
            SqlDataAdapter adp = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }

        static public int nonDB(string query)
        {
            int ret;
            con = ConnectDB();
            SqlCommand com = new SqlCommand(query, con);
            ret = com.ExecuteNonQuery();
            return ret;
        }
    }
}
