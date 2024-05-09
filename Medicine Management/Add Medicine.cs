using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Medicine_Management
{
    public partial class Add_Medicine : Form
    {
        string mname = "", cnamem = "", mtype = "";
        SqlConnection conn;
        SqlCommand cmd;
        Boolean flag = true;
        int cid;
        public Add_Medicine()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Medicine_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select cname from company", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                int i = 0;
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[i].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            mname = textBox1.Text;
            mtype = comboBox2.Text;
            cnamem = comboBox1.Text;
            //checking the form submission
            if (mname == "")
            {
                flag = false;
            }
            else if (mtype == "")
            {
                flag = false;
            }
            else if (cnamem == "")
            {
                flag = false;
            }
            //getting the cid 
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");

                conn.Open();
                cmd = new SqlCommand($"select cid from company where cname = '{cnamem}'", conn);
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

            //inserting the medicine in db
            if (flag)
            {
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
                MessageBox.Show("Medicine added.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Check the fields.");
            }
        }
    }
}
