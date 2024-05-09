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
    public partial class Sales_Report : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        string t1,t2;
        DateTime dt1,dt2;
        public Sales_Report()
        {
            InitializeComponent();
        }

        private void Sales_Report_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dt1 = dateTimePicker1.Value;
            dt2 = dateTimePicker2.Value;
            t1 = dt1.ToString("yyyy-MM-dd HH:mm:ss.fff");
            t2 = dt2.ToString("yyyy-MM-dd HH:mm:ss.fff");

            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = $"select saleid as 'Sale ID', mname as 'Medicine Name', squantity as 'Quantity', dt as 'Date' from sales where dt between '{t1}' and '{t2}'";
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

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
