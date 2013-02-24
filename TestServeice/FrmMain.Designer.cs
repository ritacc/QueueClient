namespace TestServeice
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
            this.btnGetAllBussiness = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnCH = new System.Windows.Forms.Button();
            this.txtBussinessID = new System.Windows.Forms.TextBox();
            this.btnCall = new System.Windows.Forms.Button();
            this.txtWindowNo = new System.Windows.Forms.TextBox();
            this.btnWelcome = new System.Windows.Forms.Button();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetAllBussiness
            // 
            this.btnGetAllBussiness.Location = new System.Drawing.Point(33, 12);
            this.btnGetAllBussiness.Name = "btnGetAllBussiness";
            this.btnGetAllBussiness.Size = new System.Drawing.Size(75, 23);
            this.btnGetAllBussiness.TabIndex = 0;
            this.btnGetAllBussiness.Text = "获取业务";
            this.btnGetAllBussiness.UseVisualStyleBackColor = true;
            this.btnGetAllBussiness.Click += new System.EventHandler(this.btnGetAllBussiness_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(470, 164);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnCH
            // 
            this.btnCH.Location = new System.Drawing.Point(249, 225);
            this.btnCH.Name = "btnCH";
            this.btnCH.Size = new System.Drawing.Size(75, 23);
            this.btnCH.TabIndex = 2;
            this.btnCH.Text = "取号";
            this.btnCH.UseVisualStyleBackColor = true;
            this.btnCH.Click += new System.EventHandler(this.btnCH_Click);
            // 
            // txtBussinessID
            // 
            this.txtBussinessID.Location = new System.Drawing.Point(22, 225);
            this.txtBussinessID.Name = "txtBussinessID";
            this.txtBussinessID.Size = new System.Drawing.Size(212, 21);
            this.txtBussinessID.TabIndex = 3;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(249, 254);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 4;
            this.btnCall.Text = "呼叫";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtWindowNo
            // 
            this.txtWindowNo.Location = new System.Drawing.Point(22, 252);
            this.txtWindowNo.Name = "txtWindowNo";
            this.txtWindowNo.Size = new System.Drawing.Size(212, 21);
            this.txtWindowNo.TabIndex = 5;
            // 
            // btnWelcome
            // 
            this.btnWelcome.Location = new System.Drawing.Point(249, 284);
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.Size = new System.Drawing.Size(75, 23);
            this.btnWelcome.TabIndex = 6;
            this.btnWelcome.Text = "欢迎";
            this.btnWelcome.UseVisualStyleBackColor = true;
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(72, 284);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(120, 21);
            this.txtBill.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "票号：";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 506);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBill);
            this.Controls.Add(this.btnWelcome);
            this.Controls.Add(this.txtWindowNo);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.txtBussinessID);
            this.Controls.Add(this.btnCH);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnGetAllBussiness);
            this.Name = "FrmMain";
            this.Text = "测试web服务";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetAllBussiness;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnCH;
        private System.Windows.Forms.TextBox txtBussinessID;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.TextBox txtWindowNo;
        private System.Windows.Forms.Button btnWelcome;
        private System.Windows.Forms.TextBox txtBill;
        private System.Windows.Forms.Label label1;
    }
}

