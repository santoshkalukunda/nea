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
    public partial class Resister_Customer : Form
    {
        public Resister_Customer()
        {
            InitializeComponent();

            dateTimePicker1.Value = DateTime.Now;
            textBox1.Enabled = false;
           
        }
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM costm order by Id desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
           
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        public string imlocatin = "";
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
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

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }
        string obj = "";
        public string checkgender()
        {
            if (radioButton1.Checked == true)
            {
                obj = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                obj = radioButton2.Text;
            }
            return obj;
        }
       
        private void button3_Click(object sender, EventArgs e)
        {
          

            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "Select Connection Type" || comboBox2.Text == "Select Phase" || pictureBox1.Image == null)
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
                SqlCommand cmd = new SqlCommand("insert into costm (Name, Address, Gender, Phone, Jdate, Ctype, Phase, Picture) values('" + textBox2.Text + "','" + textBox3.Text + "','" + checkgender() + "','"+textBox4.Text+"','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "',@images)", conn);
                cmd.Parameters.Add(new SqlParameter("@images", images));
             


                try
                {
                    conn.Open();
                    int n=cmd.ExecuteNonQuery();
                    MessageBox.Show("Success to regester Customer:");
                    gridview();

                    textBox1.Clear();
                    textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); radioButton1.Checked = false; radioButton2.Checked = false;  comboBox1.Text = "Select Connection Type"; comboBox2.Text = "Select Phase"; pictureBox1.Image = null;
                    dateTimePicker1.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                }

            label11.Text = (dataGridView1.RowCount - 1).ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Resister_Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nEADataSet1.costm' table. You can move, or remove it, as needed.
            this.costmTableAdapter.Fill(this.nEADataSet1.costm);
            label11.Text = (dataGridView1.RowCount - 1).ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
    } }


