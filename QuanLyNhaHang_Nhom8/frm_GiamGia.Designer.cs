namespace QuanLyNhaHang_Nhom8
{
    partial class frm_GiamGia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.lb_tb = new System.Windows.Forms.Label();
            this.btn_kiemtra = new System.Windows.Forms.Button();
            this.txt_sdt = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_xacnhan);
            this.groupBox1.Controls.Add(this.btn_exit);
            this.groupBox1.Controls.Add(this.lb_tb);
            this.groupBox1.Controls.Add(this.btn_kiemtra);
            this.groupBox1.Controls.Add(this.txt_sdt);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(249, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(643, 317);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập Số Điện Thoại Khách";
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_xacnhan.Location = new System.Drawing.Point(359, 234);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(205, 61);
            this.btn_xacnhan.TabIndex = 4;
            this.btn_xacnhan.Text = "Xác Nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_exit.Location = new System.Drawing.Point(75, 234);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(205, 61);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "Thoát";
            this.btn_exit.UseVisualStyleBackColor = false;
            // 
            // lb_tb
            // 
            this.lb_tb.AutoSize = true;
            this.lb_tb.Location = new System.Drawing.Point(26, 161);
            this.lb_tb.Name = "lb_tb";
            this.lb_tb.Size = new System.Drawing.Size(0, 31);
            this.lb_tb.TabIndex = 2;
            // 
            // btn_kiemtra
            // 
            this.btn_kiemtra.Location = new System.Drawing.Point(444, 94);
            this.btn_kiemtra.Name = "btn_kiemtra";
            this.btn_kiemtra.Size = new System.Drawing.Size(169, 61);
            this.btn_kiemtra.TabIndex = 1;
            this.btn_kiemtra.Text = "Kiểm Tra";
            this.btn_kiemtra.UseVisualStyleBackColor = true;
            this.btn_kiemtra.Click += new System.EventHandler(this.btn_kiemtra_Click);
            // 
            // txt_sdt
            // 
            this.txt_sdt.Location = new System.Drawing.Point(23, 102);
            this.txt_sdt.Multiline = true;
            this.txt_sdt.Name = "txt_sdt";
            this.txt_sdt.Size = new System.Drawing.Size(399, 45);
            this.txt_sdt.TabIndex = 0;
            // 
            // frm_GiamGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 696);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_GiamGia";
            this.Text = "frm_GiamGia";
            this.Load += new System.EventHandler(this.frm_GiamGia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_xacnhan;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Label lb_tb;
        private System.Windows.Forms.Button btn_kiemtra;
        private System.Windows.Forms.TextBox txt_sdt;
    }
}