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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            con.Open();


        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Accounts_DB;Integrated Security=True");
        void GetListSales()
        {

            SqlCommand c = new SqlCommand("exec SalesList", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            //c.ExecuteNonQuery();

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        GetListSales();
    }

        private void button2_Click(object sender, EventArgs e)
        {
            //Insert
            string salesID = textBox3.Text;
            string customerId = textBox1.Text;
            string productName = textBox2.Text;
            int pieces = int.Parse(textBox5.Text);
             DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int amount = int.Parse(textBox4.Text);
            string paymentStatus = "";
            if (radioButton1.Checked == true) { paymentStatus = "Paid"; }
            else { paymentStatus = "Unpaid"; }


            SqlCommand c = new SqlCommand("exec InsertSales'" + salesID + "','" + customerId + "','" + productName + "','" + pieces + "','" + date +
                "','" + amount + "' , '"+paymentStatus+"'",con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Inserted...");

            GetListSales();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            string salesID = textBox3.Text;
            string customerId = textBox1.Text;
            string productName = textBox2.Text;
            int pieces = int.Parse(textBox5.Text);
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int amount = int.Parse(textBox4.Text);
            string paymentStatus = "";



            if (radioButton1.Checked == true) { paymentStatus = "Paid"; }
            else { paymentStatus = "Unpaid"; }


            SqlCommand c = new SqlCommand("exec UpdateSales'" + salesID + "','" + customerId + "','" + productName + "','" + pieces + "','" + date +
                "','" + amount + "' , '" + paymentStatus + "'", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated...");

            GetListSales();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
