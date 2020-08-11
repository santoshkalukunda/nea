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
    public partial class Register_Employer : Form
    {
        public Register_Employer()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            


        }

        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM emp order by Id desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();


        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void Register_Employer_Load(object sender, EventArgs e)
        {
            gridview();
            // TODO: This line of code loads data into the 'nEADataSet2.emp' table. You can move, or remove it, as needed.
            //this.empTableAdapter.Fill(this.nEADataSet2.emp);
            label11.Text = (dataGridView1.RowCount - 1).ToString();
            textBox8.Hide();
            button5.Hide();
            button6.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string imlocatin = "";
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog di = new OpenFileDialog();

            di.Filter = "JPG Files(*.jpg)|*.jpg| PNG Files(*.png)|*.png|GIF Files (*.gif)|*.gif|Any File (*.*)|*.*";
            di.Title = "Choose Your Image from PC";
            if (di.ShowDialog() == DialogResult.OK)
            {
                di.InitialDirectory = @"C:\Users\Public\Pictures";
                imlocatin = di.FileName.ToString();
                pictureBox1.ImageLocation = imlocatin;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || comboBox1.Text == "Select Gender" || textBox5.Text == "" || pictureBox1.Image == null)
            {
                MessageBox.Show("Plese Fill the all requirment");
            }
            else
            {
                byte[] images = null;
                FileStream st = new FileStream(imlocatin, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(st);
                images = br.ReadBytes((int)st.Length);

                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("insert into emp (Name, Address, Gender, Phone, Email, Qulification, Post, DOB,Jdate,Photo) values('"+textBox1.Text+"','" + textBox2.Text + "','"+comboBox1.Text+"','" + textBox3.Text + "','" + textBox4.Text + "','"+textBox5.Text+"','"+textBox6.Text+"','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "',@images)", conn);
                cmd.Parameters.Add(new SqlParameter("@images", images));



                try
                {
                    conn.Open();
                    int n = cmd.ExecuteNonQuery();
                    MessageBox.Show("Success to Regester Emplyer: "+textBox1.Text);
                    gridview();

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox1.Text = "Select Gender";
                    pictureBox1.Image = null;
                    label11.Text = (dataGridView1.RowCount - 1).ToString();
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


            }
;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "Id")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Id like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Name")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Name like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Address")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Address like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Gender")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Gender like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Phone")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Phone like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Email")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Email like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Qualification")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Qulification like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Post")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Post like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Date Of Brith")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where DOB like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox2.Text == "Join")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select * from emp where Jdate like'" + textBox7.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            label11.Text = (dataGridView1.RowCount - 1).ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button5.Show();
            button6.Show();
            button3.Hide();


            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("select * from emp where Name='" + textBox1.Text + "'and Phone='" + textBox3.Text + "'",conn);
            DataTable dt = new DataTable();
            da.Fill(dt);

            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                textBox6.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
               dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                textBox8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                
                
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
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("select * from emp where Name='" + textBox1.Text + "'and Phone='" + textBox3.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {
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
            catch(Exception)
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "Select Gender" || textBox1.Text == ""||textBox5.Text==""||textBox6.Text=="" || pictureBox1.Image == null)
            {
                MessageBox.Show("Plese fill all Information or \n Select the requirment in below Table Of Data");
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

                SqlCommand cmd = new SqlCommand("update emp set Name='" + textBox1.Text + "', Address='" + textBox2.Text + "',Gender='" + comboBox1.Text + "',Phone='" + textBox3.Text + "',Jdate='" + dateTimePicker2.Text + "',Email='" + textBox4.Text + "', Qulification='" +textBox5.Text + "',Post='"+textBox6.Text+"',DOB='"+dateTimePicker1.Text+"',Photo=@images where Id='" + textBox8.Text + "'", conn);
                cmd.Parameters.Add(new SqlParameter("@images", images));
                SqlCommand cd = new SqlCommand("Update salary set Name='" + textBox1.Text + "' where Eid='" + textBox8.Text + "'", conn);

               
                try
                {
                    cmd.ExecuteNonQuery();
                    cd.ExecuteNonQuery();
                    MessageBox.Show("Success to update... "+textBox1.Text);
                    gridview();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    comboBox1.Text = "Select Gender";
                    pictureBox1.Image = null;
                    button3.Show();
                    button5.Hide();
                    button6.Hide();
                    dateTimePicker1.Value = DateTime.Now;
                    dateTimePicker2.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to delete the Employer:", "Employer delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox6.Text == "" || comboBox1.Text == "Select Gender" || textBox5.Text == "" || pictureBox1.Image == null)
                {
                    MessageBox.Show("Plese Search the requirment");
                }
                else
                {

                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("delete from emp where Id='" + textBox8.Text + "'", conn);
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success to Delete Customer:");
                        gridview();
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        comboBox1.Text = "Select Gender";
                        pictureBox1.Image = null;
                        label11.Text = (dataGridView1.RowCount - 1).ToString();
                        dateTimePicker1.Value = DateTime.Now;
                        dateTimePicker2.Value = DateTime.Now;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(str);
            //SqlDataAdapter das = new SqlDataAdapter("select * from salary where Name like'" + textBox2.Text + "%'order by Id desc ", conn);
            //DataTable dtt = new DataTable();
            //das.Fill(dtt);
            //dataGridView1.DataSource = dtt;
        }
    }
}
