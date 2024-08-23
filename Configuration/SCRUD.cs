using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace WindowsFormsApp1.Configuration
{
    internal class SCRUD : Migration
    {
        public string column_name = "name";
        public string column_status = "status";
        public string column_date = "date";


        // Search data from database and populate DataGridView
        public DataSet Search(string name, string order = "DESC")
        {
            try
            {
                connection.Open();

                // setup view all query
                string query = $"SELECT * FROM `{table_name}` " +
                               $"WHERE `{column_name}` LIKE '{name}%'" +
                               $"ORDER BY {column_date} {order}";

                // Create a DataSet to store the data
                DataSet dataSet = new DataSet();

                // Create a MySqlDataAdapter to execute the query and fill the DataSet
                using (adapter = new MySqlDataAdapter(query, connection))
                {
                    // Fill the DataSet
                    adapter.Fill(dataSet, "YourData");

                    // Close the connection
                    connection.Close();

                    return dataSet;
                }

            }
            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine($"Error: {ex.Message}");
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
                string query = $"INSERT INTO `{table_name}` (`{column_name}`, `{column_status}`) VALUES (@value1,@value2)";

                // Create a MySqlCommand object and pass the query and connection
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@value1", name);
                    cmd.Parameters.AddWithValue("@value2", status);

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    connection.Close();

                    return ("data is created");
                }

            }
            catch (Exception ex)
            {
                connection.Close();
                return ($"Error: {ex.Message}");
            }
        }

        // Read data from the database and populate DataGridView
        public DataSet Read(string order = "DESC")
        {
            try
            {
                connection.Open();

                // setup view all query
                string query = $"SELECT * FROM `{table_name}` " +
                    $"ORDER BY {column_date} {order}";

                // Create a DataSet to store the data
                DataSet dataSet = new DataSet();

                // Create a MySqlDataAdapter to execute the query and fill the DataSet
                using (adapter = new MySqlDataAdapter(query, connection))
                {
                    // Fill the DataSet
                    adapter.Fill(dataSet, "YourData");

                    // Close the connection
                    connection.Close();

                    return dataSet;
                }

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
                string query = $"UPDATE `{table_name}` " +
                               $"SET `{column_name}` = @value1, `{column_status}` = @value2 " +
                               $"WHERE `uid` = @uid";

                // Create a MySqlCommand object and pass the query and connection
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@value1", name);
                    cmd.Parameters.AddWithValue("@value2", status);
                    cmd.Parameters.AddWithValue("@uid", uid);

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    connection.Close();

                    return ("data is updated");
                }

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
                string query = $"DELETE FROM `{table_name}` " +
                               $"WHERE `uid` = @uid";

                // Create a MySqlCommand object and pass the query and connection
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@uid", uid);

                    // Execute the query
                    cmd.ExecuteNonQuery();

                    connection.Close();

                    return ("data is DELETED");
                }

            }
            catch (Exception ex)
            {
                connection.Close();
                return ($"Error: {ex.Message}");
            }
        }
    }
}
