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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Medicine_Management
{
    public partial class Add_Stock : Form
    {
        SqlConnection conn,conn1;
        SqlCommand cmd;
        SqlDataReader reader1;
        Boolean flag = true;
        string mname = "";
        double price;
        int quantity, q;
        public Add_Stock()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Visible = true;
            button1.Visible = true;
            textBox1.Visible = true;

            label3.Visible = false;
            button4.Visible = false;
            textBox2.Visible = false;

            flag = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            button4.Visible = true;
            textBox2.Visible = true;

            label2.Visible = false;
            button1.Visible = false;
            textBox1.Visible = false;

            flag = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            
            //validation
            try
            {
                price = Convert.ToDouble(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Invalid amount.");
                flag = false;
            }

            //changing the price in db.
            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update stock set price = {price} where mname = '{mname}'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Price changed.");
                }
                catch (Exception)
                {
                    MessageBox.Show("Invalid Price.");
                }
                finally
                {
                    conn.Close();
                }
                label2.Visible = false;
                button1.Visible = false;
                textBox1.Visible = false;
            }
            
            //refresh
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from stock where mname = '{mname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label4.Text = "Rs. " + reader[1].ToString() + "/-";
                label5.Text = reader[2].ToString();
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        private void Add_Stock_Load(object sender, EventArgs e)
        {

            //filling the medicine collection with database.
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select mname from medicine", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select mname from medicine", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            flag = true;
            //validation
            try 
            {
                quantity = Convert.ToInt32(textBox2.Text);
            }
            catch 
            {
                MessageBox.Show("Invalid Quantity.");
                flag = false;
            }

            if (label5.Text.ToString() == "")
            {
                q = 0;
            }
            else
            {
                q = Convert.ToInt32(label5.Text);
            }
            
            q = q + quantity;

            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update stock set quantity = {q} where mname = '{mname}'", conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Stock changed.");
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                label3.Visible = false;
                button4.Visible = false;
                textBox2.Visible = false;
            }
            
            //refresh
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from stock where mname = '{mname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label4.Text = "Rs. " + reader[1].ToString() + "/-";
                label5.Text = reader[2].ToString();
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label7.Visible = true;
            label6.Visible = true;
            label5.Visible = true;
            label4.Visible = true;
            button2.Visible = true;
            button3.Visible = true;

            mname = comboBox1.Text;
            
            //adding the medicine details in the fields
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from stock where mname = '{mname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                label4.Text = "Rs. " + reader[1].ToString() + "/-";
                label5.Text = reader[2].ToString();
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }
    
    }
}
