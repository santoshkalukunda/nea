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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter da = new SqlDataAdapter("Select * From Login where Username='" + textBox1.Text + "'And Password='" + textBox2.Text + "'", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            try
            {

                if (dt.Rows.Count >= 1)
                {
                    if (dt.Rows[0].ItemArray[3].ToString() == "Admin")
                    {
                        // MessageBox.Show("Login Success as: " + textBox1.Text);
                        conn.Close();
                        Admin_Panel ap = new Admin_Panel();
                        ap.Show();
                        this.Hide();

                    }
                    if (dt.Rows[0].ItemArray[3].ToString() == "User")
                    {
                        //MessageBox.Show("Login Success as: " + textBox1.Text);
                        conn.Close();
                        Nepal_Electricity_Authority_User us = new Nepal_Electricity_Authority_User();
                        us.Show();
                        this.Hide();

                    }
                    Login.us = textBox1.Text;
                    
                }
                else
                {
                    MessageBox.Show("The User Name and Password is incurrect", "Login fail", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }

        }
        public static string us;
        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
