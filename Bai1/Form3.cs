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
                    OleDbConnection myConnection = new OleDbConnection();
                    myConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\qhuyd\Desktop\csharpp\Bai1\Bai1\bin\Debug\Database1.mdb";
                    
                    string ten = txtHoten.Text;
                    string sodienthoai = txtSdt.Text;
                    string taikhoan = txtTK.Text;
                    string matkhau = txtMK.Text;
                    string sql = "insert into QuanLyNhanVien (Hoten,SoDienThoai,Account,Password) Values(@ten, @sodienthoai, @taikhoan, @matkhau)";

                    OleDbCommand cmd = new OleDbCommand(sql);
                    cmd.Connection = myConnection;
                    myConnection.Open();
                    cmd.Parameters.Add("@Hoten", OleDbType.VarChar).Value = ten;
                    cmd.Parameters.Add("@SoDienThoai", OleDbType.VarChar).Value = sodienthoai;
                    cmd.Parameters.Add("@Account", OleDbType.VarChar).Value = taikhoan;
                    cmd.Parameters.Add("@Password", OleDbType.VarChar).Value = matkhau;
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account successfully created!", "Information", MessageBoxButtons.OK);
                    myConnection.Close();

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
