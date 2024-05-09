using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine_Management
{
    public partial class Medicine_Report : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        string t1, t2;
        DateTime dt1, dt2;
        public Medicine_Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt1 = dateTimePicker1.Value;
            dt2 = dateTimePicker2.Value;
            t1 = dt1.ToString("yyyy-MM-dd HH:mm:ss.fff");
            t2 = dt2.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = $"select mname as 'Medicine', sum(squantity) as 'Total sold units'  from sales where dt between '{t1}' and '{t2}' group by mname ";
                conn.Open();
                adpt = new SqlDataAdapter(q, conn);
                DataTable dataTable = new DataTable();
                adpt.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();

            }
        }
    }
}
