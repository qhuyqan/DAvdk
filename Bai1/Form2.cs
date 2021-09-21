using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bai1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            OleDbConnection myConnection = new OleDbConnection();
            myConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0 ; Data Source=Database1.mdb ;";

            //SqlConnection connection = new SqlConnection(@"Provider=Microsoft.Jet.OLEDB.4.0 ; Data Source=Database1.mdb ;");
            try
            {
                myConnection.Open();
                string tk = txtTaiKhoan.Text;
                string mk = txtMatKhau.Text;
                string sql = "SELECT * FROM TKNhanVien WHERE Account='" + tk + "' and Password='" + mk + "'";
                OleDbCommand cmd = new OleDbCommand(sql, myConnection);
                OleDbDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    MessageBox.Show("LOGIN SUCCESSFUL!");
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                }
                else
                {
                    MessageBox.Show("LOGIN ERROR!");
                    txtMatKhau.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ptb1_Click(object sender, EventArgs e)
        {

        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }
    }
}
