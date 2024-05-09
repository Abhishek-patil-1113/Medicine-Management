using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine_Management
{
    public partial class Company_Report : Form
    {
        SqlConnection conn;
        SqlDataAdapter adpt;
        SqlCommand cmd;
        public Company_Report()
        {
            InitializeComponent();
        }

        private void Company_Report_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select cname from company", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = $"select * from company where cname = '{listBox1.SelectedItem.ToString()}'";
                conn.Open();
                cmd = new SqlCommand (q, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label10.Text = reader[0].ToString();
                label12.Text = reader[1].ToString();
                label11.Text = reader[2].ToString();
                label9.Text = reader[3].ToString();
            }
            catch (Exception)
            {

            }
            finally
            {
                conn.Close();

            }

            //label9 is cid
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                string q = $"select mname as 'Name' , mtype as 'Type' from medicine where cid = {Convert.ToInt32(label9.Text)}";
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
