using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai1
{
    public partial class Form5 : Form
    {
        Orders _orders;
        List<OrderDetail> _list;
        public Form5(Orders orders, List<OrderDetail> list)
        {
            InitializeComponent();
            _orders = orders;
            _list = list;
        }        
        private void FormPrint_Load(object sender, EventArgs e)
        {
            OrderDetailBindingSource.DataSource = _list;
            Microsoft.Reporting.WinForms.ReportParameter[] p = new Microsoft.Reporting.WinForms.ReportParameter[]{
                new Microsoft.Reporting.WinForms.ReportParameter("pOrderID",_orders.OrderID.ToString()),
                new Microsoft.Reporting.WinForms.ReportParameter("pTenKhachHang",_orders.TenKhachHang),
                new Microsoft.Reporting.WinForms.ReportParameter("pThoiGian",_orders.ThoiGian.ToString("MM/dd/yyyy"))

            };
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }
    }
}
