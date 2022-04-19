using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace AccountsManagement
{
    public partial class Purchase : Form
    {
        public Purchase()
        {
            InitializeComponent();
            con.Open();

        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Accounts_DB;Integrated Security=True");
        void GetListPurchase()
        {

            SqlCommand c = new SqlCommand("exec PurchaseList", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            //c.ExecuteNonQuery();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            GetListPurchase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Insert
            string PurchaseID = textBox3.Text;
            string StoreId = textBox1.Text;
            string productName = textBox2.Text;
            int pieces = int.Parse(textBox5.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int amount = int.Parse(textBox4.Text);
            string paymentStatus = "";



            if (radioButton1.Checked == true) { paymentStatus = "Paid"; }
            else { paymentStatus = "Unpaid"; }


            SqlCommand c = new SqlCommand("exec InsertPurchase'" + PurchaseID + "','" + StoreId + "','" + productName + "','" + pieces + "','" + date +
                "','" + amount + "' , '" + paymentStatus + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted...");

            GetListPurchase();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            string PurchaseID = textBox3.Text;
            string StoreId = textBox1.Text;
            string productName = textBox2.Text;
            int pieces = int.Parse(textBox5.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int amount = int.Parse(textBox4.Text);
            string paymentStatus = "";



            if (radioButton1.Checked == true) { paymentStatus = "Paid"; }
            else { paymentStatus = "Unpaid"; }


            SqlCommand c = new SqlCommand("exec UpdatePurchase'" + PurchaseID + "','" + StoreId + "','" + productName + "','" + pieces + "','" + date +
                "','" + amount + "' , '" + paymentStatus + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated...");

            GetListPurchase();
        }
    }
}
