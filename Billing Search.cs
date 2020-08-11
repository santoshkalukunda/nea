using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Nepal_Electricity_Authority
{
    public partial class Billing_Search : Form
    {
        public Billing_Search()
        {
            InitializeComponent();
        }

        private void Billing_Search_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nEADataSet4.bill' table. You can move, or remove it, as needed.
            this.billTableAdapter.Fill(this.nEADataSet4.bill);
            gridview();
            utotal();
            ftotal();
            ttotal();
            atotal();
            ptotal();
            rtotal();


        }
        public void utotal()
        {
            double sum = 0;
            for(int i=0; i<dataGridView1.RowCount-1; i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString());
            }
            label2.Text =sum.ToString();
        }

        public void atotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value.ToString());
            }
            label3.Text = sum.ToString();
        }

        public void rtotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[8].Value.ToString()) == "")
                {
                    continue;
                }
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value.ToString());
            }
            label4.Text = sum.ToString();
        }
        public void ftotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[9].Value.ToString()) == "")
                {
                    continue;
                }
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString());
            }
            label5.Text = sum.ToString();
        }
        public void ttotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if(Convert.ToString(dataGridView1.Rows[i].Cells[10].Value.ToString())=="")
                {
                    continue;
                }
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value.ToString());
            }
            label6.Text = sum.ToString();
        }
        public void ptotal()
        {
            double sum = 0;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (Convert.ToString(dataGridView1.Rows[i].Cells[11].Value.ToString()) == "")
                {
                    continue;
                }
                sum = sum + Convert.ToDouble(dataGridView1.Rows[i].Cells[11].Value.ToString());
            }
            label7.Text = sum.ToString();
        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM bill";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Customer Id")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from bill where Cid like'" + textBox1.Text + "%' order by Id desc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                utotal();
                ftotal();
                ttotal();
                atotal();
                ptotal();
                rtotal();
            }
            if (comboBox1.Text == "Name")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from bill where Name like'" + textBox1.Text + "%' order by Id desc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                utotal();
                ftotal();
                ttotal();
                atotal();
                ptotal();
                rtotal();
            }
            if (comboBox1.Text == "Year/Month")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from bill where Yearmonth like'" + textBox1.Text + "%' order by Id desc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                utotal();
                ftotal();
                ttotal();
                atotal();
                ptotal();
                rtotal();
            }
            if (comboBox1.Text == "Reading Date")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from bill where Rdate like'" + textBox1.Text + "%' order by Id desc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                utotal();
                ftotal();
                ttotal();
                atotal();
                ptotal();
                rtotal();
            }
            if (comboBox1.Text == "Payment Date")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from bill where Pdate like'" + textBox1.Text + "%' order by Id desc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                utotal();
                ftotal();
                ttotal();
                atotal();
                ptotal();
                rtotal();
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
