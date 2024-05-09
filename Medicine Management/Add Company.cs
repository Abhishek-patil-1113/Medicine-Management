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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace Medicine_Management
{
    public partial class Add_Company : Form
    {
        string cname = "", clocation= "", ccity= "";
        SqlConnection conn;
        SqlCommand cmd;
        Boolean flag = true;
        int cid;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public Add_Company()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            cname = textBox1.Text;
            clocation = textBox2.Text;
            ccity = textBox3.Text;
            //getting the company id automatically from db
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select max(cid) from company", conn);
                SqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Read();
                var a = reader1[0];
                //MessageBox.Show(a.ToString());
                if (a.ToString() == "")
                {
                    cid = 1;
                }
                else
                {
                    cid = Convert.ToInt32(a.ToString()) + 1;
                }
            }
            catch (Exception) { }
            
            finally { conn.Close(); }

            //checking the form submission
            if (cname == "")
            {
                flag = false;
            }
            else if (clocation== "")
            {
                flag = false;
            }
            else if (ccity == "")
            {
                flag = false;
            }

            //checking the name in DB
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

            //inserting the company in db
            if (flag)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                    conn.Open();
                    cmd = new SqlCommand($"insert into company values ('{cname}', '{clocation}', '{ccity}',{cid})", conn);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }
                MessageBox.Show($"Company Added.\nID number of the new company is : \'{cid}\'");
                this.Close();
            }
            else
            {
                MessageBox.Show("Check the fields.");
            }
        }
    }
}
