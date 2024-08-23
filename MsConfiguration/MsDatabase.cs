using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace WindowsFormsApp1.MsConfiguration
{
    class MsDatabase
    {   
        // database connection
        private string database_connection = "Data Source=localhost\\SQLEXPRESS;Integrated Security=True";

        // sql command
        public SqlConnection connection;
        public SqlCommand command;
        public SqlDataAdapter adapter;

        public MsDatabase()
        {
            Initialize();
        }

        // Initialize the database connection
        private void Initialize()
        {

            try
            {


                // querry for creating database
                string query = "IF NOT EXISTS (" +
                                    "SELECT name FROM sys.databases WHERE name = 'test') " +
                               "BEGIN " +
                                    "CREATE DATABASE test " +
                               "END";

                // establish connection
                connection = new SqlConnection(database_connection);
                connection.Open();

                command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message.ToString());
               connection.Close();
            }
    

        }
    }
}
