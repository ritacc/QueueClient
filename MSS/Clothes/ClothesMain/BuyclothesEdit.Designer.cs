namespace Clothes.SellingClothes
{
    partial class BuyclothesEdit
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
            this.btnCanncel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClothesbh = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBuywhere = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpBuydata = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnCanncel
            // 
            this.btnCanncel.Location = new System.Drawing.Point(171, 212);
            this.btnCanncel.Name = "btnCanncel";
            this.btnCanncel.Size = new System.Drawing.Size(53, 30);
            this.btnCanncel.TabIndex = 35;
            this.btnCanncel.Text = "取消";
            this.btnCanncel.UseVisualStyleBackColor = true;
            this.btnCanncel.Click += new System.EventHandler(this.btnCanncel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(78, 212);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(53, 30);
            this.btnEdit.TabIndex = 34;
            this.btnEdit.Text = "确定";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 36;
            this.label1.Text = "编号：";
            // 
            // txtClothesbh
            // 
            this.txtClothesbh.Location = new System.Drawing.Point(77, 12);
            this.txtClothesbh.Name = "txtClothesbh";
            this.txtClothesbh.Size = new System.Drawing.Size(219, 21);
            this.txtClothesbh.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "进货地点：";
            // 
            // txtBuywhere
            // 
            this.txtBuywhere.Location = new System.Drawing.Point(77, 88);
            this.txtBuywhere.Name = "txtBuywhere";
            this.txtBuywhere.Size = new System.Drawing.Size(219, 21);
            this.txtBuywhere.TabIndex = 39;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(77, 128);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(219, 21);
            this.txtPrice.TabIndex = 40;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 41;
            this.label3.Text = "价格：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 43;
            this.label4.Text = "备注：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(77, 167);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(219, 21);
            this.txtRemark.TabIndex = 42;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 44;
            this.label5.Text = "时间：";
            // 
            // dtpBuydata
            // 
            this.dtpBuydata.Location = new System.Drawing.Point(77, 50);
            this.dtpBuydata.Name = "dtpBuydata";
            this.dtpBuydata.Size = new System.Drawing.Size(219, 21);
            this.dtpBuydata.TabIndex = 45;
            // 
            // BuyclothesEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 270);
            this.Controls.Add(this.dtpBuydata);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtBuywhere);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClothesbh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCanncel);
            this.Controls.Add(this.btnEdit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BuyclothesEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "进货编辑";
            this.Load += new System.EventHandler(this.BuyclothesEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCanncel;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClothesbh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBuywhere;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpBuydata;
    }
}