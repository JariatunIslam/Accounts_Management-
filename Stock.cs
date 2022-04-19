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
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            con.Open();

        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Accounts_DB;Integrated Security=True");
        void GetListStock()
        {

            SqlCommand c = new SqlCommand("exec StockList", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            c.ExecuteNonQuery();

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Insert
            string productId = textBox3.Text;
            string ProductName = textBox1.Text;
            int piecesLeft = int.Parse(textBox2.Text);
            int piecesSold = int.Parse(textBox5.Text);
            int Cost_Price = int.Parse(textBox4.Text);
            int Selling_Price = int.Parse(textBox6.Text);


            SqlCommand c = new SqlCommand("exec InsertStocks'" + productId + "','" + ProductName + "','" + piecesSold + "','" + piecesLeft + "','" + Cost_Price +
                "','" + Selling_Price + "' ", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
       
            MessageBox.Show("Successfully Inserted...");

            GetListStock();




        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetListStock();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update
            
            string productId = textBox3.Text;
            string ProductName = textBox1.Text;
            int piecesLeft = int.Parse(textBox2.Text);
            int piecesSold = int.Parse(textBox5.Text);
            int Cost_Price = int.Parse(textBox4.Text);
            int Selling_Price = int.Parse(textBox6.Text);


            SqlCommand c = new SqlCommand("exec UpdateStocks'" + productId + "','" + ProductName + "','" + piecesSold + "','" + piecesLeft + "','" + Cost_Price +
                "','" + Selling_Price + "' ", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);

            MessageBox.Show("Successfully Updates...");

            GetListStock();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //delete
            if (MessageBox.Show("Are you sure?", "Delete Document", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                string productId = textBox3.Text;
                SqlCommand c = new SqlCommand("exec DeleteStock '" + productId + "'", con);

                c.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted...");

                GetListStock();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
