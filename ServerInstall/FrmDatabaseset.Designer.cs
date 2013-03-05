namespace ServerInstall
{
    partial class FrmDatabaseset
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
            this.txtMysqlUserName = new System.Windows.Forms.TextBox();
            this.txtMysqlIP = new System.Windows.Forms.TextBox();
            this.txtMySqlPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMysqlDB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnMysqlTest = new System.Windows.Forms.Button();
            this.btnnext = new System.Windows.Forms.Button();
            this.gpDB.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.gpDB.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpDB.Location = new System.Drawing.Point(14, 14);
            this.gpDB.Name = "gpDB";
            this.gpDB.Size = new System.Drawing.Size(265, 205);
            this.gpDB.TabIndex = 14;
            this.gpDB.TabStop = false;
            this.gpDB.Text = "服务器数据库配置(SQLServer)";
            // 
            // txtBcmUid
            // 
            this.txtBcmUid.Location = new System.Drawing.Point(103, 65);
            this.txtBcmUid.Name = "txtBcmUid";
            this.txtBcmUid.Size = new System.Drawing.Size(135, 26);
            this.txtBcmUid.TabIndex = 1;
            // 
            // btnMSSqlTest
            // 
            this.btnMSSqlTest.Location = new System.Drawing.Point(183, 168);
            this.btnMSSqlTest.Name = "btnMSSqlTest";
            this.btnMSSqlTest.Size = new System.Drawing.Size(55, 27);
            this.btnMSSqlTest.TabIndex = 9;
            this.btnMSSqlTest.Text = "测试";
            this.btnMSSqlTest.UseVisualStyleBackColor = true;
            this.btnMSSqlTest.Click += new System.EventHandler(this.btnMSSqlTest_Click);
            // 
            // txtBcmIp
            // 
            this.txtBcmIp.Location = new System.Drawing.Point(103, 33);
            this.txtBcmIp.Name = "txtBcmIp";
            this.txtBcmIp.Size = new System.Drawing.Size(135, 26);
            this.txtBcmIp.TabIndex = 0;
            // 
            // txtBcmPwd
            // 
            this.txtBcmPwd.Location = new System.Drawing.Point(103, 97);
            this.txtBcmPwd.Name = "txtBcmPwd";
            this.txtBcmPwd.Size = new System.Drawing.Size(135, 26);
            this.txtBcmPwd.TabIndex = 2;
            this.txtBcmPwd.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库名称";
            // 
            // txtBcmName
            // 
            this.txtBcmName.Location = new System.Drawing.Point(103, 128);
            this.txtBcmName.Name = "txtBcmName";
            this.txtBcmName.Size = new System.Drawing.Size(135, 26);
            this.txtBcmName.TabIndex = 3;
            this.txtBcmName.Text = "BCM_FZ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
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
            this.groupBox1.Location = new System.Drawing.Point(294, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 205);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "客户端数据库(MySQL)";
            // 
            // txtMysqlUserName
            // 
            this.txtMysqlUserName.Location = new System.Drawing.Point(86, 68);
            this.txtMysqlUserName.Name = "txtMysqlUserName";
            this.txtMysqlUserName.Size = new System.Drawing.Size(135, 23);
            this.txtMysqlUserName.TabIndex = 9;
            // 
            // txtMysqlIP
            // 
            this.txtMysqlIP.Location = new System.Drawing.Point(86, 36);
            this.txtMysqlIP.Name = "txtMysqlIP";
            this.txtMysqlIP.Size = new System.Drawing.Size(135, 23);
            this.txtMysqlIP.TabIndex = 8;
            // 
            // txtMySqlPwd
            // 
            this.txtMySqlPwd.Location = new System.Drawing.Point(86, 100);
            this.txtMySqlPwd.Name = "txtMySqlPwd";
            this.txtMySqlPwd.Size = new System.Drawing.Size(135, 23);
            this.txtMySqlPwd.TabIndex = 10;
            this.txtMySqlPwd.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "数据库名称";
            // 
            // txtMysqlDB
            // 
            this.txtMysqlDB.Location = new System.Drawing.Point(86, 131);
            this.txtMysqlDB.Name = "txtMysqlDB";
            this.txtMysqlDB.Size = new System.Drawing.Size(135, 23);
            this.txtMysqlDB.TabIndex = 11;
            this.txtMysqlDB.Text = "BCM_FZ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 14;
            this.label6.Text = "密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 12;
            this.label7.Text = "IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(31, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "用户名";
            // 
            // btnMysqlTest
            // 
            this.btnMysqlTest.Location = new System.Drawing.Point(166, 168);
            this.btnMysqlTest.Name = "btnMysqlTest";
            this.btnMysqlTest.Size = new System.Drawing.Size(55, 27);
            this.btnMysqlTest.TabIndex = 16;
            this.btnMysqlTest.Text = "测试";
            this.btnMysqlTest.UseVisualStyleBackColor = true;
            this.btnMysqlTest.Click += new System.EventHandler(this.btnMysqlTest_Click);
            // 
            // btnnext
            // 
            this.btnnext.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnext.Location = new System.Drawing.Point(458, 234);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(75, 32);
            this.btnnext.TabIndex = 16;
            this.btnnext.Text = "下一步";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // FrmDatabaseset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 284);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gpDB);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatabaseset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据库设置";
            this.Load += new System.EventHandler(this.FrmDatabaseset_Load);
            this.gpDB.ResumeLayout(false);
            this.gpDB.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

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
        private System.Windows.Forms.TextBox txtMysqlUserName;
        private System.Windows.Forms.TextBox txtMysqlIP;
        private System.Windows.Forms.TextBox txtMySqlPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMysqlDB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnMysqlTest;
        private System.Windows.Forms.Button btnnext;
    }
}