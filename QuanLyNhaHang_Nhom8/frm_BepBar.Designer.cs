namespace QuanLyNhaHang_Nhom8
{
    partial class frm_BepBar
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
            this.dgv_bep = new System.Windows.Forms.DataGridView();
            this.MaChiTietDatMon1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonAn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ramonbep = new System.Windows.Forms.Button();
            this.dgv_bar = new System.Windows.Forms.DataGridView();
            this.MaChiTietDatMon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenMonAn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_ramonbar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_bep
            // 
            this.dgv_bep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bep.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTietDatMon1,
            this.TenMonAn1,
            this.SoLuong1,
            this.GhiChu1});
            this.dgv_bep.Location = new System.Drawing.Point(32, 150);
            this.dgv_bep.Name = "dgv_bep";
            this.dgv_bep.RowTemplate.Height = 33;
            this.dgv_bep.Size = new System.Drawing.Size(960, 847);
            this.dgv_bep.TabIndex = 0;
            this.dgv_bep.SelectionChanged += new System.EventHandler(this.dgv_bep_SelectionChanged);
            // 
            // MaChiTietDatMon1
            // 
            this.MaChiTietDatMon1.DataPropertyName = "MaChiTietDatMon";
            this.MaChiTietDatMon1.HeaderText = "Mã CT";
            this.MaChiTietDatMon1.Name = "MaChiTietDatMon1";
            // 
            // TenMonAn1
            // 
            this.TenMonAn1.DataPropertyName = "TenMonAn";
            this.TenMonAn1.HeaderText = "Tên Món";
            this.TenMonAn1.Name = "TenMonAn1";
            // 
            // SoLuong1
            // 
            this.SoLuong1.DataPropertyName = "SoLuong";
            this.SoLuong1.HeaderText = "Số Lượng";
            this.SoLuong1.Name = "SoLuong1";
            // 
            // GhiChu1
            // 
            this.GhiChu1.DataPropertyName = "GhiChu";
            this.GhiChu1.HeaderText = "Ghi Chú";
            this.GhiChu1.Name = "GhiChu1";
            // 
            // btn_ramonbep
            // 
            this.btn_ramonbep.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ramonbep.Location = new System.Drawing.Point(755, 1027);
            this.btn_ramonbep.Name = "btn_ramonbep";
            this.btn_ramonbep.Size = new System.Drawing.Size(237, 100);
            this.btn_ramonbep.TabIndex = 1;
            this.btn_ramonbep.Text = "Ra Món";
            this.btn_ramonbep.UseVisualStyleBackColor = true;
            this.btn_ramonbep.Click += new System.EventHandler(this.btn_ramonbep_Click);
            // 
            // dgv_bar
            // 
            this.dgv_bar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_bar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaChiTietDatMon,
            this.TenMonAn,
            this.SoLuong,
            this.GhiChu});
            this.dgv_bar.Location = new System.Drawing.Point(23, 150);
            this.dgv_bar.Name = "dgv_bar";
            this.dgv_bar.RowTemplate.Height = 33;
            this.dgv_bar.Size = new System.Drawing.Size(947, 847);
            this.dgv_bar.TabIndex = 2;
            // 
            // MaChiTietDatMon
            // 
            this.MaChiTietDatMon.DataPropertyName = "MaChiTietDatMon";
            this.MaChiTietDatMon.HeaderText = "Mã CT";
            this.MaChiTietDatMon.Name = "MaChiTietDatMon";
            this.MaChiTietDatMon.Width = 70;
            // 
            // TenMonAn
            // 
            this.TenMonAn.DataPropertyName = "TenMonAn";
            this.TenMonAn.HeaderText = "Tên Món";
            this.TenMonAn.Name = "TenMonAn";
            this.TenMonAn.Width = 180;
            // 
            // SoLuong
            // 
            this.SoLuong.DataPropertyName = "SoLuong";
            this.SoLuong.HeaderText = "Số Lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.Width = 80;
            // 
            // GhiChu
            // 
            this.GhiChu.DataPropertyName = "GhiChu";
            this.GhiChu.HeaderText = "Ghi Chú";
            this.GhiChu.Name = "GhiChu";
            // 
            // btn_ramonbar
            // 
            this.btn_ramonbar.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ramonbar.Location = new System.Drawing.Point(733, 1027);
            this.btn_ramonbar.Name = "btn_ramonbar";
            this.btn_ramonbar.Size = new System.Drawing.Size(237, 100);
            this.btn_ramonbar.TabIndex = 3;
            this.btn_ramonbar.Text = "Ra Món";
            this.btn_ramonbar.UseVisualStyleBackColor = true;
            this.btn_ramonbar.Click += new System.EventHandler(this.btn_ramonbar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dgv_bar);
            this.groupBox1.Controls.Add(this.btn_ramonbar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(58, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(989, 1146);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 55);
            this.label1.TabIndex = 4;
            this.label1.Text = "Món Bar";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dgv_bep);
            this.groupBox2.Controls.Add(this.btn_ramonbep);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(1068, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1017, 1146);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(224, 55);
            this.label2.TabIndex = 5;
            this.label2.Text = "Món Bếp";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(733, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(237, 100);
            this.button1.TabIndex = 5;
            this.button1.Text = "Order";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_veNhanVenorder_Click);
            // 
            // frm_BepBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(2585, 1211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_BepBar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frm_BepBar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_BepBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_bar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_bep;
        private System.Windows.Forms.Button btn_ramonbep;
        private System.Windows.Forms.DataGridView dgv_bar;
        private System.Windows.Forms.Button btn_ramonbar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietDatMon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonAn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaChiTietDatMon1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenMonAn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GhiChu1;
        private System.Windows.Forms.Button button1;
    }
}