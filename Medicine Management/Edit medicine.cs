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
    public partial class Edit_medicine : Form
    {
        string mnameo = "" , mname = "", mtype = "",cname = "";
        SqlConnection conn;
        SqlCommand cmd;
        Boolean flag = true;
        int cid;

        private void Edit_medicine_Load(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Edit_medicine()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            mname = textBox1.Text;
            mtype = comboBox2.Text;
            mnameo = comboBox1.Text;
            cname = comboBox3.Text;

            //checking the form submission
            if (mname == "")
            {
                flag = false;
            }
            //else if (mtype == "")
            //{
            //    flag = false;
            //}
            //else if (cname == "")
            //{
            //    flag = false;
            //}

            //getting the cid
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select cid from company where cname = '{cname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                cid = Convert.ToInt32(reader[0]);
            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }

            //checking the name in DB
            if (mname != mnameo)
            {
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                    conn.Open();
                    cmd = new SqlCommand($"select * from medicine where mname = '{mname}'", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        flag = false;
                        MessageBox.Show("Medicine already Exist.");
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

            //inserting the medicine in db.
            if (flag)
            {
                //delete the stock first
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"delete from stock where mname = '{mnameo}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

                //delete the medicine
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"delete from medicine where mname = '{mnameo}'", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

                //inserting the changed medicine.
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"insert into medicine values ('{mname}', '{mtype}', {cid})", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

                //insert into stock
                try
                {
                    conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                    conn.Open();
                    cmd = new SqlCommand($"insert into stock (mname) values ('{mname}')", conn);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
                finally
                {
                    conn.Close();
                }

                // with update query
                //    try
                //    {
                //        conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                //        conn.Open();
                //        cmd = new SqlCommand($"update medicine set mname = '{mname}' where mname = '{mnameo}'", conn);
                //        cmd.ExecuteNonQuery();
                //    }
                //    catch (Exception)
                //    {
                //    }
                //    finally
                //    {
                //        conn.Close();
                //    }

                //    //changing the name in stock as well
                //    try
                //    {
                //        conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                //        conn.Open();
                //        cmd = new SqlCommand($"update stock set mname = '{mname}' where mname = '{mnameo}'", conn);
                //        cmd.ExecuteNonQuery();
                //    }
                //    catch (Exception)
                //    {
                //    }
                //    finally
                //    {
                //        conn.Close();
                //    }
                MessageBox.Show("Medicine edited.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Check the fields.");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            groupBox1.Visible = true;
            mname = comboBox1.Text;
            //adding the company names in the combobox
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select cname from company", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0].ToString());
                }
            }
            catch (Exception) { }

            finally { conn.Close(); }
            //adding the medicine details in the fields
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from medicine where mname = '{mname}'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                textBox1.Text = reader[0].ToString();
                comboBox2.Text = reader[1].ToString();
                cid = Convert.ToInt32(reader[2].ToString());
            }
            catch (Exception) { }

            finally { conn.Close(); }

            //getting the company name
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select cname from company where cid = {cid}", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                comboBox3.Text = reader[0].ToString();
            }
            catch (Exception) { }

            finally { conn.Close(); }
        }
    }
}
