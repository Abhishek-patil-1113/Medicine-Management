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
    public partial class Medicne_List : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        public Medicne_List()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Medicne_List_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = "select m.mname as 'Name',m.mtype as 'Type', cname as 'Company' from medicine as m left join company as c on c.cid = m.cid";
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
                string q = "select m.mname as 'Name',m.mtype as 'Type', cname as 'Company' from medicine as m left join company as c on c.cid = m.cid";
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
