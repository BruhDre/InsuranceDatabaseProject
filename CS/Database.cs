using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavrsni
{
    internal class Database
    {
        string connectionString = "insert connection string here";

        public DataSet izvrsi(string sql_upit, string naziv)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql_upit, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, naziv);
            connection.Close();
            return ds;
        }

        public int izvrsi_proceduru(string sql_upit)
        {
            SqlConnection connection = new SqlConnection(@connectionString);
            SqlCommand command = new SqlCommand(sql_upit, connection);

            try
            {
                connection.Open();
                int i = command.ExecuteNonQuery();
                return i;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Generated. Details: " + e.ToString());
                return 0;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
