namespace Clothes.SellingClothes
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.lblShowMsg = new System.Windows.Forms.Label();
			this.GdTodayList = new System.Windows.Forms.DataGridView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtpEnd = new System.Windows.Forms.DateTimePicker();
			this.btnSearch = new System.Windows.Forms.Button();
			this.dtpSellDt = new System.Windows.Forms.DateTimePicker();
			this.lblSellTime = new System.Windows.Forms.Label();
			this.btnSellPhone = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.GdTodayList)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(766, 506);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.panel2);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(758, 480);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "手机";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.GdTodayList);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 60);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(752, 417);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.lblShowMsg);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel3.Location = new System.Drawing.Point(0, 369);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(752, 48);
			this.panel3.TabIndex = 1;
			// 
			// lblShowMsg
			// 
			this.lblShowMsg.AutoSize = true;
			this.lblShowMsg.Location = new System.Drawing.Point(14, 18);
			this.lblShowMsg.Name = "lblShowMsg";
			this.lblShowMsg.Size = new System.Drawing.Size(41, 12);
			this.lblShowMsg.TabIndex = 1;
			this.lblShowMsg.Text = "信息：";
			// 
			// GdTodayList
			// 
			this.GdTodayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.GdTodayList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GdTodayList.Location = new System.Drawing.Point(0, 0);
			this.GdTodayList.Name = "GdTodayList";
			this.GdTodayList.RowTemplate.Height = 23;
			this.GdTodayList.Size = new System.Drawing.Size(752, 417);
			this.GdTodayList.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.dtpEnd);
			this.panel1.Controls.Add(this.btnSearch);
			this.panel1.Controls.Add(this.dtpSellDt);
			this.panel1.Controls.Add(this.lblSellTime);
			this.panel1.Controls.Add(this.btnSellPhone);
			this.panel1.Controls.Add(this.btnAdd);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(752, 57);
			this.panel1.TabIndex = 0;
			// 
			// dtpEnd
			// 
			this.dtpEnd.Location = new System.Drawing.Point(254, 5);
			this.dtpEnd.Name = "dtpEnd";
			this.dtpEnd.Size = new System.Drawing.Size(137, 21);
			this.dtpEnd.TabIndex = 8;
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(397, 4);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(47, 23);
			this.btnSearch.TabIndex = 7;
			this.btnSearch.Text = "查询";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// dtpSellDt
			// 
			this.dtpSellDt.Location = new System.Drawing.Point(83, 5);
			this.dtpSellDt.Name = "dtpSellDt";
			this.dtpSellDt.Size = new System.Drawing.Size(137, 21);
			this.dtpSellDt.TabIndex = 6;
			// 
			// lblSellTime
			// 
			this.lblSellTime.AutoSize = true;
			this.lblSellTime.Location = new System.Drawing.Point(11, 10);
			this.lblSellTime.Name = "lblSellTime";
			this.lblSellTime.Size = new System.Drawing.Size(65, 12);
			this.lblSellTime.TabIndex = 5;
			this.lblSellTime.Text = "销售时间：";
			// 
			// btnSellPhone
			// 
			this.btnSellPhone.Enabled = false;
			this.btnSellPhone.Location = new System.Drawing.Point(315, 28);
			this.btnSellPhone.Name = "btnSellPhone";
			this.btnSellPhone.Size = new System.Drawing.Size(75, 23);
			this.btnSellPhone.TabIndex = 1;
			this.btnSellPhone.Text = "卖手机";
			this.btnSellPhone.UseVisualStyleBackColor = true;
			this.btnSellPhone.Click += new System.EventHandler(this.btnSellPhone_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(524, 5);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "添加";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(758, 480);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "维修";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(758, 480);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "配件";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 506);
			this.Controls.Add(this.tabControl1);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "进销系统";
			this.Load += new System.EventHandler(this.Main_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.GdTodayList)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GdTodayList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSellPhone;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblShowMsg;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpSellDt;
        private System.Windows.Forms.Label lblSellTime;


    }
}