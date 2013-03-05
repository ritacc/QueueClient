namespace QM.Client.UpdateDB
{
    partial class FrmMain
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
            this.btnBussiness = new System.Windows.Forms.Button();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnBussiness
            // 
            this.btnBussiness.Location = new System.Drawing.Point(23, 13);
            this.btnBussiness.Name = "btnBussiness";
            this.btnBussiness.Size = new System.Drawing.Size(116, 23);
            this.btnBussiness.TabIndex = 0;
            this.btnBussiness.Text = "与服务器数据同步";
            this.btnBussiness.UseVisualStyleBackColor = true;
            this.btnBussiness.Click += new System.EventHandler(this.btnBussiness_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.Location = new System.Drawing.Point(23, 57);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(428, 204);
            this.rtbMsg.TabIndex = 1;
            this.rtbMsg.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 273);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.btnBussiness);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "更新数据";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBussiness;
        private System.Windows.Forms.RichTextBox rtbMsg;
    }
}