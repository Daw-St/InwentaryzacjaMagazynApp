using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inwentaryazjaMagazynu
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // TO-DO check login username and password admin + admin@123
            SqlConnection con = new SqlConnection("Data Source=DAWID-KOMPUTER\\DAWSQLSERVER;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * FROM[Stock].[dbo].[Login] Where UserName = '"+ textBox1.Text +"' and Password = '"+ textBox2.Text +"'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                stockMain main = new stockMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Niewłaściwa nazwa użytkownika i/lub hasło", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                button1_Click(sender, e);
            }
        }
    }
}
