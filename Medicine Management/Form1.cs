using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicine_Management
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string s1 = string.Empty;
        string s2 = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select * from adminlogin", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                s1 = reader[0].ToString();
                s2 = reader[1].ToString();
                
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            if (textBox1.Text == s1 && textBox2.Text == s2)
            {
                MessageBox.Show("Welcome " + s1 + ".");


                Dashbaord d = new Dashbaord();
                d.Show();




                this.Hide();
            }
            else {
                MessageBox.Show("Invalid Log in details.");
            }

        }
    }
}
