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
                new Microsoft.Reporting.WinForms.ReportParameter("pCustomerName",_orders.CustomerName),
                new Microsoft.Reporting.WinForms.ReportParameter("pOrderDate",_orders.OrderDate),
                new Microsoft.Reporting.WinForms.ReportParameter("pPhone",_orders.Phone)
            };
            this.reportViewer.LocalReport.SetParameters(p);
            this.reportViewer.RefreshReport();
        }
    }
}
