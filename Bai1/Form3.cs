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
                    string ten = txtHoten.Text;
                    string sdt = txtSdt.Text;
                    string tk = txtTK.Text;
                    string mk = txtMK.Text;
                    string sql = "INSERT INTO [QuanLyNhanVien] (Hoten,SoDienThoai,Account,Password) VALUES ("+ten+","+sdt+","+tk+","+mk+")";

                    //OleDbDataReader readerr = Program.Database.SelectSQL(sql);

                    MessageBox.Show(sql);
                    this.Close();

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
