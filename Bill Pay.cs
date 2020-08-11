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
    public partial class Bill_Pay : Form
    {
        public Bill_Pay()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy/MM";
            dateTimePicker3.Value = DateTime.Now;
            gridview();

            name.Enabled = false;
            tm.Enabled = false;
            amount.Enabled = false;
            unit.Enabled = false;
            rmk.Enabled = false;
            nreadunit.Hide();
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button8.Hide();
            button9.Hide();
            textBox2.Hide();
            textBox2.Enabled = false;
            fnd.Enabled = false;
            rate.Enabled = false;





        }

        private void Bill_Pay_Load(object sender, EventArgs e)
        {
            label9.Text = (dataGridView1.RowCount - 1).ToString();
            textBox2.Clear();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }
        public void gridview()
        {

            SqlConnection conn1 = new SqlConnection(str);
            string sql = "SELECT * FROM bill order by Id desc";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn1);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();


        }
        public string str = ConfigurationManager.ConnectionStrings["connection"].ToString();
        private void button1_Click(object sender, EventArgs e)
        {



            if (cid.Text == "" || name.Text == "")
            {
                MessageBox.Show("The Customer is not Registed");
                cid.Clear();
            }
            else
            {
                readunit.Text = (0).ToString();
                unit.Text = 0.ToString();
                amount.Text = 0.ToString();
                rmk.Text = 0.ToString();
                fnd.Text = 0.ToString();
                tm.Text = 0.ToString();

                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("insert into bill (Cid, Name, Yearmonth, Rdate, Runit, Unit, Amount, Remark, Finediscount, Totalamount) values('" + cid.Text + "','" + name.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker1.Text + "','" + readunit.Text + "','" + unit.Text + "','" + amount.Text + "','" + rmk.Text + "','" + fnd.Text + "','" + tm.Text + "')", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Success to regester Customer:");
                    gridview();
                    readunit.Clear();
                    unit.Clear();
                    amount.Clear();
                    rmk.Clear();
                    fnd.Clear();
                    tm.Clear();
                    cid.Clear();
                    name.Clear();
                }
                catch (Exception ex)
                {
                     MessageBox.Show(ex.ToString());
                }
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
        }

        private void unit_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cid_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(str);
            SqlDataAdapter das = new SqlDataAdapter("select * from bill where Cid like'" + cid.Text + "%'order by Id desc ", conn);
            DataTable dtt = new DataTable();
            das.Fill(dtt);
            dataGridView1.DataSource = dtt;

            label9.Text = (dataGridView1.RowCount - 1).ToString();
            if (cid.Text != "")
            {
                SqlConnection conn1 = new SqlConnection(str);

                SqlDataAdapter da = new SqlDataAdapter("select * from costm where Id='" + cid.Text + "'", conn1);
                DataTable dt = new DataTable();
                da.Fill(dt);
                try
                {

                    if (dt.Rows.Count >= 1)
                    {
                        name.Text = dt.Rows[0].ItemArray[1].ToString();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (cid.Text == "")
            {
                name.Clear();
            }
            if(dataGridView1.RowCount>1)
            {
                button1.Hide();
            }
            else
            {
                button1.Show();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (cid.Text == "")
            {
                MessageBox.Show("Please Enter the customer Id");
            }
            else
            {
                if (label9.Text == "0")
                {
                    MessageBox.Show("The Result is not found");
                }
                else {
                    if (MessageBox.Show("You want to delete all whose id =" + cid.Text + " of Customer billing:", "User delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand("delete from bill where Cid='" + cid.Text + "'", conn);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Success to Delete Customer:");
                            gridview();
                            readunit.Clear();
                            unit.Clear();
                            amount.Clear();
                            rmk.Clear();
                            fnd.Clear();
                            tm.Clear();
                            cid.Clear();
                            name.Clear();
                            paid.Clear();
                            label9.Text = (dataGridView1.RowCount - 1).ToString();


                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }

                }
            }
        }

        private void name_Click(object sender, EventArgs e)
        {

        }

        private void name_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {


            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cid.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                name.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                dateTimePicker3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                readunit.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                unit.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                amount.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                rmk.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                fnd.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                tm.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                //dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[].Value.ToString();
                paid.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                rate.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                dateTimePicker2.Text = dataGridView1.SelectedRows[0].Cells[13].Value.ToString();
            }
            catch (Exception)
            {
                // MessageBox.Show(ex.ToString());
            }
            if (readunit.Text != "")
            {
                button1.Hide();
                button2.Show();
                button3.Hide();
                button4.Show();
               // button5.Show();
                button6.Hide();
                button8.Show();
                nreadunit.Hide();
                button9.Show();
                s = rmk.Text;
            }
            textBox2.Hide();
            textBox2.Clear();
            fnd.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cid.Text == "" || name.Text == "" || readunit.Text == "")
            {
                MessageBox.Show("Please Enter Id Double click on right side of Data table ");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("update bill set Rdate='" + dateTimePicker1.Text + "', Runit='" + nreadunit.Text + "',Unit='" + unit.Text + "',Amount='" + amount.Text + "', Remark='" + textBox2.Text + "',Finediscount='" + fnd.Text + "',Totalamount='" + tm.Text + "',Payment='" + paid.Text + "',Rate='" + rate.Text + "',Yearmonth='" + dateTimePicker3.Text + "' where Cid='" + cid.Text + "' and Id='"+textBox1.Text + "'", conn);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The Success update of: " + name.Text);
                    gridview();
                    readunit.Clear();
                    unit.Clear();
                    amount.Clear();
                    rmk.Clear();
                    fnd.Clear();
                    tm.Clear();
                    cid.Clear();
                    name.Clear();
                    paid.Clear();
                    rate.Clear();
                    textBox1.Clear();
                    name.Clear();
                    cid.Clear();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (paid.Text != "")
            {
                if (tm.Text != "")
                {
                    rmk.Text = (Convert.ToDouble(tm.Text) - Convert.ToDouble(paid.Text)).ToString();
                }
              
            }
            
        }

        private void nreadunit_TextChanged(object sender, EventArgs e)
        {

            if (nreadunit.Text != "")

            {

                if (readunit.Text != "")
                {
                    unit.Text = (Convert.ToDouble(nreadunit.Text) - Convert.ToDouble(readunit.Text)).ToString();
                }
                else
                {
                    unit.Text = unit.Text;
                }

            }
            else
            {
                unit.Clear();
            }
        }

        private void rate_TextChanged(object sender, EventArgs e)
        {
            if (rate.Text != "")
            {
                if (unit.Text != "")
                {
                    amount.Text = (Convert.ToDouble(unit.Text) * Convert.ToDouble(rate.Text)).ToString();
                }
                else
                {
                    MessageBox.Show("Please Enter the Reading Unit");
                    rate.Clear();
                }

            }
            else
            {
                amount.Clear();

            }
        }
        private void amount_TextChanged(object sender, EventArgs e)
        {
            if (amount.Text != "")
            {
                if (rmk.Text == "")
                {
                   
                    rmk.Text = (Convert.ToDouble(amount.Text) + Convert.ToDouble(s)).ToString();
                    tm.Text =(Convert.ToDouble(rmk.Text)).ToString();
                }
                else
                {
                    rmk.Text = amount.Text;
                    tm.Text =(Convert.ToDouble( amount.Text)).ToString();

                
                }
            }
            else
            {
                tm.Clear();
                textBox2.Clear();
                rmk.Clear();
            }
        }

        private void tm_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void fnd_TextChanged(object sender, EventArgs e)
        {
            //tm.Clear();
            if (fnd.Text != "")
            {


                if (rmk.Text != "" || rmk.Text != "0")
                {
                    //tm.Clear();
                    tm.Text = ((Convert.ToDouble(rmk.Text) + (Convert.ToDouble(amount.Text) * Convert.ToDouble(fnd.Text)) / 100)).ToString();
                }
                else
                {
                    tm.Text = ((Convert.ToDouble(amount.Text) + (Convert.ToDouble(amount.Text) * Convert.ToDouble(fnd.Text)) / 100)).ToString();

                }
            }
            else
            {
                tm.Text = rmk.Text;
            }

        }

        private void nreadunit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void readunit_TextChanged(object sender, EventArgs e)
        {

        }

        private void readunit_KeyPress(object sender, KeyPressEventArgs e)
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

        private void rate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void paid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (rmk.Text != "")
            {
                s = rmk.Text;
            }
            else
            {
                s = 0.ToString();
            }
           if (readunit.Text == "")
            {
                MessageBox.Show("Please Enter the Id And select top most data of those Customer Id On right side");
            }
            else
            {
                fnd.Clear();
                //button5.Show();
                button4.Hide();
                button3.Show();
                button2.Hide();
                nreadunit.Show();
               // textBox1.Show();
                button8.Show();
                button9.Hide();
                unit.Clear();
                //fnd.Clear();
                tm.Clear();
                paid.Clear();
                nreadunit.Clear();
                rate.Clear();
                textBox2.Clear();
                rmk.Clear();
               
                
                amount.Clear();
               //textBox2.Show();
                fnd.Enabled = false;
                rate.Enabled = true;
            }


        }
        public string s;

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void fnd_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cid_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_TextChanged_1(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            if (cid.Text == "" || readunit.Text == "")
            {
                MessageBox.Show("Please Enter the customer Id");
            }
            else
            {
                if (label9.Text == "0")
                {
                    MessageBox.Show("The Result is not found");
                }
                else
                {
                    if (MessageBox.Show("You want to delete the Customer billing:", "User delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(str);
                        SqlCommand cmd = new SqlCommand("delete from bill where Cid='" + cid.Text + "'and Rdate='" + dateTimePicker1.Text + "'and Id='" + textBox1.Text + "'", conn);
                        try
                        {
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Success to Delete Customer:");
                            gridview();
                            readunit.Clear();
                            unit.Clear();
                            amount.Clear();
                            rmk.Clear();
                            fnd.Clear();
                            tm.Clear();
                            cid.Clear();
                            name.Clear();
                            paid.Clear();
                            label9.Text = (dataGridView1.RowCount - 1).ToString();


                        }
                        catch (Exception)
                        {
                            //MessageBox.Show(ex.ToString());
                        }
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cid.Text == "" || name.Text == "" || readunit.Text == ""||rate.Text=="")
            {
                MessageBox.Show("Please Enter the New Reading Unit");
            }
            else
            {
                SqlConnection conn = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("insert into bill (Cid, Name, Yearmonth, Rdate, Runit, Unit, Rate, Remark, Amount, TotalAmount) values('" + cid.Text + "','" + name.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker1.Text + "','" + nreadunit.Text + "','" + unit.Text + "','"+rate.Text+"','"+rmk.Text+"','"+amount.Text+"','"+tm.Text+"')", conn);
                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    textBox2.Clear();
                    MessageBox.Show("Success to regester Customer:");

                    gridview();
                    readunit.Clear();
                    name.Clear();
                    cid.Clear();
                    tm.Clear();
                    amount.Clear();
                    unit.Clear();
                    rate.Clear();
                    fnd.Clear();
                    paid.Clear();
                    rmk.Clear();
                   

                    readunit.Clear();
                    nreadunit.Hide();
                    textBox1.Hide();
                    button2.Hide();
                    button3.Hide();
                    button4.Hide();
                    button5.Hide();
                    button1.Show();
                    button6.Show();
                    button8.Hide();
                    button9.Hide();
                    textBox2.Hide();




                }
                catch (Exception)
                {
                    // MessageBox.Show(ex.ToString());
                }
                label9.Text = (dataGridView1.RowCount - 1).ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "yyyy/MM";
            dateTimePicker3.Value = DateTime.Now;
            gridview();
            label9.Text = (dataGridView1.RowCount - 1).ToString();
            name.Clear();
            cid.Clear();
            tm.Clear();
            amount.Clear();
            unit.Clear();
            rate.Clear();
            fnd.Clear();
            paid.Clear();
            rmk.Clear();
            textBox1.Clear();
            readunit.Clear();
            nreadunit.Hide();
            textBox1.Hide();
            button2.Hide();
            button3.Hide();
            button4.Hide();
            button5.Hide();
            button1.Show();
            button6.Show();
            button8.Hide();
            button9.Hide();
            textBox2.Hide();
            textBox2.Clear();
        }
        public static string blno;
        public static string ci;
        public static string canm;
        public static string mth;
        public static string ru;
        public static string u;
        public static string r;
        public static string am;
        public static string fn;
        public static string rm;
        public static string t;
        public static string pd;
        private void button9_Click(object sender, EventArgs e)
        {
            if(rate.Text=="")
            {
                MessageBox.Show("Please Enter the rate");
            }
            else
            {
                if (paid.Text == "")
                {
                    MessageBox.Show("Please Enter Amount in Paid:");
                }
                else
                {
                    SqlConnection conn = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("update bill set Yearmonth='" + dateTimePicker3.Text + "', Rdate='" + dateTimePicker1.Text + "', Runit='" + readunit.Text + "',Unit='" + unit.Text + "',Amount='" + amount.Text + "', Remark='" + rmk.Text + "',Finediscount='" + fnd.Text + "',Totalamount='" + tm.Text + "',Payment='" + paid.Text + "',Rate='" + rate.Text + "',Pdate='" + dateTimePicker2.Text + "' where Cid='" + cid.Text + "' and Runit='"+readunit.Text+"' ", conn);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("The Success Paid: " + name.Text);

                        gridview();
                        // Bill_Pay.blno =dataGridView1.SelectedRows[0].Cells[0].Value.ToString(); ;
                        Bill_Pay.ci = cid.Text;
                        Bill_Pay.canm = name.Text;
                        Bill_Pay.mth = dateTimePicker3.Text;
                        Bill_Pay.ru = readunit.Text;
                        Bill_Pay.u = unit.Text;
                        Bill_Pay.r = rate.Text;
                        Bill_Pay.am = amount.Text;
                        Bill_Pay.fn = fnd.Text;
                        Bill_Pay.rm = rmk.Text;
                        Bill_Pay.t = tm.Text;
                        Bill_Pay.pd = paid.Text;

                        Print_Bill pr = new Print_Bill();
                        pr.Show();


                        readunit.Clear();
                        unit.Clear();
                        amount.Clear();
                        rmk.Clear();
                        fnd.Clear();
                        tm.Clear();
                        cid.Clear();
                        name.Clear();
                        paid.Clear();
                        rate.Clear();
                        textBox1.Clear();
                      
                      





                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        private void rmk_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            
                
        }
    }
}
