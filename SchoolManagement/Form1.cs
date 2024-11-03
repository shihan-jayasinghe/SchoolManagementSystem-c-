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

namespace SchoolManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();
            string username= textUsername.Text;
            string password= textPassword.Text;
            SqlCommand cmd = new SqlCommand("select username,password from logintab where username='"+ username + "'and password='"+ password+ "'",conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                Main main= new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
            conn.Close();
        }
    }
}
