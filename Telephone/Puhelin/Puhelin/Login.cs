using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puhelin
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Equals("admin") && textBox2.Text.Equals("admin"))
            {
                this.Hide();
                Puhelin puhelin  = new Puhelin();
                puhelin.Show();
                
            }
            if (textBox1.Text.Equals("doctor") && textBox2.Text.Equals("doctor"))
            {
                this.Hide();
                Doctor doctor = new Doctor();
                doctor.Show();
            }
            if (textBox1.Text.Equals("nurse") && textBox2.Text.Equals("nurse"))
            {
                this.Hide();
                Search search = new Search();
                search.Show();
            }
            if (textBox1.Text.Equals("service") && textBox2.Text.Equals("service"))
            {
                this.Hide();
                Search search = new Search();
                search.Show();
            }
            
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
