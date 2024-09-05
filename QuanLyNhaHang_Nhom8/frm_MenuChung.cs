using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang_Nhom8
{
    
    public partial class frm_MenuChung : Form
    {
        Button currentBtn;
        Panel leftBorderBtn;

        public frm_MenuChung()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 96);
            leftBorderBtn.BackColor = Color.Red; 
            leftBorderBtn.Visible = false; 
            Controls.Add(leftBorderBtn);
            timer1.Start();
        }

        void ActivateButton(Button clickedBtn)
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.White;
                currentBtn.ForeColor = Color.Black;
                //currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            }

            currentBtn = clickedBtn;
            currentBtn.BackColor = Color.FromArgb(173, 216, 230);
            currentBtn.ForeColor = Color.Black;
            currentBtn.TextAlign = ContentAlignment.MiddleLeft;

            leftBorderBtn.Size = new Size(7, currentBtn.Height);
            leftBorderBtn.Location = new Point(currentBtn.Left - leftBorderBtn.Width, currentBtn.Top);
            leftBorderBtn.Visible = true;
        }
        Form activeForm = null;

        void openForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pannel_from.Controls.Add(childForm);
            pannel_from.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btn_ordermn_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_ordermn);
            openForm(new QL_BanAn());
        }

        private void btn_monanmn_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_monanmn);
            openForm(new QL_ThucDon());
        }

        private void btn_khachhangmn_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_khachhangmn);
            openForm(new QL_KhachHang());
        }

        private void btn_nhanvienmn_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_nhanvienmn);
            openForm(new QL_NhanVien());
        }

        private void btn_thongke_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_thongke);
            openForm(new frm_ThongKe());
            
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            DangNhap a = new DangNhap();
            this.Hide();  // Ẩn form hiện tại
            a.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

      
        private void btn_bepbarmn_Click(object sender, EventArgs e)
        {
            ActivateButton(btn_bepbarmn);
            openForm(new frm_BepBar());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_order_Click(object sender, EventArgs e)
        {
            
            openForm(new QL_BanAn());
        }

        private void btn_qltaikhoan_Click(object sender, EventArgs e)
        {
            
            openForm(new QL_TaiKhoan());
        }

        private void btn_quanLyHoaDon_Click(object sender, EventArgs e)
        {
            openForm(new QL_HoaDon());
        }

        private void btn_quanLyThucDon_Click(object sender, EventArgs e)
        {
            openForm(new QL_ThucDon());
        }

        private void btn_thongketrong_Click(object sender, EventArgs e)
        {
            openForm(new frm_ThongKe());
        }

        private void btn_lienHe_Click(object sender, EventArgs e)
        {
            openForm(new frmLienHe());
        }

        private void btn_dangXuat_Click(object sender, EventArgs e)
        {
            DangNhap a = new DangNhap();
            this.Hide();
            a.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frm_MenuChung a = new frm_MenuChung();
            this.Hide();
            a.Show();
        }

        private void frm_MenuChung_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(frm_keydown);
            this.Focus();
            string taikhoan;
            if(Properties.Settings.Default.taikhoan!=null)
            {
                taikhoan=Properties.Settings.Default.taikhoan;
            }else
            {
                taikhoan="";
            }
            lb_chaodn.Text = "Chào Tài Khoản" + taikhoan;
        }
        private void frm_keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {

                btn_ordermn.PerformClick();
            }
            if (e.KeyCode == Keys.F2)
            {

                btn_monanmn.PerformClick();
            }
            if (e.KeyCode == Keys.F3)
            {

                btn_khachhangmn.PerformClick();
            }
            if (e.KeyCode == Keys.F4)
            {

                btn_nhanvienmn.PerformClick();
            }
        }
        


    }
}
