namespace ServerInstall
{
    partial class FrimServiceStart
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
            this.gpServerStart = new System.Windows.Forms.GroupBox();
            this.lblStartServer = new System.Windows.Forms.Label();
            this.btnnext = new System.Windows.Forms.Button();
            this.gpServerStart.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpServerStart
            // 
            this.gpServerStart.Controls.Add(this.lblStartServer);
            this.gpServerStart.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpServerStart.Location = new System.Drawing.Point(22, 10);
            this.gpServerStart.Name = "gpServerStart";
            this.gpServerStart.Size = new System.Drawing.Size(349, 236);
            this.gpServerStart.TabIndex = 16;
            this.gpServerStart.TabStop = false;
            this.gpServerStart.Text = "启动服务";
            // 
            // lblStartServer
            // 
            this.lblStartServer.AutoSize = true;
            this.lblStartServer.Location = new System.Drawing.Point(23, 57);
            this.lblStartServer.Name = "lblStartServer";
            this.lblStartServer.Size = new System.Drawing.Size(152, 16);
            this.lblStartServer.TabIndex = 0;
            this.lblStartServer.Text = "正在启动服务。。。";
            // 
            // btnnext
            // 
            this.btnnext.Enabled = false;
            this.btnnext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext.Location = new System.Drawing.Point(296, 252);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 32);
            this.btnnext.TabIndex = 17;
            this.btnnext.Text = "下一步";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // FrimServiceStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 299);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.gpServerStart);
            this.Name = "FrimServiceStart";
            this.Text = "服务启动";
            this.Load += new System.EventHandler(this.FrimServiceStart_Load);
            this.gpServerStart.ResumeLayout(false);
            this.gpServerStart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gpServerStart;
        private System.Windows.Forms.Label lblStartServer;
        private System.Windows.Forms.Button btnnext;
    }
}