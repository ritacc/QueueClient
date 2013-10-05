namespace QM.Client.DeviceAdmin
{
    partial class frmDeviceEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWindowno = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtWindowtype = new System.Windows.Forms.ComboBox();
            this.txtDevicemodel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtHostaddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCanncel = new System.Windows.Forms.Button();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtColNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnTP = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.pnTP.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "柜台号码：";
            // 
            // txtWindowno
            // 
            this.txtWindowno.Location = new System.Drawing.Point(118, 44);
            this.txtWindowno.MaxLength = 5;
            this.txtWindowno.Name = "txtWindowno";
            this.txtWindowno.Size = new System.Drawing.Size(98, 21);
            this.txtWindowno.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "柜台类型：";
            // 
            // txtWindowtype
            // 
            this.txtWindowtype.FormattingEnabled = true;
            this.txtWindowtype.Items.AddRange(new object[] {
            "高柜",
            "低柜"});
            this.txtWindowtype.Location = new System.Drawing.Point(118, 101);
            this.txtWindowtype.Name = "txtWindowtype";
            this.txtWindowtype.Size = new System.Drawing.Size(98, 20);
            this.txtWindowtype.TabIndex = 3;
            // 
            // txtDevicemodel
            // 
            this.txtDevicemodel.Location = new System.Drawing.Point(118, 132);
            this.txtDevicemodel.Name = "txtDevicemodel";
            this.txtDevicemodel.Size = new System.Drawing.Size(164, 21);
            this.txtDevicemodel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "设备型号：";
            // 
            // txtHostaddr
            // 
            this.txtHostaddr.Location = new System.Drawing.Point(118, 159);
            this.txtHostaddr.Name = "txtHostaddr";
            this.txtHostaddr.Size = new System.Drawing.Size(164, 21);
            this.txtHostaddr.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "设备主机地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "排队机的IP地址";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(118, 71);
            this.txtAddress.MaxLength = 10;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(98, 21);
            this.txtAddress.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "设备地址：";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(111, 254);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCanncel
            // 
            this.btnCanncel.Location = new System.Drawing.Point(183, 254);
            this.btnCanncel.Name = "btnCanncel";
            this.btnCanncel.Size = new System.Drawing.Size(51, 23);
            this.btnCanncel.TabIndex = 7;
            this.btnCanncel.Text = "取消";
            this.btnCanncel.UseVisualStyleBackColor = true;
            this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(118, 12);
            this.txtTypeName.MaxLength = 5;
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(98, 21);
            this.txtTypeName.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "设备名称：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(223, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(11, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(223, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 41;
            this.label10.Text = "字";
            // 
            // txtColNumber
            // 
            this.txtColNumber.Location = new System.Drawing.Point(56, 4);
            this.txtColNumber.MaxLength = 10;
            this.txtColNumber.Name = "txtColNumber";
            this.txtColNumber.Size = new System.Drawing.Size(98, 21);
            this.txtColNumber.TabIndex = 39;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "每行：";
            // 
            // pnTP
            // 
            this.pnTP.Controls.Add(this.label12);
            this.pnTP.Controls.Add(this.txtColNumber);
            this.pnTP.Controls.Add(this.label10);
            this.pnTP.Controls.Add(this.label11);
            this.pnTP.Location = new System.Drawing.Point(60, 186);
            this.pnTP.Name = "pnTP";
            this.pnTP.Size = new System.Drawing.Size(200, 34);
            this.pnTP.TabIndex = 42;
            this.pnTP.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(176, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(11, 12);
            this.label12.TabIndex = 43;
            this.label12.Text = "*";
            // 
            // frmDeviceEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 289);
            this.Controls.Add(this.pnTP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCanncel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtHostaddr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDevicemodel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWindowtype);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtWindowno);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeviceEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条屏管理";
            this.Load += new System.EventHandler(this.frmTPEdit_Load);
            this.pnTP.ResumeLayout(false);
            this.pnTP.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWindowno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox txtWindowtype;
        private System.Windows.Forms.TextBox txtDevicemodel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtHostaddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCanncel;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtColNumber;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnTP;
        private System.Windows.Forms.Label label12;
    }
}