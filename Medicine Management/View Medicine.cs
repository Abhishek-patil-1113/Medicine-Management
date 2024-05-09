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
using System.Xml.Linq;

namespace Medicine_Management
{
    public partial class View_Medicine : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adpt;
        public View_Medicine()
        {
            InitializeComponent();
        }

        private void View_Medicine_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select mname from medicine where mname like '{textBox1.Text}%'", conn);
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
            string medi = listBox1.SelectedItem.ToString();
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select m.mname ,m.mtype, cname from medicine as m left join company as c on c.cid = m.cid where mname = '{medi}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label5.Text = reader[0].ToString();
                label6.Text = reader[1].ToString();
                label7.Text = reader[2].ToString();
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
