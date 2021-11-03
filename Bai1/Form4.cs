using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using System.Configuration;
using System.Data.OleDb;

namespace Bai1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["Bai1.Properties.Settings.Database1ConnectionString"].ConnectionString))
            {
                if (db.State == ConnectionState.Closed)
                {
                    db.Open();
                }
                string sql = "SELECT * FROM SanPhamDaBan";
                ordersBindingSource2.DataSource = db.Query<Orders>(sql, CommandType.Text);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Orders obj = ordersBindingSource2.Current as Orders;
            if (obj != null)
            {
                using (IDbConnection db = new OleDbConnection(ConfigurationManager.ConnectionStrings["Bai1.Properties.Settings.Database1ConnectionString"].ConnectionString))
                {
                    if (db.State == ConnectionState.Closed)
                    {
                        db.Open();
                    }
                    string sql = "SELECT * FROM SanPhamDaBan WHERE OrderID = " + obj.OrderID + "";
                    List<OrderDetail> list = db.Query<OrderDetail>(sql, CommandType.Text).ToList();
                    Form5 f5 = new Form5(obj, list);
                    f5.ShowDialog();                    
                }
            }
        }
    }
}
