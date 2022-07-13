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
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "INSERT INTO table_db VALUES('" + textBoxName.Text + "','" + textBoxCity.Text + "','" + textBoxCountry.Text + "')";

            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Record Inserted Successfully");

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
