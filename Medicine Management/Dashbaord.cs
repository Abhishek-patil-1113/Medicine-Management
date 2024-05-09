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
    public partial class Dashbaord : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        string s1;
        public Dashbaord()
        {
            InitializeComponent();
        }

        private void Dashbaord_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(@"Server=ABHI;Database=Medicine Management;Trusted_Connection=True;");
                conn.Open();
                cmd = new SqlCommand($"select * from adminlogin", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                s1 = reader[0].ToString();

            }
            catch (Exception)
            {
            }
            finally
            {
                conn.Close();
            }
            label1.Text = s1;
        }

        private void medToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Add_Medicine am = new Add_Medicine();
            am.Show();
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Add_Company ac = new Add_Company();
            ac.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Edit_medicine em = new Edit_medicine();
            em.Show();
        }

        private void editToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Edit_Company ec = new Edit_Company();
            ec.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Medicne_List mc = new Medicne_List();
            mc.Show();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Company_List cl = new Company_List();
            cl.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            View_Medicine vm = new View_Medicine();
            vm.Show();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            View_Company vc = new View_Company();
            vc.Show();
        }

        private void stockToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void allStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            All_Stock alls = new All_Stock();
            alls.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Stock adds = new Add_Stock();
            adds.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Account account = new Account();
            account.Show();
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Add_Sale adds = new Add_Sale();
            adds.Show();
        }

        private void salesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Sales_List sl = new Sales_List();
            sl.Show();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Company_Report cr = new Company_Report();
            cr.Show();
        }

        private void salesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sales_Report sr = new Sales_Report();
            sr.Show();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Medicine_Report mr = new Medicine_Report();
            mr.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
