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

namespace Bai1
{
    public partial class Form3 : Form
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
        public Form3()
        {
            InitializeComponent();
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (txtHoten.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR NAME!");
                txtHoten.Focus(); //Đưa trỏ chuột về lại
            }
            else if (txtSdt.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR PHONE NUMBER!");
                txtSdt.Focus();
            }
            else if (txtTK.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR ACCOUNT!");
                txtTK.Focus();
            }
            else if (txtMK.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR PASSWORD!");
                txtMK.Focus();
            }
            else if (txtXacNhan.Text == "")
            {
                MessageBox.Show("PLEASE ENTER YOUR CONFIRM PASSWORD!");
                txtXacNhan.Focus();
            }
            else if (txtMK.Text != txtXacNhan.Text)
            {
                MessageBox.Show("INCORRECT PASSWORD!");
                txtXacNhan.Focus();
                txtXacNhan.SelectAll();
            }

            // ĐỊNH DẠNG 
            else
            {
                NhanVien nv = new NhanVien(txtHoten.Text, txtSdt.Text, txtTK.Text, txtMK.Text);
                if (nv.KiemTra() == true)
                {
                    OpenConnection();

                    OleDbCommand sqlCmd = new OleDbCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "INSERT INTO QuanLyNhanVien(Hoten,SoDienThoai,Tk,Mk) VALUES (@ten,@sdt,@tk,@mk)";

                    OleDbParameter ten = new OleDbParameter("@ten", OleDbType.BSTR);
                    ten.Value = txtHoten.Text.Trim();
                    sqlCmd.Parameters.Add(ten);

                    OleDbParameter sdt = new OleDbParameter("@sdt", OleDbType.Integer);
                    sdt.Value = int.Parse(txtSdt.Text.Trim());
                    sqlCmd.Parameters.Add(sdt);

                    OleDbParameter tk = new OleDbParameter("@tk", OleDbType.BSTR);
                    tk.Value = txtTK.Text.Trim();
                    sqlCmd.Parameters.Add(tk);

                    OleDbParameter mk = new OleDbParameter("@mk", OleDbType.BSTR);
                    mk.Value = txtMK.Text.Trim();
                    sqlCmd.Parameters.Add(mk);

                    sqlCmd.Connection = sqlCon;
                    int result = sqlCmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Successfull");
                        this.CloseConnection();
                    }
                    else
                    {
                        MessageBox.Show("Fail");
                    }                    
                }
                else
                {
                    MessageBox.Show("Password must be at least 6 characters; include letters and numbers");
                }
            }
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
