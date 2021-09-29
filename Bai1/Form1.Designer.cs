namespace Bai1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnCon = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnNhap = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThanhTien = new System.Windows.Forms.TextBox();
            this.txtDonGia = new System.Windows.Forms.TextBox();
            this.txtKhoiLuong = new System.Windows.Forms.TextBox();
            this.txtTenSanPham = new System.Windows.Forms.TextBox();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picCam = new System.Windows.Forms.PictureBox();
            this.btnEsc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCon
            // 
            this.btnCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnCon.Location = new System.Drawing.Point(1021, 92);
            this.btnCon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCon.Name = "btnCon";
            this.btnCon.Size = new System.Drawing.Size(164, 62);
            this.btnCon.TabIndex = 1;
            this.btnCon.Text = "Connect";
            this.btnCon.UseVisualStyleBackColor = true;
            this.btnCon.Click += new System.EventHandler(this.btnCon_Click);
            // 
            // btnDis
            // 
            this.btnDis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnDis.Location = new System.Drawing.Point(1021, 179);
            this.btnDis.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(164, 62);
            this.btnDis.TabIndex = 2;
            this.btnDis.Text = "Disconnect";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(180, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(899, 58);
            this.label1.TabIndex = 5;
            this.label1.Text = "ĐỒ ÁN VI ĐIỀU KHIỂN - CÂN ĐIỆN TỬ";
            // 
            // btnNhap
            // 
            this.btnNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhap.Location = new System.Drawing.Point(161, 514);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(198, 56);
            this.btnNhap.TabIndex = 16;
            this.btnNhap.Text = "NHẬP";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtThanhTien);
            this.panel1.Controls.Add(this.btnNhap);
            this.panel1.Controls.Add(this.txtDonGia);
            this.panel1.Controls.Add(this.txtKhoiLuong);
            this.panel1.Controls.Add(this.txtTenSanPham);
            this.panel1.Controls.Add(this.txtMaSanPham);
            this.panel1.Controls.Add(this.txtKhachHang);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(549, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 581);
            this.panel1.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 435);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 29);
            this.label2.TabIndex = 30;
            this.label2.Text = "Thành tiền";
            // 
            // txtThanhTien
            // 
            this.txtThanhTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThanhTien.Location = new System.Drawing.Point(213, 354);
            this.txtThanhTien.Name = "txtThanhTien";
            this.txtThanhTien.Size = new System.Drawing.Size(232, 22);
            this.txtThanhTien.TabIndex = 29;
            // 
            // txtDonGia
            // 
            this.txtDonGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonGia.Location = new System.Drawing.Point(213, 296);
            this.txtDonGia.Name = "txtDonGia";
            this.txtDonGia.Size = new System.Drawing.Size(232, 22);
            this.txtDonGia.TabIndex = 28;
            // 
            // txtKhoiLuong
            // 
            this.txtKhoiLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhoiLuong.Location = new System.Drawing.Point(213, 238);
            this.txtKhoiLuong.Name = "txtKhoiLuong";
            this.txtKhoiLuong.Size = new System.Drawing.Size(232, 22);
            this.txtKhoiLuong.TabIndex = 27;
            // 
            // txtTenSanPham
            // 
            this.txtTenSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenSanPham.Location = new System.Drawing.Point(213, 180);
            this.txtTenSanPham.Name = "txtTenSanPham";
            this.txtTenSanPham.Size = new System.Drawing.Size(232, 22);
            this.txtTenSanPham.TabIndex = 26;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaSanPham.Location = new System.Drawing.Point(213, 122);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(232, 22);
            this.txtMaSanPham.TabIndex = 25;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhachHang.Location = new System.Drawing.Point(213, 64);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.Size = new System.Drawing.Size(232, 22);
            this.txtKhachHang.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 354);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 29);
            this.label12.TabIndex = 24;
            this.label12.Text = "Thành tiền";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 296);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 29);
            this.label11.TabIndex = 23;
            this.label11.Text = "Đơn giá";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 29);
            this.label10.TabIndex = 22;
            this.label10.Text = "Khối lượng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 29);
            this.label9.TabIndex = 21;
            this.label9.Text = "Tên sản phẩm";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(167, 29);
            this.label8.TabIndex = 20;
            this.label8.Text = "Mã sản phẩm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 29);
            this.label7.TabIndex = 19;
            this.label7.Text = "Khách hàng";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(129, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(230, 29);
            this.label6.TabIndex = 18;
            this.label6.Text = "Thông tin đơn hàng";
            // 
            // btnScan
            // 
            this.btnScan.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnScan.Location = new System.Drawing.Point(1021, 266);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(164, 62);
            this.btnScan.TabIndex = 19;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnShow
            // 
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnShow.Location = new System.Drawing.Point(1021, 353);
            this.btnShow.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(164, 62);
            this.btnShow.TabIndex = 20;
            this.btnShow.Text = "Show";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picCam
            // 
            this.picCam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCam.Location = new System.Drawing.Point(12, 92);
            this.picCam.Name = "picCam";
            this.picCam.Size = new System.Drawing.Size(531, 418);
            this.picCam.TabIndex = 18;
            this.picCam.TabStop = false;
            // 
            // btnEsc
            // 
            this.btnEsc.BackColor = System.Drawing.SystemColors.Window;
            this.btnEsc.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)), true);
            this.btnEsc.Image = global::Bai1.Properties.Resources.icons8_close_window_64;
            this.btnEsc.Location = new System.Drawing.Point(1127, 605);
            this.btnEsc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEsc.Name = "btnEsc";
            this.btnEsc.Size = new System.Drawing.Size(58, 59);
            this.btnEsc.TabIndex = 0;
            this.btnEsc.UseVisualStyleBackColor = false;
            this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 676);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.picCam);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDis);
            this.Controls.Add(this.btnCon);
            this.Controls.Add(this.btnEsc);
            this.Font = new System.Drawing.Font("Matura MT Script Capitals", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEsc;
        private System.Windows.Forms.Button btnCon;
        private System.Windows.Forms.Button btnDis;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtThanhTien;
        private System.Windows.Forms.TextBox txtDonGia;
        private System.Windows.Forms.TextBox txtKhoiLuong;
        private System.Windows.Forms.TextBox txtTenSanPham;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picCam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Timer timer1;
    }
}

