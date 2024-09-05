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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        CN_DangNhap dn = new CN_DangNhap();
        private void btn_dangnhap_Click(object sender, EventArgs e)
        {
            if (dn.Chk_DangNhap(txt_taikhoan.Text, dn.CalculateMD5Hash(txt_matkhau.Text)) == 0)
            {

                tb_dangnhap.Text = "Tài Khoản Không Tồn Tại!";
            }
            if (dn.Chk_DangNhap(txt_taikhoan.Text, dn.CalculateMD5Hash(txt_matkhau.Text)) == 1)
            {
                tb_dangnhap.Text = "Mật Khẩu Không Chính Xác!";
            }
            if (dn.Chk_DangNhap(txt_taikhoan.Text, dn.CalculateMD5Hash(txt_matkhau.Text)) == 2 && dn.Lay_Role(txt_taikhoan.Text) == "admin")
            {
                if (checkBox1.Checked)
                {
                    Properties.Settings.Default.taikhoan = null;
                    Properties.Settings.Default.matkhau = null;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.taikhoan = null;
                    Properties.Settings.Default.matkhau = null;
                    Properties.Settings.Default.Save();
                }
                Properties.Settings.Default.taikhoanchung = txt_taikhoan.Text;
                Properties.Settings.Default.Save();
                frm_MenuChung a = new frm_MenuChung();
                this.Hide();
                a.Show();
            }
            if (dn.Chk_DangNhap(txt_taikhoan.Text, dn.CalculateMD5Hash(txt_matkhau.Text)) == 2 && dn.Lay_Role(txt_taikhoan.Text) == "user")
            {
                if (checkBox1.Checked)
                {
                    Properties.Settings.Default.taikhoan = txt_taikhoan.Text;
                    Properties.Settings.Default.matkhau = txt_matkhau.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.taikhoan = null;
                    Properties.Settings.Default.matkhau = null;
                    Properties.Settings.Default.Save();
                }
                Properties.Settings.Default.taikhoannhanvien = txt_taikhoan.Text;
                Properties.Settings.Default.Save();
                OderNhanVien a = new OderNhanVien();
                this.Hide();
                a.Show();

            }

        }

        private void txt_matkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_matkhau.PasswordChar = '*';
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txt_taikhoan.Text = Properties.Settings.Default.taikhoan;
            string mk=Properties.Settings.Default.matkhau;
            txt_matkhau.Text = mk;
            txt_matkhau.PasswordChar = '*';
            
        }
    }
}
