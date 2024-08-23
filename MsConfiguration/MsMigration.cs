using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.MsConfiguration
{
    internal class MsMigration : MsDatabase
    {
        public string table_name = "posted";

        // create table
        public void create_table()
        {
            try
            {

                string query = $"IF NOT EXISTS (SELECT name FROM sys.tables WHERE name = '{table_name}') " +
                                 $"BEGIN" +
                                    $" CREATE TABLE Posted( " +
                                        $"uid INT PRIMARY KEY IDENTITY(1,1)," +
                                        $"name VARCHAR(3000) NOT NULL," +
                                        $"status VARCHAR(3000) NOT NULL," +
                                        $"date DATETIME2 NULL DEFAULT SYSDATETIME()" +
                                    $")" +
                                  $"END";


                command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

         
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Migration Error: {ex.Message}");
                connection.Close();
            }
        }

      
    }
}
