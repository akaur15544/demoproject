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

namespace Puhelin
{
    public partial class Doctor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=D16007\\sqlexpress;Initial Catalog=phone;Integrated Security=True");
       
        public Doctor()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox5.Clear();
            textBox2.Text = "";
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"Insert into Mobiles(First,Last,Mobile,Email,Catagory)Values('" + textBox1.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Sucessfully inserted!");
            Display();
        }
        void Display()
        {
            SqlDataAdapter sda = new SqlDataAdapter("select*from Mobiles", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(@"UPDATE Mobiles
            SET First= '" + textBox1.Text + "', Last= '" + textBox5.Text + "', Mobile='" + textBox2.Text + "' , Email= '" + textBox3.Text + "', Catagory='" + comboBox1.Text + "' Where  (Mobile='" + textBox2.Text + "')", con);
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Sucessfully Updated!");
            Display();
        }
        //search button
        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select*from Mobiles Where Mobile like'" + textBox4.Text + "%' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            Display();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Doctor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
