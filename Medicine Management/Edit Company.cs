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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Medicine_Management
{
    public partial class Edit_Company : Form
    {
        string cname = "", cnameo = "", clocation = "", ccity = "";
        SqlConnection conn;
        SqlCommand cmd;
        Boolean flag = true;

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            cname = comboBox1.Text;
            //adding the medicine details in the fields
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from company where cname = '{cname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                textBox1.Text = reader[0].ToString();
                textBox2.Text = reader[1].ToString();
                textBox3.Text = reader[2].ToString();
                label6.Text = reader[3].ToString();
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        public Edit_Company()
        {
            InitializeComponent();
        }

        private void Edit_Company_Load(object sender, EventArgs e)
        {
            //filling the company collection with database.
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select cname from company", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }   
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            cname = textBox1.Text;
            clocation = textBox2.Text;
            ccity = textBox3.Text;
            cnameo = comboBox1.Text;

            //checking the form submission
            if (cname == "")
            {
                flag = false;
            }
            else if (ccity== "")
            {
                flag = false;
            }
            else if (clocation == "")
            {
                flag = false;
            }

            
            //checking the name in DB

            if (cname != cnameo)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                    conn.Open();
                    cmd = new SqlCommand($"select * from company where cname = '{cname}'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        flag = false;
                        MessageBox.Show("Company already Exist.");
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
            
            //inserting the company in db.
            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"update company set cname = '{cname}', clocation = '{clocation}', ccity = '{ccity}'where cname = '{cnameo}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show("Company edited.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Check the fields.");
            }
        }
    }
}
