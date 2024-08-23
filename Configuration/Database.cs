using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    internal class Database
    {


        private string server = "localhost";
        private string username = "root";
        private string password = "";
        private string database = "test";

        public MySqlDataAdapter adapter;
        public DataSet data;
        public MySqlConnection connection;

        // Constructor
        public Database()
        {
            Initialize();
        }

        // Initialize the database connection
        private void Initialize()
        {
            try
            {
                string connectionString = $"server={server};username={username};Password={password};database={database}";
                connection = new MySqlConnection(connectionString);
                connection.Open();
                connection.Close();

            }
            catch (Exception)
            {
                string connectionString = $"server={server};username={username};Password={password};";
                MySqlConnection connect = new MySqlConnection(connectionString);
                create_database(connect);
                Initialize();
            }
        }

        // Testing Connection
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                MessageBox.Show($"Connection is Open");
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Error: {ex.Message}");
                return false;
            }
        }



        // create Database
        private void create_database(MySqlConnection Connect)
        {
            try
            {
                Connect.Open();
                string query = $"CREATE DATABASE IF NOT EXISTS `{database}`;";
                using (MySqlCommand cmd = new MySqlCommand(query, Connect))
                {
                    cmd.ExecuteNonQuery();
                }
                Connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                Connect.Close();
            }
        }

        // delete databases
        public void drop_database()
        {
            try
            {
                connection.Open();
                string query = $"DROP DATABASE IF EXISTS `{database}`;";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                connection.Close();
            }
        }
    }
}
