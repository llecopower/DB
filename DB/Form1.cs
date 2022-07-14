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

            disp_data();
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

        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "SELECT * FROM table_db";

            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridViewDB.DataSource = dt;

            con.Close();






        
        
        
        }




        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
