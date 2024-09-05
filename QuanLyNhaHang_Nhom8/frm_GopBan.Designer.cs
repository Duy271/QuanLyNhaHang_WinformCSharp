namespace QuanLyNhaHang_Nhom8
{
    partial class frm_GopBan
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
            this.SuspendLayout();
            // 
            // flowLayoutPanelBan
            // 
            this.flowLayoutPanelBan.Location = new System.Drawing.Point(1, 120);
            this.flowLayoutPanelBan.Name = "flowLayoutPanelBan";
            this.flowLayoutPanelBan.Size = new System.Drawing.Size(887, 559);
            this.flowLayoutPanelBan.TabIndex = 0;
            // 
            // frm_GopBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 677);
            this.Controls.Add(this.flowLayoutPanelBan);
            this.Name = "frm_GopBan";
            this.Text = "frm_GopBan";
            this.Load += new System.EventHandler(this.frm_GopBan_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBan;
    }
}