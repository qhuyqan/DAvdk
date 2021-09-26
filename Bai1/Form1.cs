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
            String sql = "";
            OleDbDataReader reader = Program.Database.SelectSQL(sql);
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
                    DataTable my_data = new DataTable();
                    String sql = "SELECT * FROM DanhSachSanPham WHERE MaSP=" + txtMaSanPham.Text + "";
                    my_data.Load(Program.Database.SelectSQL(sql));
                }
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }
    }
}
