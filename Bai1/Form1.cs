using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Emgu.CV;
using Emgu.CV.Structure;
using ZXing;

namespace Bai1
{
    public partial class Form1 : Form
    {
        Capture Camera;
        string strCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\qhuyd\Desktop\DA\Bai1\Bai1\bin\Debug\Database1.mdb";
        OleDbConnection sqlCon = null;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEsc_Click(object sender, EventArgs e)
        {
            Close();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
                btnCon.Enabled = false;
                btnDis.Enabled = true;
                txtConnected.Text = "Connected";
            }
            catch { }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            btnCon.Enabled = true;
            btnDis.Enabled = false;
            txtConnected.Text = "Not Connected";
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            OpenConnection();

            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT INTO SanPhamDaBan(TenKhachHang,MaSP,TenSP,KhoiLuong,DonGia,TongTien,ThoiGian) VALUES (@tenkhachhang,@masp,@tensp,@kg,@dongia,@tongtien,@thoigian)";

            OleDbParameter tenkhachhang = new OleDbParameter("@tenkhachhang", OleDbType.BSTR);
            tenkhachhang.Value = txtKhachHang.Text.Trim();
            sqlCmd.Parameters.Add(tenkhachhang);

            OleDbParameter masp = new OleDbParameter("@masp", OleDbType.Integer);
            masp.Value = int.Parse(txtMaSanPham.Text.Trim());
            sqlCmd.Parameters.Add(masp);

            OleDbParameter tensp = new OleDbParameter("@tensp", OleDbType.BSTR);
            tensp.Value = txtTenSanPham.Text.Trim();
            sqlCmd.Parameters.Add(tensp);

            OleDbParameter kg = new OleDbParameter("@kg", OleDbType.BSTR);
            kg.Value = txtKhoiLuong.Text.Trim();
            sqlCmd.Parameters.Add(kg);

            OleDbParameter dongia = new OleDbParameter("@dongia", OleDbType.BSTR);
            dongia.Value = txtDonGia.Text.Trim();
            sqlCmd.Parameters.Add(dongia);

            OleDbParameter tongtien = new OleDbParameter("@tongtien", OleDbType.BSTR);
            tongtien.Value = txtTongTien.Text.Trim();
            sqlCmd.Parameters.Add(tongtien);

            OleDbParameter thoigian = new OleDbParameter("@thoigian", OleDbType.BSTR);
            thoigian.Value = lblDate.Text.Trim() + ", " + lblTime.Text.Trim();
            sqlCmd.Parameters.Add(thoigian);

            sqlCmd.Connection = sqlCon;
            int result = sqlCmd.ExecuteNonQuery();
            if (result > 0)
            {
                MessageBox.Show("NHẬP THÀNH CÔNG");
                this.CloseConnection();
            }
            else
            {
                MessageBox.Show("NHẬP KHÔNG THÀNH CÔNG");
            }
        }

        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Camera.Retrieve(frame);
            picCam.Image = frame.ToImage<Bgr, byte>().Bitmap;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDis.Enabled = false;

            Camera = new Capture(1);
            Camera.ImageGrabbed += Camera_ImageGrabbed;
            Camera.Start();

            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Camera.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picCam.Image != null)
            {
                BarcodeReader readQR = new BarcodeReader();
                Result result = readQR.Decode((Bitmap)picCam.Image);
                if (result != null)
                {
                    txtMaSanPham.Text = result.ToString();
                }
            }

            OpenConnection();
            OleDbCommand sqlCmd = new OleDbCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM DanhSachSanPham WHERE IdSanPham = " + txtMaSanPham.Text + "";
            sqlCmd.Connection = sqlCon;
            OleDbDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read() == true)
            {
                string tenSP = reader.GetString(1);
                int donGia = reader.GetInt32(2);
                double thanhTien = donGia * 0.13573;
                // Show lên
                txtTenSanPham.Text = tenSP;
                txtDonGia.Text = donGia.ToString();
                txtThanhTien.Text = thanhTien.ToString();
            }

            reader.Close();
            timer1.Stop();

        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void txtTenSanPham_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
