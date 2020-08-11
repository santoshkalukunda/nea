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
using System.Drawing.Printing;

namespace Nepal_Electricity_Authority
{
    public partial class Print_Bill : Form
    {
        //private Button pb = new Button();
        //private PrintDocument pd = new PrintDocument();
        public Print_Bill()
        {
            InitializeComponent();
            //dateTimePicker1.Enabled = false;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd  hh:mm";
            dateTimePicker1.Value = DateTime.Now;
            

            
            
        }
        int a;

        private void Print_Bill_Load(object sender, EventArgs e)
        {
            cid.Text = Bill_Pay.ci;
            name.Text = Bill_Pay.canm;
            manth.Text = Bill_Pay.mth;
            readunit.Text = Bill_Pay.ru;
            rate.Text = Bill_Pay.r;
            amount.Text = Bill_Pay.am;
            unit.Text = Bill_Pay.u;
            fine.Text = Bill_Pay.fn+"%";
            total.Text = Bill_Pay.t;
            rem.Text = Bill_Pay.rm;
            gtotal.Text = Bill_Pay.pd;
            transname.Text = Login.us;


            SqlConnection conn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("Select Max(Id) from bill", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                string val = dr[0].ToString();
                if(val=="")
                {
                    billno.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    
                    billno.Text = a.ToString();
                }
            }

            
        




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void button1_Click(object sender, EventArgs e)
        {
            
          printDocument1.Print();
            
        }

        private void printPreviewControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
