namespace ServerInstall
{
    partial class frmDataParaSet
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
            this.btnMysqlTest = new System.Windows.Forms.Button();
            this.cbUpTimelen = new System.Windows.Forms.ComboBox();
            this.txtMysqlIP = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBankno = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMySqlPwd = new System.Windows.Forms.TextBox();
            this.txtQueueUpTimeLen = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMysqlUserName = new System.Windows.Forms.TextBox();
            this.btnnext = new System.Windows.Forms.Button();
            this.gpDB = new System.Windows.Forms.GroupBox();
            this.txtBcmUid = new System.Windows.Forms.TextBox();
            this.btnMSSqlTest = new System.Windows.Forms.Button();
            this.txtBcmIp = new System.Windows.Forms.TextBox();
            this.txtBcmPwd = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBcmName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMysqlDB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.gpDB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMysqlTest
            // 
            this.btnMysqlTest.Location = new System.Drawing.Point(136, 141);
            this.btnMysqlTest.Name = "btnMysqlTest";
            this.btnMysqlTest.Size = new System.Drawing.Size(55, 27);
            this.btnMysqlTest.TabIndex = 16;
            this.btnMysqlTest.Text = "测试";
            this.btnMysqlTest.UseVisualStyleBackColor = true;
            this.btnMysqlTest.Click += new System.EventHandler(this.btnMysqlTest_Click);
            // 
            // cbUpTimelen
            // 
            this.cbUpTimelen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpTimelen.FormattingEnabled = true;
            this.cbUpTimelen.Items.AddRange(new object[] {
            "-1",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.cbUpTimelen.Location = new System.Drawing.Point(179, 266);
            this.cbUpTimelen.Name = "cbUpTimelen";
            this.cbUpTimelen.Size = new System.Drawing.Size(77, 20);
            this.cbUpTimelen.TabIndex = 34;
            // 
            // txtMysqlIP
            // 
            this.txtMysqlIP.Location = new System.Drawing.Point(86, 22);
            this.txtMysqlIP.Name = "txtMysqlIP";
            this.txtMysqlIP.Size = new System.Drawing.Size(105, 21);
            this.txtMysqlIP.TabIndex = 8;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(67, 269);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 12);
            this.label12.TabIndex = 33;
            this.label12.Text = "参数同步时间：";
            // 
            // txtBankno
            // 
            this.txtBankno.Location = new System.Drawing.Point(179, 208);
            this.txtBankno.Name = "txtBankno";
            this.txtBankno.Size = new System.Drawing.Size(100, 21);
            this.txtBankno.TabIndex = 32;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(96, 211);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 31;
            this.label11.Text = "网点编号：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(262, 246);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "秒";
            // 
            // txtMySqlPwd
            // 
            this.txtMySqlPwd.Location = new System.Drawing.Point(86, 83);
            this.txtMySqlPwd.Name = "txtMySqlPwd";
            this.txtMySqlPwd.Size = new System.Drawing.Size(105, 21);
            this.txtMySqlPwd.TabIndex = 10;
            this.txtMySqlPwd.UseSystemPasswordChar = true;
            // 
            // txtQueueUpTimeLen
            // 
            this.txtQueueUpTimeLen.Location = new System.Drawing.Point(180, 237);
            this.txtQueueUpTimeLen.Name = "txtQueueUpTimeLen";
            this.txtQueueUpTimeLen.Size = new System.Drawing.Size(76, 21);
            this.txtQueueUpTimeLen.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(137, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "取号数据同步时间间隔：";
            // 
            // txtMysqlUserName
            // 
            this.txtMysqlUserName.Location = new System.Drawing.Point(86, 53);
            this.txtMysqlUserName.Name = "txtMysqlUserName";
            this.txtMysqlUserName.Size = new System.Drawing.Size(105, 21);
            this.txtMysqlUserName.TabIndex = 9;
            // 
            // btnnext
            // 
            this.btnnext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext.Location = new System.Drawing.Point(422, 298);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 32);
            this.btnnext.TabIndex = 27;
            this.btnnext.Text = "保存";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // gpDB
            // 
            this.gpDB.Controls.Add(this.txtBcmUid);
            this.gpDB.Controls.Add(this.btnMSSqlTest);
            this.gpDB.Controls.Add(this.txtBcmIp);
            this.gpDB.Controls.Add(this.txtBcmPwd);
            this.gpDB.Controls.Add(this.label4);
            this.gpDB.Controls.Add(this.txtBcmName);
            this.gpDB.Controls.Add(this.label3);
            this.gpDB.Controls.Add(this.label1);
            this.gpDB.Controls.Add(this.label2);
            this.gpDB.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpDB.Location = new System.Drawing.Point(14, 13);
            this.gpDB.Name = "gpDB";
            this.gpDB.Size = new System.Drawing.Size(242, 179);
            this.gpDB.TabIndex = 25;
            this.gpDB.TabStop = false;
            this.gpDB.Text = "服务器数据库配置(SQLServer)";
            // 
            // txtBcmUid
            // 
            this.txtBcmUid.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBcmUid.Location = new System.Drawing.Point(103, 51);
            this.txtBcmUid.Name = "txtBcmUid";
            this.txtBcmUid.Size = new System.Drawing.Size(105, 23);
            this.txtBcmUid.TabIndex = 1;
            // 
            // btnMSSqlTest
            // 
            this.btnMSSqlTest.Location = new System.Drawing.Point(153, 138);
            this.btnMSSqlTest.Name = "btnMSSqlTest";
            this.btnMSSqlTest.Size = new System.Drawing.Size(55, 27);
            this.btnMSSqlTest.TabIndex = 9;
            this.btnMSSqlTest.Text = "测试";
            this.btnMSSqlTest.UseVisualStyleBackColor = true;
            this.btnMSSqlTest.Click += new System.EventHandler(this.btnMSSqlTest_Click);
            // 
            // txtBcmIp
            // 
            this.txtBcmIp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBcmIp.Location = new System.Drawing.Point(103, 22);
            this.txtBcmIp.Name = "txtBcmIp";
            this.txtBcmIp.Size = new System.Drawing.Size(105, 23);
            this.txtBcmIp.TabIndex = 0;
            // 
            // txtBcmPwd
            // 
            this.txtBcmPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBcmPwd.Location = new System.Drawing.Point(103, 80);
            this.txtBcmPwd.Name = "txtBcmPwd";
            this.txtBcmPwd.Size = new System.Drawing.Size(105, 23);
            this.txtBcmPwd.TabIndex = 2;
            this.txtBcmPwd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(14, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库名称";
            // 
            // txtBcmName
            // 
            this.txtBcmName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBcmName.Location = new System.Drawing.Point(103, 109);
            this.txtBcmName.Name = "txtBcmName";
            this.txtBcmName.Size = new System.Drawing.Size(105, 23);
            this.txtBcmName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(41, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(42, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "用户名";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMysqlTest);
            this.groupBox1.Controls.Add(this.txtMysqlUserName);
            this.groupBox1.Controls.Add(this.txtMysqlIP);
            this.groupBox1.Controls.Add(this.txtMySqlPwd);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtMysqlDB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(273, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 179);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端数据库(MySQL)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "数据库名称";
            // 
            // txtMysqlDB
            // 
            this.txtMysqlDB.Location = new System.Drawing.Point(86, 112);
            this.txtMysqlDB.Name = "txtMysqlDB";
            this.txtMysqlDB.Size = new System.Drawing.Size(105, 21);
            this.txtMysqlDB.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "用户名";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(262, 274);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(215, 12);
            this.label13.TabIndex = 35;
            this.label13.Text = "-1:启动时更新。每天0-23：更新一次。";
            // 
            // frmDataParaSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 343);
            this.Controls.Add(this.cbUpTimelen);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtBankno);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQueueUpTimeLen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.gpDB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label13);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(527, 370);
            this.MinimumSize = new System.Drawing.Size(527, 370);
            this.Name = "frmDataParaSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库、参数设置";
            this.Load += new System.EventHandler(this.frmDataParaSet_Load);
            this.gpDB.ResumeLayout(false);
            this.gpDB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMysqlTest;
        private System.Windows.Forms.ComboBox cbUpTimelen;
        private System.Windows.Forms.TextBox txtMysqlIP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBankno;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMySqlPwd;
        private System.Windows.Forms.TextBox txtQueueUpTimeLen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMysqlUserName;
        private System.Windows.Forms.Button btnnext;
        private System.Windows.Forms.GroupBox gpDB;
        private System.Windows.Forms.TextBox txtBcmUid;
        private System.Windows.Forms.Button btnMSSqlTest;
        private System.Windows.Forms.TextBox txtBcmIp;
        private System.Windows.Forms.TextBox txtBcmPwd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBcmName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMysqlDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;

    }
}