namespace MSS
{
	partial class frmMaintainEdit
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintainEdit));
			this.CB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SS = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.MC = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.GHS = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.XSRQ = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.btnCanncel = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// CB
			// 
			this.CB.Location = new System.Drawing.Point(81, 75);
			this.CB.Name = "CB";
			this.CB.Size = new System.Drawing.Size(171, 21);
			this.CB.TabIndex = 11;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(33, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(41, 12);
			this.label3.TabIndex = 10;
			this.label3.Text = "成本：";
			// 
			// SS
			// 
			this.SS.Location = new System.Drawing.Point(81, 48);
			this.SS.Name = "SS";
			this.SS.Size = new System.Drawing.Size(171, 21);
			this.SS.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(33, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 8;
			this.label2.Text = "实收：";
			// 
			// MC
			// 
			this.MC.Location = new System.Drawing.Point(81, 21);
			this.MC.Name = "MC";
			this.MC.Size = new System.Drawing.Size(171, 21);
			this.MC.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(33, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 12);
			this.label1.TabIndex = 6;
			this.label1.Text = "名称：";
			// 
			// GHS
			// 
			this.GHS.Location = new System.Drawing.Point(81, 102);
			this.GHS.Name = "GHS";
			this.GHS.Size = new System.Drawing.Size(171, 21);
			this.GHS.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(21, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 12);
			this.label5.TabIndex = 12;
			this.label5.Text = "供货商：";
			// 
			// XSRQ
			// 
			this.XSRQ.Location = new System.Drawing.Point(81, 129);
			this.XSRQ.Name = "XSRQ";
			this.XSRQ.Size = new System.Drawing.Size(128, 21);
			this.XSRQ.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(9, 134);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(65, 12);
			this.label8.TabIndex = 16;
			this.label8.Text = "销售日期：";
			// 
			// btnCanncel
			// 
			this.btnCanncel.Location = new System.Drawing.Point(157, 182);
			this.btnCanncel.Name = "btnCanncel";
			this.btnCanncel.Size = new System.Drawing.Size(65, 23);
			this.btnCanncel.TabIndex = 21;
			this.btnCanncel.Text = "取消";
			this.btnCanncel.UseVisualStyleBackColor = true;
			this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(74, 183);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 23);
			this.btnSave.TabIndex = 20;
			this.btnSave.Text = "保存";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// frmMaintainEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(321, 236);
			this.Controls.Add(this.btnCanncel);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.XSRQ);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.GHS);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.CB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.SS);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.MC);
			this.Controls.Add(this.label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMaintainEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "维修";
			this.Load += new System.EventHandler(this.frmMaintainEdit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox CB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox SS;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox MC;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox GHS;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker XSRQ;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnCanncel;
		private System.Windows.Forms.Button btnSave;
	}
}