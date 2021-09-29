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
        }

        private void btnCon_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Open();
            }
            catch { }
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {

        }    
            
        private void Camera_ImageGrabbed(object sender, EventArgs e)
        {
            Mat frame = new Mat();
            Camera.Retrieve(frame);
            picCam.Image = frame.ToImage<Bgr, byte>().Bitmap;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Camera = new Capture(1);
            Camera.ImageGrabbed += Camera_ImageGrabbed;
            Camera.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Camera.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (picCam.Image != null)
            {
                BarcodeReader reader = new BarcodeReader();
                Result result = reader.Decode((Bitmap)picCam.Image);
                if (result != null)
                {
                    txtMaSanPham.Text = result.ToString();
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
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
           
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
