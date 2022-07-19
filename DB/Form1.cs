using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace DB
{
    public partial class Form1 : Form
    {

        //connection string

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP_ALEX;Initial Catalog=sqldb;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();

           // disp_data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO table_db VALUES('" + textBoxName.Text + "'," +
                "'" + textBoxCity.Text + "','" + textBoxCountry.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            MessageBox.Show("Record Inserted Successfully");
        }




        public void disp_data()

        {   //open database
            con.Open();

            //this will add the line 57 be read as Query at ServeDB
            SqlCommand cmd = con.CreateCommand();

            //says what will be the type of the commands (suggestion always use text, for a happy life)
            cmd.CommandType = CommandType.Text;

            //The SQL query itself
            cmd.CommandText = "SELECT * FROM table_db";

            //this is the trigger to run the query;
            cmd.ExecuteNonQuery();

            

            //I need to add the atributes from the server db to my PC memory
            DataTable dt = new DataTable();

            //format the data atribute to an way that C# understards
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            //all the magic happens HERE. The funcion fill will put all info from 
            //memory that was from DB Server to C# be able to display at front end
            da.Fill(dt);

            //data component that loads the data itself already transformed
            dataGridViewDB.DataSource = dt;

            //close db to not crash
            con.Close();
            //IF I use FILES like XML. I use objects
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM table_test WHERE name='" + textBoxName.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridViewDB.DataSource = dt;

            con.Close();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM table_db WHERE name='" + textBoxName.Text + "'";

            cmd.ExecuteNonQuery();

            con.Close();
            disp_data();
            MessageBox.Show("Record Deleted Successfully");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE table_db SET name='"+textBoxCity.Text+"' WHERE name='"+textBoxName.Text+"' ";

            cmd.ExecuteNonQuery();

            con.Close();
            disp_data();
            MessageBox.Show("Record Updated Successfully");

        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            disp_data();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {

        }
    }
}
