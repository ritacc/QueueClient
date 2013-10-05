namespace Clothes.SellingClothes
{
    partial class SellClotheEdit
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
            this.cbSellType = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblTime = new System.Windows.Forms.Label();
            this.txtSellprice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtProfit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPurchasecountprice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPurchaseprice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtClotheno = new System.Windows.Forms.TextBox();
            this.txtClothename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCanncel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbSellType
            // 
            this.cbSellType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSellType.FormattingEnabled = true;
            this.cbSellType.Location = new System.Drawing.Point(87, 103);
            this.cbSellType.Name = "cbSellType";
            this.cbSellType.Size = new System.Drawing.Size(138, 20);
            this.cbSellType.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 66);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(132, 21);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(16, 75);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(65, 12);
            this.lblTime.TabIndex = 32;
            this.lblTime.Text = "销售时间：";
            // 
            // txtSellprice
            // 
            this.txtSellprice.Location = new System.Drawing.Point(87, 183);
            this.txtSellprice.Name = "txtSellprice";
            this.txtSellprice.Size = new System.Drawing.Size(248, 21);
            this.txtSellprice.TabIndex = 7;
            this.txtSellprice.TextChanged += new System.EventHandler(this.txtSellprice_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 192);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 30;
            this.label8.Text = "销售价格：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(87, 242);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(248, 48);
            this.txtRemark.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "备注：";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(87, 308);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(53, 30);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "确定";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtProfit
            // 
            this.txtProfit.Location = new System.Drawing.Point(87, 215);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Size = new System.Drawing.Size(248, 21);
            this.txtProfit.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "利润：";
            // 
            // txtPurchasecountprice
            // 
            this.txtPurchasecountprice.Location = new System.Drawing.Point(87, 156);
            this.txtPurchasecountprice.Name = "txtPurchasecountprice";
            this.txtPurchasecountprice.Size = new System.Drawing.Size(248, 21);
            this.txtPurchasecountprice.TabIndex = 6;
            this.txtPurchasecountprice.TextChanged += new System.EventHandler(this.txtPurchasecountprice_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "进货总价：";
            // 
            // txtPurchaseprice
            // 
            this.txtPurchaseprice.Location = new System.Drawing.Point(87, 129);
            this.txtPurchaseprice.Name = "txtPurchaseprice";
            this.txtPurchaseprice.Size = new System.Drawing.Size(248, 21);
            this.txtPurchaseprice.TabIndex = 5;
            this.txtPurchaseprice.TextChanged += new System.EventHandler(this.txtPurchaseprice_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 22;
            this.label4.Text = "进货价格：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "衣服名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "衣服编号：";
            // 
            // txtClotheno
            // 
            this.txtClotheno.Location = new System.Drawing.Point(87, 12);
            this.txtClotheno.Name = "txtClotheno";
            this.txtClotheno.Size = new System.Drawing.Size(248, 21);
            this.txtClotheno.TabIndex = 1;
            // 
            // txtClothename
            // 
            this.txtClothename.Location = new System.Drawing.Point(87, 39);
            this.txtClothename.Name = "txtClothename";
            this.txtClothename.Size = new System.Drawing.Size(248, 21);
            this.txtClothename.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "衣服类别：";
            // 
            // btnCanncel
            // 
            this.btnCanncel.Location = new System.Drawing.Point(180, 308);
            this.btnCanncel.Name = "btnCanncel";
            this.btnCanncel.Size = new System.Drawing.Size(53, 30);
            this.btnCanncel.TabIndex = 33;
            this.btnCanncel.Text = "取消";
            this.btnCanncel.UseVisualStyleBackColor = true;
            this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
            // 
            // SellClotheEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 359);
            this.Controls.Add(this.btnCanncel);
            this.Controls.Add(this.cbSellType);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtSellprice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.txtProfit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPurchasecountprice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPurchaseprice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClotheno);
            this.Controls.Add(this.txtClothename);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellClotheEdit";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "销售记录";
            this.Load += new System.EventHandler(this.SellClotheEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbSellType;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.TextBox txtSellprice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtProfit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPurchasecountprice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPurchaseprice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtClotheno;
        private System.Windows.Forms.TextBox txtClothename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCanncel;
    }
}