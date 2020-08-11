using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nepal_Electricity_Authority
{
    public partial class Nepal_Electricity_Authority_User : Form
    {
        private int childFormNumber = 0;

        public Nepal_Electricity_Authority_User()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void registerNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resister_Customer rc = new Resister_Customer();
            rc.MdiParent = this;
            rc.Show();
        }

        private void searchAndModifyCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search_And_Modify_Customer sc = new Search_And_Modify_Customer();
            sc.MdiParent = this;
            sc.Show();

        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bill_Pay bp = new Bill_Pay();
            bp.MdiParent = this;
            bp.Show();
        }

        private void searchBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Billing_Search bs = new Billing_Search();
            bs.MdiParent = this;
            bs.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void searchBillingToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Billing_Search bs = new Billing_Search();
            bs.MdiParent = this;
            bs.Show();
        }

        private void Nepal_Electricity_Authority_User_Load(object sender, EventArgs e)
        {
            Print_Bill pb = new Print_Bill();
            pb.MdiParent = this;
            this.BackgroundImage = Properties.Resources._111;
        }

        private void Nepal_Electricity_Authority_User_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void logoutToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Show();
            this.Hide();
        }
    }
}
