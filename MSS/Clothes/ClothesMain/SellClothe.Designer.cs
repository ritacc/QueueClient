namespace Clothes.SellingClothes
{
    partial class SellClothe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpSellDt = new System.Windows.Forms.DateTimePicker();
            this.lblSellTime = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblShowMsg = new System.Windows.Forms.Label();
            this.GdTodayList = new System.Windows.Forms.DataGridView();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GdTodayList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpEnd);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpSellDt);
            this.panel1.Controls.Add(this.lblSellTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1012, 40);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(699, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(313, 40);
            this.panel3.TabIndex = 3;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(178, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(55, 26);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "修改";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(99, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(403, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(47, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpSellDt
            // 
            this.dtpSellDt.Location = new System.Drawing.Point(89, 12);
            this.dtpSellDt.Name = "dtpSellDt";
            this.dtpSellDt.Size = new System.Drawing.Size(137, 21);
            this.dtpSellDt.TabIndex = 1;
            // 
            // lblSellTime
            // 
            this.lblSellTime.AutoSize = true;
            this.lblSellTime.Location = new System.Drawing.Point(17, 17);
            this.lblSellTime.Name = "lblSellTime";
            this.lblSellTime.Size = new System.Drawing.Size(65, 12);
            this.lblSellTime.TabIndex = 0;
            this.lblSellTime.Text = "销售时间：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.GdTodayList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1012, 507);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblShowMsg);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 457);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1012, 50);
            this.panel4.TabIndex = 1;
            // 
            // lblShowMsg
            // 
            this.lblShowMsg.AutoSize = true;
            this.lblShowMsg.Location = new System.Drawing.Point(17, 18);
            this.lblShowMsg.Name = "lblShowMsg";
            this.lblShowMsg.Size = new System.Drawing.Size(0, 12);
            this.lblShowMsg.TabIndex = 0;
            // 
            // GdTodayList
            // 
            this.GdTodayList.AllowUserToAddRows = false;
            this.GdTodayList.AllowUserToDeleteRows = false;
            this.GdTodayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GdTodayList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GdTodayList.GridColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.GdTodayList.Location = new System.Drawing.Point(0, 0);
            this.GdTodayList.MultiSelect = false;
            this.GdTodayList.Name = "GdTodayList";
            this.GdTodayList.RowTemplate.Height = 23;
            this.GdTodayList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GdTodayList.ShowCellErrors = false;
            this.GdTodayList.ShowCellToolTips = false;
            this.GdTodayList.ShowEditingIcon = false;
            this.GdTodayList.ShowRowErrors = false;
            this.GdTodayList.Size = new System.Drawing.Size(1012, 507);
            this.GdTodayList.TabIndex = 0;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(260, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(137, 21);
            this.dtpEnd.TabIndex = 4;
            // 
            // SellClothe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 547);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SellClothe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售管理";
            this.Load += new System.EventHandler(this.SellClothe_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GdTodayList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView GdTodayList;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpSellDt;
        private System.Windows.Forms.Label lblSellTime;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblShowMsg;
        private System.Windows.Forms.DateTimePicker dtpEnd;
    }
}