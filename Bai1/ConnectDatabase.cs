using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Bai1
{
    class ConnectDatabase
    {
        OleDbConnection myConnection = new OleDbConnection();

        public void Connect()
        {
            try
            {
                myConnection.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database1.mdb";
                myConnection.Open();
            }
            catch { }
        }

        public OleDbDataReader SelectSQL(string sql)
        {
            OleDbCommand cmd = myConnection.CreateCommand();
            cmd.CommandText = sql;
            OleDbDataReader reader = cmd.ExecuteReader();
            cmd.Dispose();
            return reader;
        }

        public int UpdateSQL(string sql)
        {
            OleDbCommand cmd = myConnection.CreateCommand();
            cmd.CommandText = sql;
            int result = cmd.ExecuteNonQuery();
            cmd.Dispose();
            return result;
        }
        public void Close()
        {
            try
            {
                if (myConnection != null && myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }
            catch { }
        }
    }
}
