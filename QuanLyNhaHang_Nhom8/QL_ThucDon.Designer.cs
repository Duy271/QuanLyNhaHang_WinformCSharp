namespace QuanLyNhaHang_Nhom8
{
    partial class QL_ThucDon
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QL_ThucDon));
            this.cbb_trangthai = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_tenmon = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_chonanh = new System.Windows.Forms.Button();
            this.txt_mamon = new System.Windows.Forms.TextBox();
            this.cbb_loaimon = new System.Windows.Forms.ComboBox();
            this.txt_giaban = new System.Windows.Forms.TextBox();
            this.dgv_thucdon = new System.Windows.Forms.DataGridView();
            this.MaMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaLoaiMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DuongDanAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_them = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_sua = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pt_chonanh = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thucdon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pt_chonanh)).BeginInit();
            this.SuspendLayout();
            // 
            // cbb_trangthai
            // 
            this.cbb_trangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_trangthai.FormattingEnabled = true;
            this.cbb_trangthai.Items.AddRange(new object[] {
            "Con",
            "Het"});
            this.cbb_trangthai.Location = new System.Drawing.Point(1087, 371);
            this.cbb_trangthai.Name = "cbb_trangthai";
            this.cbb_trangthai.Size = new System.Drawing.Size(454, 45);
            this.cbb_trangthai.TabIndex = 48;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(917, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 31);
            this.label5.TabIndex = 47;
            this.label5.Text = "Trạng Thái:";
            // 
            // txt_tenmon
            // 
            this.txt_tenmon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_tenmon.Location = new System.Drawing.Point(593, 273);
            this.txt_tenmon.Multiline = true;
            this.txt_tenmon.Name = "txt_tenmon";
            this.txt_tenmon.Size = new System.Drawing.Size(454, 48);
            this.txt_tenmon.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(454, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 31);
            this.label1.TabIndex = 34;
            this.label1.Text = "Mã Món:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(441, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 31);
            this.label2.TabIndex = 35;
            this.label2.Text = "Tên Món:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1283, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 31);
            this.label3.TabIndex = 36;
            this.label3.Text = "Loại Món:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1283, 290);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 31);
            this.label4.TabIndex = 37;
            this.label4.Text = "Giá Bán:";
            // 
            // btn_chonanh
            // 
            this.btn_chonanh.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_chonanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_chonanh.Location = new System.Drawing.Point(78, 440);
            this.btn_chonanh.Name = "btn_chonanh";
            this.btn_chonanh.Size = new System.Drawing.Size(286, 78);
            this.btn_chonanh.TabIndex = 42;
            this.btn_chonanh.Text = "Chọn Ảnh";
            this.btn_chonanh.UseVisualStyleBackColor = false;
            this.btn_chonanh.Click += new System.EventHandler(this.btn_chonAnh_Click);
            // 
            // txt_mamon
            // 
            this.txt_mamon.Enabled = false;
            this.txt_mamon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mamon.Location = new System.Drawing.Point(593, 160);
            this.txt_mamon.Multiline = true;
            this.txt_mamon.Name = "txt_mamon";
            this.txt_mamon.Size = new System.Drawing.Size(454, 48);
            this.txt_mamon.TabIndex = 38;
            // 
            // cbb_loaimon
            // 
            this.cbb_loaimon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_loaimon.FormattingEnabled = true;
            this.cbb_loaimon.Location = new System.Drawing.Point(1438, 169);
            this.cbb_loaimon.Name = "cbb_loaimon";
            this.cbb_loaimon.Size = new System.Drawing.Size(454, 45);
            this.cbb_loaimon.TabIndex = 41;
            // 
            // txt_giaban
            // 
            this.txt_giaban.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_giaban.Location = new System.Drawing.Point(1438, 273);
            this.txt_giaban.Multiline = true;
            this.txt_giaban.Name = "txt_giaban";
            this.txt_giaban.Size = new System.Drawing.Size(454, 48);
            this.txt_giaban.TabIndex = 40;
            // 
            // dgv_thucdon
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thucdon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_thucdon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_thucdon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaMonAn,
            this.TenMonAn,
            this.MaLoaiMonAn,
            this.DuongDanAnh,
            this.TrangThai,
            this.GiaBan});
            this.dgv_thucdon.Location = new System.Drawing.Point(78, 584);
            this.dgv_thucdon.Name = "dgv_thucdon";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_thucdon.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv_thucdon.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_thucdon.RowTemplate.Height = 33;
            this.dgv_thucdon.Size = new System.Drawing.Size(1830, 598);
            this.dgv_thucdon.TabIndex = 62;
            this.dgv_thucdon.SelectionChanged += new System.EventHandler(this.dgv_thucdon_SelectionChanged);
            // 
            // MaMonAn
            // 
            this.MaMonAn.DataPropertyName = "MaMonAn";
            this.MaMonAn.HeaderText = "Mã Món";
            this.MaMonAn.Name = "MaMonAn";
            // 
            // TenMonAn
            // 
            this.TenMonAn.DataPropertyName = "TenMonAn";
            this.TenMonAn.HeaderText = "Tên Món";
            this.TenMonAn.Name = "TenMonAn";
            this.TenMonAn.Width = 250;
            // 
            // MaLoaiMonAn
            // 
            this.MaLoaiMonAn.DataPropertyName = "MaLoaiMonAn";
            this.MaLoaiMonAn.HeaderText = "Loại Món";
            this.MaLoaiMonAn.Name = "MaLoaiMonAn";
            // 
            // DuongDanAnh
            // 
            this.DuongDanAnh.DataPropertyName = "DuongDanAnh";
            this.DuongDanAnh.HeaderText = "Tên Ảnh";
            this.DuongDanAnh.Name = "DuongDanAnh";
            // 
            // TrangThai
            // 
            this.TrangThai.DataPropertyName = "TrangThai";
            this.TrangThai.HeaderText = "Trạng Thái";
            this.TrangThai.Name = "TrangThai";
            // 
            // GiaBan
            // 
            this.GiaBan.DataPropertyName = "GiaBan";
            this.GiaBan.HeaderText = "Giá Bán";
            this.GiaBan.Name = "GiaBan";
            // 
            // btn_them
            // 
            this.btn_them.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Image = ((System.Drawing.Image)(resources.GetObject("btn_them.Image")));
            this.btn_them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_them.Location = new System.Drawing.Point(716, 440);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(231, 78);
            this.btn_them.TabIndex = 49;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = false;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // btn_load
            // 
            this.btn_load.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_load.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_load.Image = ((System.Drawing.Image)(resources.GetObject("btn_load.Image")));
            this.btn_load.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_load.Location = new System.Drawing.Point(1661, 440);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(231, 78);
            this.btn_load.TabIndex = 46;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = false;
            // 
            // btn_sua
            // 
            this.btn_sua.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btn_sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("btn_sua.Image")));
            this.btn_sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_sua.Location = new System.Drawing.Point(1350, 440);
            this.btn_sua.Name = "btn_sua";
            this.btn_sua.Size = new System.Drawing.Size(231, 78);
            this.btn_sua.TabIndex = 45;
            this.btn_sua.Text = "Sữa";
            this.btn_sua.UseVisualStyleBackColor = false;
            this.btn_sua.Click += new System.EventHandler(this.btn_sua_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(1039, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(231, 78);
            this.button2.TabIndex = 44;
            this.button2.Text = "Xóa";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // pt_chonanh
            // 
            this.pt_chonanh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pt_chonanh.Location = new System.Drawing.Point(78, 160);
            this.pt_chonanh.Name = "pt_chonanh";
            this.pt_chonanh.Size = new System.Drawing.Size(286, 254);
            this.pt_chonanh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pt_chonanh.TabIndex = 43;
            this.pt_chonanh.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2510, 139);
            this.panel1.TabIndex = 68;
            // 
            // QL_ThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2505, 1432);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_thucdon);
            this.Controls.Add(this.btn_them);
            this.Controls.Add(this.cbb_trangthai);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_tenmon);
            this.Controls.Add(this.btn_load);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_sua);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pt_chonanh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_chonanh);
            this.Controls.Add(this.txt_mamon);
            this.Controls.Add(this.cbb_loaimon);
            this.Controls.Add(this.txt_giaban);
            this.Name = "QL_ThucDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Mệc Thiệt Chứ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QL_ThucDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_thucdon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pt_chonanh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.ComboBox cbb_trangthai;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_tenmon;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_sua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pt_chonanh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_chonanh;
        private System.Windows.Forms.TextBox txt_mamon;
        private System.Windows.Forms.ComboBox cbb_loaimon;
        private System.Windows.Forms.TextBox txt_giaban;
        private System.Windows.Forms.DataGridView dgv_thucdon;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaLoaiMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DuongDanAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
        private System.Windows.Forms.DataGridViewTextBoxColumn GiaBan;
        private System.Windows.Forms.Panel panel1;
    }
}