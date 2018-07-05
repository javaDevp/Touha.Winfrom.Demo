using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCHelper
{
    public class DbHelper
    {
        public static DataTable QueryTable(string sql, string connectString)
        {
            using(SqlConnection conn = new SqlConnection(connectString))
            {
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        return dt;
                    }
                }
                
            }
        }

        public static int ExecuteSql(string sql, string connectString)
        {
            using(SqlConnection conn = new SqlConnection(connectString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
