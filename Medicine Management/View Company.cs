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
    public partial class View_Company : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        public View_Company()
        {
            InitializeComponent();
        }

        private void View_Company_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select cname from company where cname like '{textBox1.Text}%'", conn);
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
            listBox1.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                string medi = listBox1.SelectedItem.ToString();
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from company where cname = '{medi}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label5.Text = reader[0].ToString();
                label6.Text = reader[1].ToString();
                label7.Text = reader[2].ToString();
                label8.Text = reader[3].ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            groupBox1.Visible = true;
        }
    }
}
