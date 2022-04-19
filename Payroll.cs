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

namespace AccountsManagement
{
    public partial class Payroll : Form
    {
        public Payroll()
        {
            InitializeComponent();
            con.Open();
        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Accounts_DB;Integrated Security=True");
        void GetListPay()
        {

            SqlCommand c = new SqlCommand("exec PayList", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            //c.ExecuteNonQuery();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //insert

            string payId= textBox3.Text;
            string empId = textBox1.Text;
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int salary = int.Parse(textBox2.Text);
            string type = "";
            int bonus = int.Parse(textBox4.Text);


            if (radioButton1.Checked == true) { type = "Cash"; }
            else { type = "Bank"; }


            SqlCommand c = new SqlCommand("exec InsertPayroll'" + payId + "','" + empId + "','" + date + "','" + salary + "','" + type +
                "','" + bonus + "' ", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated...");

            GetListPay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetListPay();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update

            string payId = textBox3.Text;
            string empId = textBox1.Text;
            DateTime date = DateTime.Parse(dateTimePicker1.Text);
            int salary = int.Parse(textBox2.Text);
            string type = "";
            int bonus = int.Parse(textBox4.Text);


            if (radioButton1.Checked == true) { type = "Cash"; }
            else { type = "Bank"; }


            SqlCommand c = new SqlCommand("exec UpdatePayroll'" + payId + "','" + empId + "','" + date + "','" + salary + "','" + type +
                "','" + bonus + "' ", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            //c.ExecuteNonQuery();
            MessageBox.Show("Successfully Updated...");

            GetListPay();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
