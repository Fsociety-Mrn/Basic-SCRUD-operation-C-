

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.MsConfiguration
{
    internal class MsSCRUD : MsMigration
    {
        private string column_name = "name";
        private string column_status = "status";
        private string column_date = "date";




        // Search data from database and populate DataGridView
        public DataSet Search(string name, string order = "DESC")
        {
            try
            {
                connection.Open();

                // setup view all query
                string query = $"SELECT * FROM [{table_name}] " +
                               $"WHERE [{column_name}] LIKE @name " +
                               $"ORDER BY {column_date} {order}";

                // Create a DataSet to store the data
                DataSet dataSet = new DataSet();

                // Create a MySqlDataAdapter to execute the query and fill the DataSet
                using (adapter = new SqlDataAdapter(query, connection))
                {
                    // Add parameter for the query
                    adapter.SelectCommand.Parameters.AddWithValue("@name", name + "%");

                    // Fill the DataSet
                    adapter.Fill(dataSet, "YourData");
                }

                // Close the connection
                connection.Close();

                return dataSet;
            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"MS search Error: {ex.Message}");
                return null;
            }
        }

        // Create data
        public String Create(string name, string status)
        {

            try
            {

                connection.Open();

                // Your INSERT query with parameters
                string query = $"INSERT INTO [{table_name}] ([{column_name}], [{column_status}]) VALUES (@value1, @value2)";

                // Create a MySqlCommand object and pass the query and connection
                using (command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@value1", name);
                    command.Parameters.AddWithValue("@value2", status);

                    // Execute the query
                    command.ExecuteNonQuery();
                }


                connection.Close();

                return ("data is created");

            }
            catch (Exception ex)
            {
                connection.Close();
                return ($"Error: {ex.Message}");

            }
        }

        // read
        public DataSet Read(string name = "", string order = "DESC")
        {
            try
            {
                connection.Open();

                // setup view all query
                string query = $"SELECT * FROM [{table_name}] " +
                    $"ORDER BY {column_date} {order}";

                // Create a DataSet to store the data
                DataSet dataSet = new DataSet();

                // Create a MySqlDataAdapter to execute the query and fill the DataSet
                using (adapter = new SqlDataAdapter(query, connection))
                {
                    // Fill the DataSet
                    adapter.Fill(dataSet, "YourData");
                }

                // Close the connection
                connection.Close();
                return dataSet;

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        // Update data from database and populate DataGridView
        public String Update(int uid, string name, string status)
        {
            try
            {
                connection.Open();

                // Your INSERT query with parameters
                string query = $"UPDATE [{table_name}] " +
                               $"SET [{column_name}] = @value1, [{column_status}] = @value2 " +
                               $"WHERE [uid] = @uid";

                // Create a MySqlCommand object and pass the query and connection
                using (command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@value1", name);
                    command.Parameters.AddWithValue("@value2", status);
                    command.Parameters.AddWithValue("@uid", uid);

                    // Execute the query
                    command.ExecuteNonQuery();
                }

                connection.Close();
                return ("data is updated");

            }
            catch (Exception ex)
            {
                connection.Close();
                return ($"Error: {ex.Message}");
            }
        }

        // Delete data from database and populate DataGridView
        public String Delete(int uid)
        {
            try
            {
                connection.Open();

                // Your INSERT query with parameters
                string query = $"DELETE FROM [{table_name}] " +
                               $"WHERE [uid] = @uid";

                // Create a MySqlCommand object and pass the query and connection
                using (command = new SqlCommand(query, connection))
                {
                    // Add parameters to the query
                    command.Parameters.AddWithValue("@uid", uid);

                    // Execute the query
                    command.ExecuteNonQuery();
                }

                connection.Close();

                return ("data is DELETED");
            }
            catch (Exception ex)
            {
                connection.Close();
                return ($"Error: {ex.Message}");
            }
        }
    }
}
