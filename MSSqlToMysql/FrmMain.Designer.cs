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
            this.SuspendLayout();
            // 
            // btnBussiness
            // 
            this.btnBussiness.Location = new System.Drawing.Point(23, 13);
            this.btnBussiness.Name = "btnBussiness";
            this.btnBussiness.Size = new System.Drawing.Size(75, 23);
            this.btnBussiness.TabIndex = 0;
            this.btnBussiness.Text = "Bussiness";
            this.btnBussiness.UseVisualStyleBackColor = true;
            this.btnBussiness.Click += new System.EventHandler(this.btnBussiness_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 273);
            this.Controls.Add(this.btnBussiness);
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBussiness;
    }
}