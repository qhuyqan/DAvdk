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
        string strCon = @"Data Source=QUANGHUY;Initial Catalog=QuanLyBanHang;Persist Security Info=True;User ID=sa";
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
                if (nv.KiemTraMatKhau() == true)
                {
                    if (nv.CheckLength_Sdt() == true)
                    {
                        OpenConnection();

                        OleDbCommand sqlCmd = new OleDbCommand();
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = "INSERT INTO DanhSachNhanVien(Hoten,SoDienThoai,Tk,Mk)" + 
                                             "VALUES ('" + txtHoten.Text + "','" + txtSdt.Text + "','" + txtTK.Text + "','" + txtMK.Text + "')";

                        sqlCmd.Connection = sqlCon;
                        int result = sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Create Successfully");
                            CloseConnection();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Fail");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số Điện Thoại chỉ bao gồm 10 số!");
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

        private void txtHoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)8 || e.KeyChar == (char)32)
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
