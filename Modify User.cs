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


namespace Nepal_Electricity_Authority
{
    public partial class Modify_User : Form
    {
        public Modify_User()
        {
            InitializeComponent();
            gridview();
        }

        private void Modify_User_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'nEADataSet3.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter1.Fill(this.nEADataSet3.Login);
            button1.Hide();
            button2.Hide();
            textBox5.Hide();
           
            // TODO: This line of code loads data into the 'nEADataSet.Login' table. You can move, or remove it, as needed.
            this.loginTableAdapter.Fill(this.nEADataSet.Login);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM Login";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
                textBox4.PasswordChar = checkBox1.Checked ? '\0' : '*';
            }

            else
            {
                textBox3.PasswordChar = checkBox1.Checked ? '\0' : '*';
                textBox4.PasswordChar = checkBox1.Checked ? '\0' : '*';
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Username")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Username, Password, Type from Login where Username like'" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if (comboBox1.Text == "Type")
            {
                SqlConnection conn = new SqlConnection(str);
                SqlDataAdapter da = new SqlDataAdapter("select Username, Password, Type from Login where Type like'" + textBox1.Text + "%'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            if(textBox1.Text=="")
            {
                button1.Hide();
                button2.Hide();
                button4.Show();
            }
            else
            {
                button1.Show();
                button2.Show();
                button4.Hide();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "Select User Type")
            {
                MessageBox.Show("Please Enter the User Type, User name and Password", "The filed is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("The Password and conform Password is not match:", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
                textBox3.Clear();
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("update Login set Username='" + textBox2.Text + "', Password='" + textBox3.Text + "', Type='" + comboBox2.Text + "' where Id='" + textBox5.Text + "'", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The Success update :  " + textBox2.Text);
                    gridview();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox2.Text = "Select User Type";
                    button4.Show();
                    button2.Hide();
                    button1.Hide();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You want to delete the user:", "User delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "Select User Type")
                {
                    MessageBox.Show("Please double click on selected gridview", "The filed is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("delete from Login where Username='" + textBox2.Text + "'", conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Success to delete user : " + textBox2.Text);
                        gridview();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        comboBox2.Text = "Select User Type";
                        button4.Show();
                        button2.Hide();
                        button1.Hide();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "Select User Type")
            {
                MessageBox.Show("Please Enter the User Type, User name and Password", "The filed is Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("The Password and conform Password is not match:", "Eroor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
                textBox3.Clear();
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("insert into Login (Username, Password,Type) Values('" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "')", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The Success Register : " + textBox2.Text);
                    gridview();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    comboBox2.Text = "Select User Type";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                button1.Show();
                button2.Show();
                button4.Hide();
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString());
            }
        }
    }
}
