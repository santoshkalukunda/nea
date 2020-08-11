namespace Nepal_Electricity_Authority
{
    partial class Print_Bill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Print_Bill));
            this.label1 = new System.Windows.Forms.Label();
            this.billno = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cid = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.manth = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.readunit = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.unit = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.rate = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.amount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.fine = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.remainig = new System.Windows.Forms.Label();
            this.rem = new System.Windows.Forms.Label();
            this.transname = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.gtotal = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 153);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bill No. :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // billno
            // 
            this.billno.AutoSize = true;
            this.billno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billno.Location = new System.Drawing.Point(70, 153);
            this.billno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.billno.Name = "billno";
            this.billno.Size = new System.Drawing.Size(0, 17);
            this.billno.TabIndex = 2;
            this.billno.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(275, 151);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trans Date :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(367, 148);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 23);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // cid
            // 
            this.cid.AutoSize = true;
            this.cid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cid.Location = new System.Drawing.Point(106, 182);
            this.cid.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cid.Name = "cid";
            this.cid.Size = new System.Drawing.Size(52, 17);
            this.cid.TabIndex = 6;
            this.cid.Text = "Bill No.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 182);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "Customer ID. :";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(140, 212);
            this.name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(52, 17);
            this.name.TabIndex = 8;
            this.name.Text = "Bill No.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 212);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Customer Name. :";
            // 
            // manth
            // 
            this.manth.AutoSize = true;
            this.manth.Location = new System.Drawing.Point(12, 280);
            this.manth.Name = "manth";
            this.manth.Size = new System.Drawing.Size(52, 17);
            this.manth.TabIndex = 10;
            this.manth.Text = "Bill No.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 251);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Month";
            // 
            // readunit
            // 
            this.readunit.AutoSize = true;
            this.readunit.Location = new System.Drawing.Point(80, 280);
            this.readunit.Name = "readunit";
            this.readunit.Size = new System.Drawing.Size(52, 17);
            this.readunit.TabIndex = 12;
            this.readunit.Text = "Bill No.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(74, 251);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "ReadingUnit";
            // 
            // unit
            // 
            this.unit.AutoSize = true;
            this.unit.Location = new System.Drawing.Point(177, 280);
            this.unit.Name = "unit";
            this.unit.Size = new System.Drawing.Size(52, 17);
            this.unit.TabIndex = 14;
            this.unit.Text = "Bill No.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(177, 251);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 17);
            this.label13.TabIndex = 13;
            this.label13.Text = "Unit";
            // 
            // rate
            // 
            this.rate.AutoSize = true;
            this.rate.Location = new System.Drawing.Point(236, 280);
            this.rate.Name = "rate";
            this.rate.Size = new System.Drawing.Size(38, 17);
            this.rate.TabIndex = 16;
            this.rate.Text = "Rate";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(235, 251);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 17);
            this.label15.TabIndex = 15;
            this.label15.Text = "Rate";
            // 
            // amount
            // 
            this.amount.AutoSize = true;
            this.amount.Location = new System.Drawing.Point(282, 280);
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(56, 17);
            this.amount.TabIndex = 18;
            this.amount.Text = "Amount";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(281, 251);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 17);
            this.label17.TabIndex = 17;
            this.label17.Text = "Amount";
            // 
            // fine
            // 
            this.fine.AutoSize = true;
            this.fine.Location = new System.Drawing.Point(347, 280);
            this.fine.Name = "fine";
            this.fine.Size = new System.Drawing.Size(56, 17);
            this.fine.TabIndex = 20;
            this.fine.Text = "Amount";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(349, 251);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(57, 17);
            this.label19.TabIndex = 19;
            this.label19.Text = "Fine(%)";
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(489, 280);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(56, 17);
            this.total.TabIndex = 22;
            this.total.Text = "Amount";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(487, 251);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 17);
            this.label21.TabIndex = 21;
            this.label21.Text = "Total";
            // 
            // remainig
            // 
            this.remainig.AutoSize = true;
            this.remainig.Location = new System.Drawing.Point(406, 251);
            this.remainig.Name = "remainig";
            this.remainig.Size = new System.Drawing.Size(67, 17);
            this.remainig.TabIndex = 24;
            this.remainig.Text = "Remainig";
            // 
            // rem
            // 
            this.rem.Location = new System.Drawing.Point(408, 280);
            this.rem.Name = "rem";
            this.rem.Size = new System.Drawing.Size(49, 17);
            this.rem.TabIndex = 23;
            this.rem.Text = "Remain";
            // 
            // transname
            // 
            this.transname.AutoSize = true;
            this.transname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transname.Location = new System.Drawing.Point(89, 338);
            this.transname.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.transname.Name = "transname";
            this.transname.Size = new System.Drawing.Size(52, 17);
            this.transname.TabIndex = 26;
            this.transname.Text = "Bill No.";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(9, 338);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 17);
            this.label25.TabIndex = 25;
            this.label25.Text = "Trans. By :";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(80, 371);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(124, 17);
            this.label26.TabIndex = 27;
            this.label26.Text = ".............................";
            // 
            // gtotal
            // 
            this.gtotal.AutoSize = true;
            this.gtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtotal.Location = new System.Drawing.Point(462, 338);
            this.gtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.gtotal.Name = "gtotal";
            this.gtotal.Size = new System.Drawing.Size(60, 17);
            this.gtotal.TabIndex = 29;
            this.gtotal.Text = "Bill No.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(315, 338);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(142, 17);
            this.label28.TabIndex = 28;
            this.label28.Text = "Grand Total Paid :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = global::Nepal_Electricity_Authority.Properties.Resources.banner_blue;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(558, 140);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(483, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 30;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Print_Bill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 409);
            this.Controls.Add(this.gtotal);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.transname);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.remainig);
            this.Controls.Add(this.rem);
            this.Controls.Add(this.total);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.fine);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.rate);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.unit);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.readunit);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.manth);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.billno);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Print_Bill";
            this.Text = "Print_Bill";
            this.Load += new System.EventHandler(this.Print_Bill_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label billno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label cid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label manth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label readunit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label unit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label rate;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label amount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label fine;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label remainig;
        private System.Windows.Forms.Label rem;
        private System.Windows.Forms.Label transname;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label gtotal;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}