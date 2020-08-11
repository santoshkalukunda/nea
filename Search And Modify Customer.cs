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
using System.Drawing.Imaging;

namespace Nepal_Electricity_Authority
{
    public partial class Search_And_Modify_Customer : Form
    {
        public Search_And_Modify_Customer()
        {
            InitializeComponent();
            gridview();
            dateTimePicker1.Value = DateTime.Now;
            label9.Text =(dataGridView1.RowCount-1).ToString();
            
        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void Search_And_Modify_Customer_Load(object sender, EventArgs e)
        {

        }
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm order by Id desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                SqlConnection conn1 = new SqlConnection(str);

                //string sql ="select * from costm Where Id='" + textBox1.Text+"',";
                SqlDataAdapter da = new SqlDataAdapter("select * from costm where Id='" + textBox1.Text + "'", conn1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {

                    if (dt.Rows.Count >= 1)
                    {
                        textBox2.Text = dt.Rows[0].ItemArray[1].ToString();

                        textBox3.Text = dt.Rows[0].ItemArray[2].ToString();

                        comboBox3.Text = dt.Rows[0].ItemArray[3].ToString();
                        textBox4.Text = dt.Rows[0].ItemArray[4].ToString();
                        dateTimePicker1.Text = dt.Rows[0].ItemArray[5].ToString();
                        comboBox1.Text = dt.Rows[0].ItemArray[6].ToString();
                        comboBox2.Text = dt.Rows[0].ItemArray[7].ToString();
                        byte[] images = ((byte[])dt.Rows[0].ItemArray[8]);

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
                    else
                    {
                        MessageBox.Show("The information is not found", "Emty data", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("The Customer id is empty");
            }
            //SqlCommand cmd = new SqlCommand(sql, conn1);
            //SqlDataReader dr = cmd.ExecuteReader();  
            //dr.Read();
            //if (dr.HasRows)
            //{

            //    textBox2.Text = dr[1].ToString();
            //    textBox3.Text = dr[2].ToString();
            //    comboBox3.Text = dr[2].ToString();
            //    textBox4.Text = dr[4].ToString();
            //    dateTimePicker1.Text = dr[5].ToString();
            //    comboBox1.Text = dr[6].ToString();
            //    comboBox3.Text = dr[7].ToString();
            // 

            //}
            //else
            //{
            //    MessageBox.Show("This data is not Availabe...");
            //}
            //conn1.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Id like'" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            label9.Text =(dataGridView1.RowCount-1).ToString();



        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
               
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(str);
            //SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Address like'" + textBox3.Text + "%'", conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //label9.Text = (dataGridView1.RowCount - 1).ToString();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(str);
            //SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Phone like'" + textBox3.Text + "%'", conn);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //label9.Text = (dataGridView1.RowCount-1).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public string imlocation;
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "Select Connection Type" || comboBox2.Text == "Select Phase" || pictureBox1.Image == null)
            {
                MessageBox.Show("Plese Search the requirment");
            }
            else
            {
                //byte[] images = null;
                //FileStream fs = new FileStream(imlocation, FileMode.Open, FileAccess.ReadWrite);
                //BinaryReader br = new BinaryReader(fs);
                //images = br.ReadBytes((int)fs.Length);
                MemoryStream ms = new MemoryStream();

                pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                byte[] images = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(images, 0, images.Length);

                SqlConnection conn = new SqlConnection(str);
                conn.Open();

                SqlCommand cmd = new SqlCommand("update costm set Name='" + textBox2.Text + "', Address='" + textBox3.Text + "',Gender='" + comboBox3.Text + "',Phone='" + textBox4.Text + "',Jdate='" + dateTimePicker1.Text + "',Ctype='" + comboBox1.Text + "', Phase='" + comboBox2.Text + "',Picture=@images where Id='" + textBox1.Text + "'", conn);
                SqlCommand cd = new SqlCommand("Update bill set Name='" + textBox2.Text + "' where Cid='" + textBox1.Text + "'", conn);

                cmd.Parameters.Add(new SqlParameter("@images", images));
                try
                {
                    cmd.ExecuteNonQuery();
                    cd.ExecuteNonQuery();
                    MessageBox.Show("Success to update... : "+textBox2.Text);
                    gridview();
                    textBox1.Clear();
                    textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); comboBox3.Text = "Select Gender"; comboBox1.Text = "Select Connection Type"; comboBox2.Text = "Select Phase"; pictureBox1.Image = null;
                    dateTimePicker1.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();

            di.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png|GIF Files (*.gif)|*.gif|Any File (*.*)|*.*";
            di.Title = "Choose Your Image from PC";
            if (di.ShowDialog() == DialogResult.OK)
            {
                di.InitialDirectory = @"C:\Users\Public\Pictures";
                imlocation = di.FileName.ToString();
                pictureBox1.ImageLocation = imlocation;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to delete the Customer:", "Customer delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "Select Connection Type" || comboBox2.Text == "Select Phase" || pictureBox1.Image == null)
                {
                    MessageBox.Show("Plese Search the requirment");
                }
                else
                {

                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("delete from costm where Id='" + textBox1.Text + "'", conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success to Delete Customer:");
                        gridview();

                        textBox1.Clear();
                        textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); comboBox3.Text = "Select Gender"; comboBox1.Text = "Select Connection Type"; comboBox2.Text = "Select Phase"; pictureBox1.Image = null;
                        label9.Text = (dataGridView1.RowCount - 1).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if(comboBox4.Text=="Id")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Id like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
            if (comboBox4.Text == "Name")
            {
                SqlConnection conn = new SqlConnection(str);

                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Name like'" + textBox7.Text + "%'order by Id desc ", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
            if (comboBox4.Text == "Address")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Address like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
                   }
            if(comboBox4.Text=="Gender")
            {

            }
            if(comboBox4.Text=="Phone")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Phone like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
            if(comboBox4.Text=="Join Date")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Jdate like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
            if(comboBox4.Text=="Connection Type")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Ctype like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
            if (comboBox4.Text == "Phase")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Id, Name, Address, Gender, Phone, Jdate, Ctype, Phase from costm where Phase like'" +textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
