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

    public partial class Account : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string name, password;
        bool flag = false;
        public Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button4.Visible = true;
            label1.Text = "Enter the new username.";
            flag = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update adminlogin set username = '{textBox2.Text}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Username Changed.");
                textBox2.Visible = false;
                button4.Visible = false;

            }
            else
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update adminlogin set pass = '{textBox2.Text}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

                MessageBox.Show("Password Changed.");
                textBox2.Visible = false;
                button4.Visible = false;
            }
            textBox2.Clear();
        }

        private void Account_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from adminlogin", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                name = reader[0].ToString();
                password = reader[1].ToString();
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button4.Visible = true;
            label1.Text = "Enter the new password.";
            flag = false;

        }
    }
}
