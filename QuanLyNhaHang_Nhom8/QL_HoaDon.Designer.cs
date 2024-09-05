namespace QuanLyNhaHang_Nhom8
{
    partial class QL_HoaDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_hoadon = new System.Windows.Forms.DataGridView();
            this.MaDatMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayDatMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDangNhap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_dsmon = new System.Windows.Forms.DataGridView();
            this.MaDatMon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsmon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgv_hoadon);
            this.groupBox1.Location = new System.Drawing.Point(137, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1010, 1031);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dgv_hoadon
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_hoadon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_hoadon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoadon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatMon,
            this.NgayDatMon,
            this.MaBan,
            this.TenDangNhap});
            this.dgv_hoadon.Location = new System.Drawing.Point(42, 96);
            this.dgv_hoadon.Name = "dgv_hoadon";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_hoadon.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_hoadon.RowTemplate.Height = 33;
            this.dgv_hoadon.Size = new System.Drawing.Size(917, 885);
            this.dgv_hoadon.TabIndex = 0;
            this.dgv_hoadon.SelectionChanged += new System.EventHandler(this.dgv_hoadon_SelectionChanged);
            // 
            // MaDatMon
            // 
            this.MaDatMon.DataPropertyName = "MaDatMon";
            this.MaDatMon.HeaderText = "Mã HĐ";
            this.MaDatMon.Name = "MaDatMon";
            // 
            // NgayDatMon
            // 
            this.NgayDatMon.DataPropertyName = "NgayDatMon";
            this.NgayDatMon.HeaderText = "Ngày HĐ";
            this.NgayDatMon.Name = "NgayDatMon";
            // 
            // MaBan
            // 
            this.MaBan.DataPropertyName = "MaBan";
            this.MaBan.HeaderText = "Mã Bàn";
            this.MaBan.Name = "MaBan";
            // 
            // TenDangNhap
            // 
            this.TenDangNhap.DataPropertyName = "TenDangNhap";
            this.TenDangNhap.HeaderText = "TK DM";
            this.TenDangNhap.Name = "TenDangNhap";
            // 
            // dgv_dsmon
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_dsmon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgv_dsmon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_dsmon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaDatMon1,
            this.TenMonAn,
            this.SoLuong});
            this.dgv_dsmon.Location = new System.Drawing.Point(1198, 276);
            this.dgv_dsmon.Name = "dgv_dsmon";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_dsmon.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dgv_dsmon.RowTemplate.Height = 33;
            this.dgv_dsmon.Size = new System.Drawing.Size(831, 787);
            this.dgv_dsmon.TabIndex = 1;
            // 
            // MaDatMon1
            // 
            this.MaDatMon1.DataPropertyName = "MaDatMon";
            this.MaDatMon1.HeaderText = "Mã HĐ";
            this.MaDatMon1.Name = "MaDatMon1";
            // 
            // TenMonAn
            // 
            this.TenMonAn.DataPropertyName = "TenMonAn";
            this.TenMonAn.HeaderText = "Tên Món";
            this.TenMonAn.Name = "TenMonAn";
            this.TenMonAn.Width = 230;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "SL";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 50;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 55);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh Sách HĐ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1188, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 55);
            this.label2.TabIndex = 3;
            this.label2.Text = "Chi Tiết HĐ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyNhaHang_Nhom8.Properties.Resources.icons8_print_50;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(1198, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(202, 99);
            this.button1.TabIndex = 4;
            this.button1.Text = "IN HĐ";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Location = new System.Drawing.Point(1, 1119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2554, 177);
            this.panel1.TabIndex = 5;
            // 
            // QL_HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2554, 1292);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv_dsmon);
            this.Controls.Add(this.groupBox1);
            this.Name = "QL_HoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DIIII";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QL_HoaDon_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoadon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_dsmon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_hoadon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayDatMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDangNhap;
        private System.Windows.Forms.DataGridView dgv_dsmon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDatMon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}