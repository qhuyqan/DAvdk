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
        string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
        OleDbConnection sqlCon = null;
        // Open
        public void OpenConnection()
        {
            if (sqlCon == null)
            {
                sqlCon = new OleDbConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }
        // Close
        public void CloseConnection()
        {
            if (sqlCon.State == ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }
        public Form2()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();
                OleDbCommand sqlCmd = new OleDbCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT * FROM DanhSachNhanVien WHERE Tk='" + txtTaiKhoan.Text + "' and Mk='" + txtMatKhau.Text + "'";
                sqlCmd.Connection = sqlCon;
                OleDbDataReader reader = sqlCmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    MessageBox.Show("LOGIN SUCCESSFUL!");
                    txtTaiKhoan.Text = "";
                    txtMatKhau.Text = "";
                    txtTaiKhoan.Focus();
                    Form1 f1 = new Form1();
                    f1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("WRONG USERNAME OR PASSWORD!");
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
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
        }

        private void txtMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
        private void txtTaiKhoan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Tab)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtTaiKhoan_Enter(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "Username")
            {
                txtTaiKhoan.Text = "";
                txtTaiKhoan.ForeColor = Color.Black;
            }
        }

        private void txtTaiKhoan_Leave(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text == "")
            {
                txtTaiKhoan.Text = "Username";
                txtTaiKhoan.ForeColor = Color.Gray;
            }
        }

        private void txtMatKhau_Enter(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "Password")
            {
                txtMatKhau.Text = "";
                txtMatKhau.ForeColor = Color.Black;
            }
        }

        private void txtMatKhau_Leave(object sender, EventArgs e)
        {
            if (txtMatKhau.Text == "")
            {
                txtMatKhau.Text = "Password";
                txtMatKhau.ForeColor = Color.Gray;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }       
    }
}
