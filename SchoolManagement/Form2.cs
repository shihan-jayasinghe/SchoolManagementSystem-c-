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
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyy";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Back)
            {
                dateTimePicker1.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("insert into studentab values(@studentid,@studentname,@dob,@gender,@phone,@email)",conn);
            cmd.Parameters.AddWithValue("@studentId",int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@studentName", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender",textBox3.Text);
            cmd.Parameters.AddWithValue("@phone",textBox4.Text);
            cmd.Parameters.AddWithValue("@email",textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("record save successfully","save",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from studentab", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource=dt;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("update studentab set studentname=@studentname,dob=@dob,gender=@gender,phone=@phone,email=@email where studentid=@studentid", conn);
            cmd.Parameters.AddWithValue("@studentId", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@studentName", textBox2.Text);
            cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@gender", textBox3.Text);
            cmd.Parameters.AddWithValue("@phone", textBox4.Text);
            cmd.Parameters.AddWithValue("@email", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("record updated successfully", "update", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("delete from studentab where studentid=@studentid",conn);
            cmd.Parameters.AddWithValue("@studentid", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("record deleted successfully", "deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from studentab", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-N5QFL4U9;Initial Catalog=schooldb;Integrated Security=True;Encrypt=False");
            conn.Open();

            SqlCommand cmd = new SqlCommand("select * from studentab", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
