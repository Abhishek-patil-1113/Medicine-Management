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

    public partial class Company_List : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        public Company_List()
        {
            InitializeComponent();
        }

        private void Company_List_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = "select cid as 'Company ID', cname as 'Name',ccity as 'City', clocation as 'Location' from company";
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

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = "select cid as 'Company ID', cname as 'Name',ccity as 'City', clocation as 'Location' from company";
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
