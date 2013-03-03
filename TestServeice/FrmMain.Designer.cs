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
            this.btnGetQueues = new System.Windows.Forms.Button();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.lblBill = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtEmployeeNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnJudge = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
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
            this.btnCH.Location = new System.Drawing.Point(311, 225);
            this.btnCH.Name = "btnCH";
            this.btnCH.Size = new System.Drawing.Size(75, 23);
            this.btnCH.TabIndex = 2;
            this.btnCH.Text = "取号";
            this.btnCH.UseVisualStyleBackColor = true;
            this.btnCH.Click += new System.EventHandler(this.btnCH_Click);
            // 
            // txtBussinessID
            // 
            this.txtBussinessID.Location = new System.Drawing.Point(52, 225);
            this.txtBussinessID.Name = "txtBussinessID";
            this.txtBussinessID.Size = new System.Drawing.Size(253, 21);
            this.txtBussinessID.TabIndex = 3;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(188, 255);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(75, 23);
            this.btnCall.TabIndex = 4;
            this.btnCall.Text = "呼叫";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtWindowNo
            // 
            this.txtWindowNo.Location = new System.Drawing.Point(435, 370);
            this.txtWindowNo.Name = "txtWindowNo";
            this.txtWindowNo.Size = new System.Drawing.Size(100, 21);
            this.txtWindowNo.TabIndex = 5;
            // 
            // btnWelcome
            // 
            this.btnWelcome.Location = new System.Drawing.Point(178, 284);
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.Size = new System.Drawing.Size(75, 23);
            this.btnWelcome.TabIndex = 6;
            this.btnWelcome.Text = "欢迎";
            this.btnWelcome.UseVisualStyleBackColor = true;
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
            // 
            // txtBill
            // 
            this.txtBill.Location = new System.Drawing.Point(52, 284);
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(120, 21);
            this.txtBill.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "票号：";
            // 
            // btnGetQueues
            // 
            this.btnGetQueues.Location = new System.Drawing.Point(249, 394);
            this.btnGetQueues.Name = "btnGetQueues";
            this.btnGetQueues.Size = new System.Drawing.Size(75, 23);
            this.btnGetQueues.TabIndex = 9;
            this.btnGetQueues.Text = "获取取号记录";
            this.btnGetQueues.UseVisualStyleBackColor = true;
            this.btnGetQueues.Click += new System.EventHandler(this.btnGetQueues_Click);
            // 
            // rtbMsg
            // 
            this.rtbMsg.Location = new System.Drawing.Point(13, 396);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.Size = new System.Drawing.Size(221, 96);
            this.rtbMsg.TabIndex = 10;
            this.rtbMsg.Text = "";
            // 
            // lblBill
            // 
            this.lblBill.AutoSize = true;
            this.lblBill.Location = new System.Drawing.Point(402, 225);
            this.lblBill.Name = "lblBill";
            this.lblBill.Size = new System.Drawing.Size(29, 12);
            this.lblBill.TabIndex = 11;
            this.lblBill.Text = "票号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-1, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "业务ID：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(391, 377);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "窗口：";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(435, 408);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtEmployeeNo
            // 
            this.txtEmployeeNo.Location = new System.Drawing.Point(435, 334);
            this.txtEmployeeNo.Name = "txtEmployeeNo";
            this.txtEmployeeNo.Size = new System.Drawing.Size(100, 21);
            this.txtEmployeeNo.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "用户编号：";
            // 
            // btnJudge
            // 
            this.btnJudge.Location = new System.Drawing.Point(260, 283);
            this.btnJudge.Name = "btnJudge";
            this.btnJudge.Size = new System.Drawing.Size(75, 23);
            this.btnJudge.TabIndex = 17;
            this.btnJudge.Text = "请评价";
            this.btnJudge.UseVisualStyleBackColor = true;
            this.btnJudge.Click += new System.EventHandler(this.btnJudge_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Location = new System.Drawing.Point(393, 452);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(75, 23);
            this.btnEnd.TabIndex = 18;
            this.btnEnd.Text = "结束服务";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(368, 481);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 19;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = false;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Location = new System.Drawing.Point(449, 481);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(75, 23);
            this.btnRestart.TabIndex = 20;
            this.btnRestart.Text = "恢复";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 506);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnJudge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmployeeNo);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBill);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.btnGetQueues);
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
        private System.Windows.Forms.Button btnGetQueues;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.Label lblBill;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtEmployeeNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnJudge;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnRestart;
    }
}

