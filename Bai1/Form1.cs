using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        double tongTien = 0;
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
                btnScan.Enabled = true;
                btnNew.Enabled = true;
                txtIsConnect.Text = "Connected";
                txtIsConnect.ForeColor = Color.Green;
            }
            catch { }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            btnCon.Enabled = true;
            btnDis.Enabled = false;
            btnScan.Enabled = false;
            btnNew.Enabled = false;
            txtIsConnect.Text = "Not Connected";
            txtIsConnect.ForeColor = Color.Red;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtKhachHang.Text = "";
            tongTien = 0;
            txtTongTien.Text = "";
        }

        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Camera.Retrieve(frame);
            try
            {
                picCam.Image = frame.ToImage<Bgr, byte>().Bitmap;
            }
            catch { }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDis.Enabled = false;
            btnScan.Enabled = false;
            btnNew.Enabled = false;
            Camera = new Capture(0);
            Camera.ImageGrabbed += Camera_ImageGrabbed;
            Camera.Start();

            timer2.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write("get_weight");
            //if (picCam.Image != null)
            //{
            //    BarcodeReader readQR = new BarcodeReader();
            //    Result result = readQR.Decode((Bitmap)picCam.Image);
            //    if (result != null)
            //    {
            //        txtMaSanPham.Text = result.ToString();
            //    }
            //}
            Bitmap img = (Bitmap)picCam.Image;
            if (img != null)
            {
                
                try
                {
                    ZXing.BarcodeReader Reader = new ZXing.BarcodeReader();
                    Result result = Reader.Decode(img);
                    string decoded = result.ToString().Trim();
                    if (!txtMaSanPham.Text.Contains(decoded))
                    {
                        txtMaSanPham.Text = decoded;
                        //img.Dispose();
                    }

                    OpenConnection();
                    OleDbCommand sqlCmd = new OleDbCommand();
                    sqlCmd.CommandType = CommandType.Text;
                    sqlCmd.CommandText = "SELECT * FROM DanhSachSanPham WHERE IdSanPham = " + txtMaSanPham.Text + "";
                    sqlCmd.Connection = sqlCon;
                    OleDbDataReader reader = sqlCmd.ExecuteReader();
                    //serialPort1_DataReceived();
                    if (reader.Read() == true)
                    {
                        string tenSP = reader.GetString(1);
                        int donGia = reader.GetInt32(2);
                        //string khoiLuong = serialPort1.ReadExisting();
                        double thanhTien = donGia * 0.6851;//float.Parse(khoiLuong);
                        // Show 
                        txtTenSanPham.Text = tenSP;
                        txtDonGia.Text = donGia.ToString();
                        //txtKhoiLuong.Text = khoiLuong.ToString() + " kg ";
                        txtThanhTien.Text = thanhTien.ToString();
                    }
                    reader.Close();
                    //timer1.Stop();
                    tongTien = tongTien + double.Parse(txtThanhTien.Text);
                    txtTongTien.Text = tongTien.ToString();
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + "");
                }

            }
            try
            {
                
            }
            catch { }
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

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                OpenConnection();

                OleDbCommand sqlCmd = new OleDbCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "INSERT INTO SanPhamDaBan(TenKhachHang,MaSP,TenSP,KhoiLuong,DonGia,ThanhTien,ThoiGian) VALUES (@tenkhachhang,@masp,@tensp,@kg,@dongia,@thanhtien,@thoigian)";
                if (txtKhachHang.Text != "")
                {
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

                    OleDbParameter thanhtien = new OleDbParameter("@thanhtien", OleDbType.BSTR);
                    thanhtien.Value = txtThanhTien.Text.Trim();
                    sqlCmd.Parameters.Add(thanhtien);

                    OleDbParameter thoigian = new OleDbParameter("@thoigian", OleDbType.BSTR);
                    thoigian.Value = lblDate.Text.Trim() + " " + lblTime.Text.Trim();
                    sqlCmd.Parameters.Add(thoigian);


                    sqlCmd.Connection = sqlCon;
                    int result = sqlCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        this.CloseConnection();
                        txtMaSanPham.Text = "";
                        txtTenSanPham.Text = "";
                        txtKhoiLuong.Text = "";
                        txtDonGia.Text = "";
                        txtThanhTien.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("NHẬP KHÔNG THÀNH CÔNG");
                    }
                }
                else
                {
                    MessageBox.Show("PLEASE ENTER CUSTOMER'S NAME");
                }
            }
            catch
            {
                MessageBox.Show("chưa quét");
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToShortTimeString();
            lblDate.Text = DateTime.Now.ToShortDateString();
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string weight = serialPort1.ReadExisting();
            Invoke(new MethodInvoker(() => txtKhoiLuong.Text = weight));
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();
        }
    }
}
