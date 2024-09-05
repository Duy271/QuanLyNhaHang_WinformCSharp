namespace QuanLyNhaHang_Nhom8
{
    partial class frm_ChonThanhToan
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
            this.rdo_chuyenkhoan = new System.Windows.Forms.RadioButton();
            this.rdo_tienmat = new System.Windows.Forms.RadioButton();
            this.btn_xacnhan = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdo_chuyenkhoan);
            this.groupBox1.Controls.Add(this.rdo_tienmat);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(245, 126);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 301);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn Phương Thức Thanh Toán";
            // 
            // rdo_chuyenkhoan
            // 
            this.rdo_chuyenkhoan.AutoSize = true;
            this.rdo_chuyenkhoan.Location = new System.Drawing.Point(77, 180);
            this.rdo_chuyenkhoan.Name = "rdo_chuyenkhoan";
            this.rdo_chuyenkhoan.Size = new System.Drawing.Size(271, 41);
            this.rdo_chuyenkhoan.TabIndex = 1;
            this.rdo_chuyenkhoan.TabStop = true;
            this.rdo_chuyenkhoan.Text = "Chuyển Khoản";
            this.rdo_chuyenkhoan.UseVisualStyleBackColor = true;
            // 
            // rdo_tienmat
            // 
            this.rdo_tienmat.AutoSize = true;
            this.rdo_tienmat.Location = new System.Drawing.Point(77, 82);
            this.rdo_tienmat.Name = "rdo_tienmat";
            this.rdo_tienmat.Size = new System.Drawing.Size(180, 41);
            this.rdo_tienmat.TabIndex = 0;
            this.rdo_tienmat.TabStop = true;
            this.rdo_tienmat.Text = "Tiền Mặt";
            this.rdo_tienmat.UseVisualStyleBackColor = true;
            // 
            // btn_xacnhan
            // 
            this.btn_xacnhan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_xacnhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xacnhan.Location = new System.Drawing.Point(404, 447);
            this.btn_xacnhan.Name = "btn_xacnhan";
            this.btn_xacnhan.Size = new System.Drawing.Size(226, 95);
            this.btn_xacnhan.TabIndex = 1;
            this.btn_xacnhan.Text = "Xác Nhận";
            this.btn_xacnhan.UseVisualStyleBackColor = false;
            this.btn_xacnhan.Click += new System.EventHandler(this.btn_xacnhan_Click);
            // 
            // frm_ChonThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 672);
            this.Controls.Add(this.btn_xacnhan);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_ChonThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ChonThanhToan";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdo_chuyenkhoan;
        private System.Windows.Forms.RadioButton rdo_tienmat;
        private System.Windows.Forms.Button btn_xacnhan;
    }
}