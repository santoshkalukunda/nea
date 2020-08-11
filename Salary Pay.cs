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
    public partial class Salary_Pay : Form
    {
        public Salary_Pay()
        {
            InitializeComponent();
        }
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM salary order by Id desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();


        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void Salary_Pay_Load(object sender, EventArgs e)
        {
            gridview();
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM";
            dateTimePicker1.Value = DateTime.Now;
            textBox7.Hide();
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox2.Enabled = false;



        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox7.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            }
            catch
            {

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox6.Text = "0";
            textBox5.Text = "0";
            textBox4.Text = "0";
            textBox3.Text = "0";
           
            if (textBox1.Text == "" || textBox2.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Please Enter the Employee ID\n Check the employer is not registed in Employer :");

            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("insert into salary (Eid, Name, Month, Pdate, Amount, Tax, Pamount, Damount) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success To register Employer in salary" + textBox2.Text);
                    gridview();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    pictureBox1.Image = null;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
                catch (Exception)
                {
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter das = new SqlDataAdapter("select * from salary where Eid like'" + textBox1.Text + "%'order by Id desc ", conn);
            DataTable dtt = new DataTable();
            das.Fill(dtt);
            dataGridView1.DataSource = dtt;

            //label9.Text = (dataGridView1.RowCount - 1).ToString();
            if (textBox1.Text != "")
            {
                SqlConnection conn1 = new SqlConnection(str);

                SqlDataAdapter da = new SqlDataAdapter("select * from emp  where Id='" + textBox1.Text + "'", conn1);

                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {

                    if (dt.Rows.Count >= 1)
                    {
                        textBox2.Text = dt.Rows[0].ItemArray[1].ToString();


                        conn.Open();

                        byte[] images = ((byte[])dt.Rows[0].ItemArray[10]);

                        if (images == null)
                        {
                            pictureBox1.Image = null;

                        }
                        else
                        {
                            MemoryStream st = new MemoryStream(images);
                            pictureBox1.Image = Image.FromStream(st);

                        }

                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            if (textBox1.Text == "")
            {
                textBox2.Clear();
                pictureBox1.Image = null;
            }
            if (dataGridView1.RowCount > 1)
            {
                button4.Hide();
                button1.Show();
                button2.Show();
                button3.Show();
            }
            else
            {
                button4.Show();
                button1.Hide();
                button2.Hide();
                button3.Hide();
                
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
          if(textBox6.Text!="")
            {
                if(textBox5.Text!="")
                {
                    textBox4.Text = (Convert.ToDouble(textBox5.Text) - Convert.ToDouble(textBox6.Text)).ToString();
                }
                
               
            }
            else
            {
                textBox4.Text = "";
            }
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (textBox4.Text != "")
                {
                    textBox5.Text = (Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox4.Text)).ToString();
                }
                else
                {
                    textBox5.Text = textBox3.Text;
                }
            }
            else
            {
                textBox5.Clear();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Enter the Employer Id and \n click the top of the data on below of table ");
            }
            else { 
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("Update salary set Month='" + dateTimePicker1.Text + "',Pdate='" + dateTimePicker2.Text + "',Amount='" + textBox3.Text + "',Tax='" + textBox4.Text + "',Pamount='" + textBox5.Text + "',Damount='" + textBox6.Text + "'where Id='" + textBox7.Text + "' ", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update success : " + textBox2.Text);
                    gridview();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    pictureBox1.Image = null;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
                catch
                {

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to delete the Employer:", "Employer delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (textBox1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please Enter the Employer Id and \n click the top of the data on below of table ");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("Delete from salary where Id='" + textBox7.Text + "'", conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete success : " + textBox2.Text);
                        gridview();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        pictureBox1.Image = null;
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;

                    }
                    catch
                    {

                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please Enter the Employer Id and \n click the top of the data on below of table\n and Enter Pay amount ");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("Update salary set Month='" + dateTimePicker1.Text + "',Pdate='" + dateTimePicker2.Text + "',Amount='" + textBox3.Text + "',Tax='" + textBox4.Text + "',Pamount='" + textBox5.Text + "',Damount='" + textBox6.Text + "'where Id='" + textBox7.Text + "' ", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Payment success : " + textBox2.Text);
                    gridview();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    pictureBox1.Image = null;
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;

                }
                catch
                {

                }
            }
        }
    }
}
