namespace QuanLyNhaHang_Nhom8
{
    partial class frm_ChonBan
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
            this.flowLayoutPanelBan = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelBan
            // 
            this.flowLayoutPanelBan.Location = new System.Drawing.Point(0, 102);
            this.flowLayoutPanelBan.Name = "flowLayoutPanelBan";
            this.flowLayoutPanelBan.Size = new System.Drawing.Size(881, 523);
            this.flowLayoutPanelBan.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(225, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh Sách Bàn Trống";
            // 
            // frm_ChonBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 626);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelBan);
            this.Name = "frm_ChonBan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_ChonBan";
            this.Load += new System.EventHandler(this.frm_ChonBan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBan;
        private System.Windows.Forms.Label label1;
    }
}