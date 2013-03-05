namespace ServerInstall
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbItems = new System.Windows.Forms.ListBox();
            this.gpServer = new System.Windows.Forms.GroupBox();
            this.btnnext = new System.Windows.Forms.Button();
            this.gpServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbItems
            // 
            this.lbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbItems.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbItems.FormattingEnabled = true;
            this.lbItems.ItemHeight = 15;
            this.lbItems.Location = new System.Drawing.Point(3, 22);
            this.lbItems.Name = "lbItems";
            this.lbItems.Size = new System.Drawing.Size(378, 227);
            this.lbItems.TabIndex = 7;
            // 
            // gpServer
            // 
            this.gpServer.Controls.Add(this.lbItems);
            this.gpServer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpServer.Location = new System.Drawing.Point(11, 12);
            this.gpServer.Name = "gpServer";
            this.gpServer.Size = new System.Drawing.Size(384, 252);
            this.gpServer.TabIndex = 9;
            this.gpServer.TabStop = false;
            this.gpServer.Text = "服务安装信息";
            // 
            // btnnext
            // 
            this.btnnext.Enabled = false;
            this.btnnext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext.Location = new System.Drawing.Point(317, 270);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 32);
            this.btnnext.TabIndex = 14;
            this.btnnext.Text = "下一步";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 315);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.gpServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务安装";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.gpServer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbItems;
        private System.Windows.Forms.GroupBox gpServer;
        private System.Windows.Forms.Button btnnext;
    }
}

