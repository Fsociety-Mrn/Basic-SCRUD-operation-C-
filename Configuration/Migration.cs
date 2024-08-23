using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    // Child class from Database , use for Migration of Database
    internal class Migration : Database
    {

        public string table_name = "posted";



        // create table
        public void create_table()
        {
            try
            {
                connection.Open();

                string query = $"CREATE TABLE IF NOT EXISTS `{table_name}` (" +
                    $"`uid` INT  AUTO_INCREMENT , " +
                    $"`name` VARCHAR(1000) NOT NULL , " +
                    $"`status` VARCHAR(1000) NOT NULL , " +
                    $"`date` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP, " +
                    $"PRIMARY KEY (`uid`));";

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

        // delete table
        public void drop_table()
        {
            try
            {
                connection.Open();

                // ID INT PRIMARY KEY AUTO_INCREMENT, Name VARCHAR(100), Age INT
                string query = $"DROP TABLE IF EXISTS`{table_name}`";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Database 'test' created successfully.");
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
