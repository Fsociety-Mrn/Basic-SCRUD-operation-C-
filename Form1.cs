using System;
using System.Data;
using System.Windows.Forms;
using WindowsFormsApp1.Configuration;
using WindowsFormsApp1.MsConfiguration;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // NOTE: this line of code uses MySQL using XAMPP server
        // Database db = new Database();
        // Migration mb = new Migration();
        // SCRUD shrud = new SCRUD();

        // NOTE: this line of code uses MS SQL (T-SQL approach)
        // MsDatabase msdatabase = new MsDatabase();
        // MsMigration msmigration = new MsMigration();
        MsSCRUD shrud = new MsSCRUD();

        public Form1()
        {
            // new Migration().create_table();
            shrud.create_table();
            InitializeComponent();
            update_datagridview();
        }

        // update data table
        private void update_datagridview(string order = "DESC")
        {   

            // Get data from the database
            DataSet dataSet = shrud.Search(textBox2.Text, order);

            // Check if data retrieval was successful
            if (dataSet != null)
            {
                // Set the DataSet as the DataSource for your DataGridView
                dataGridView1.DataSource = dataSet.Tables["YourData"];
            }
        
            
        }


        // reset text
        public void reset()
        {
            textBox1.ResetText();
            richTextBox1.ResetText();
            button1.Enabled = true;
            button3.Enabled = false;
        }

        // check the text
        private Boolean filter_text()
        {
            if (textBox1.Text != "" && richTextBox1.Text != "")
            {
                return true;
            }
            return false;
        }

        // create data
        private void button1_Click(object sender, EventArgs e)
        {

            string message = filter_text() ? shrud.Create(textBox1.Text, richTextBox1.Text) : "please dont leave textbox empty";

            update_datagridview();
            MessageBox.Show(message);
            reset();
           
        }

        // update data
        private void button2_Click(object sender, EventArgs e)
        {

            string message = filter_text() ? shrud.Update(int.Parse(label1.Text), textBox1.Text, richTextBox1.Text) : "please dont leave textbox empty";

            update_datagridview();
            MessageBox.Show(message);
            reset();
      
        }

  

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            update_datagridview(comboBox1.Text);
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                // Get the specific row
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                label1.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                richTextBox1.Text = row.Cells[2].Value.ToString();

                button1.Enabled = false;
                button3.Enabled = true;

            }
        }

        // clear data
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ResetText();
            richTextBox1.ResetText();
            button1.Enabled = true;
            button3.Enabled = false;
        }

        // delete data
        private void button3_Click(object sender, EventArgs e)
        {


            
            DialogResult result = MessageBox.Show("Are you sure you want to delete this?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // The user clicked "No"
            string message = "data will not deleted";
            if (result == DialogResult.Yes)
            {


                message = shrud.Delete(int.Parse(label1.Text));

                update_datagridview();

            }

            reset();
            MessageBox.Show(message);
           
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            

            // Get data from the database
            DataSet dataSet = shrud.Search(textBox2.Text);
            dataGridView1.DataSource = dataSet.Tables["YourData"];

     
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox2.Text == "")
            {
                update_datagridview();
            }
        }

      
    }
}
