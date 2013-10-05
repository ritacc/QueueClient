namespace QM.Client.DeviceAdmin
{
    partial class frmZPEdit
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
            this.label9 = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCanncel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHostaddr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDevicemodel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRowNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(222, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 12);
            this.label9.TabIndex = 33;
            this.label9.Text = "*";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(112, 22);
            this.txtTypeName.MaxLength = 5;
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.ReadOnly = true;
            this.txtTypeName.Size = new System.Drawing.Size(98, 21);
            this.txtTypeName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "柜台号码：";
            // 
            // btnCanncel
            // 
            this.btnCanncel.Location = new System.Drawing.Point(182, 220);
            this.btnCanncel.Name = "btnCanncel";
            this.btnCanncel.Size = new System.Drawing.Size(51, 23);
            this.btnCanncel.TabIndex = 27;
            this.btnCanncel.Text = "取消";
            this.btnCanncel.UseVisualStyleBackColor = true;
            this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(110, 220);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(47, 23);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(112, 55);
            this.txtAddress.MaxLength = 10;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(98, 21);
            this.txtAddress.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "设备地址：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(286, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 28;
            this.label5.Text = "排队机的IP地址";
            // 
            // txtHostaddr
            // 
            this.txtHostaddr.Location = new System.Drawing.Point(112, 115);
            this.txtHostaddr.Name = "txtHostaddr";
            this.txtHostaddr.Size = new System.Drawing.Size(164, 21);
            this.txtHostaddr.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "设备主机地址：";
            // 
            // txtDevicemodel
            // 
            this.txtDevicemodel.Location = new System.Drawing.Point(112, 88);
            this.txtDevicemodel.Name = "txtDevicemodel";
            this.txtDevicemodel.Size = new System.Drawing.Size(164, 21);
            this.txtDevicemodel.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "设备型号：";
            // 
            // txtColNumber
            // 
            this.txtColNumber.Location = new System.Drawing.Point(112, 148);
            this.txtColNumber.MaxLength = 10;
            this.txtColNumber.Name = "txtColNumber";
            this.txtColNumber.Size = new System.Drawing.Size(98, 21);
            this.txtColNumber.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 35;
            this.label1.Text = "每行：";
            // 
            // txtRowNumber
            // 
            this.txtRowNumber.Location = new System.Drawing.Point(112, 175);
            this.txtRowNumber.MaxLength = 10;
            this.txtRowNumber.Name = "txtRowNumber";
            this.txtRowNumber.Size = new System.Drawing.Size(98, 21);
            this.txtRowNumber.TabIndex = 36;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 37;
            this.label2.Text = "行数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 38;
            this.label8.Text = "字";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(239, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(11, 12);
            this.label10.TabIndex = 39;
            this.label10.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(216, 178);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(11, 12);
            this.label11.TabIndex = 40;
            this.label11.Text = "*";
            // 
            // frmZPEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 256);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRowNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtColNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmZPEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "主屏管理";
            this.Load += new System.EventHandler(this.frmZPEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCanncel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHostaddr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDevicemodel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtColNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRowNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}