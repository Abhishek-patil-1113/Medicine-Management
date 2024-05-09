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
    public partial class Add_Sale : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        int qq, q;
        bool flag;
        DateTime dt;
        public Add_Sale()
        {
            InitializeComponent();
        }

        private void Add_Sale_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
            try
            {
                label5.Text = listBox1.SelectedItem.ToString();
                groupBox1.Visible = true;
            }
            catch (Exception) { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dt = DateTime.Now;
            string sqlFormattedDate = dt.ToString("yyyy-MM-dd HH:mm:ss.fff");
            flag = true;

            try 
            {
                q = Convert.ToInt32(textBox2.Text);
            }
            catch(Exception)
            {
                flag = false;
                MessageBox.Show("Enter the valid quantity");    
            }

            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select quantity from stock where mname = '{label5.Text}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                qq = Convert.ToInt32(reader[0].ToString());
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            if (q > qq)
            {
                MessageBox.Show($"Enough stock is not available.\nCurrent Stock for {label5.Text} is {qq}.");
                flag = false;
            }
            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"insert into sales values ('{label5.Text}', {q}, '{sqlFormattedDate}')", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    qq = Convert.ToInt32(reader[0].ToString());
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update stock set quantity = {qq-q} where mname = '{label5.Text}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Sale added.");
                this.Close();
            }
        }
    }
}
