using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyNhaHang_Nhom8
{
    public partial class QL_TaiKhoan : Form
    {
        string conStr = Properties.Settings.Default.ConStr;
        SqlDataAdapter da_ThongTinTK;
        DataSet ds_ThongTinTK;
        public QL_TaiKhoan()
        {
            da_ThongTinTK = new SqlDataAdapter();
            ds_ThongTinTK = new DataSet();
            InitializeComponent();
        }
        public void Load_TaiKhoan()
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select TenDangNhap,TenHienThi,Email,ChucVu from DangKiTaiKhoan";
                da_ThongTinTK = new SqlDataAdapter(sql, con);
                ds_ThongTinTK.Tables.Clear();
                da_ThongTinTK.Fill(ds_ThongTinTK, "ThongTinTK");
                dgv_qltaikhoan.DataSource = ds_ThongTinTK.Tables["ThongTinTK"];

            }
        }
        private void QL_TaiKhoan_Load(object sender, EventArgs e)
        {
            Load_TaiKhoan();
            dgv_qltaikhoan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgv_qltaikhoan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_qltaikhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow chon = dgv_qltaikhoan.SelectedRows[0];
                txt_taikhoan.Text = chon.Cells["TenDangNhap"].Value.ToString();
                txt_email.Text = chon.Cells["Email"].Value.ToString();
                cbb_chucvu.Text = chon.Cells["ChucVu"].Value.ToString();
                

            }
        }
        CN_DangNhap dn = new CN_DangNhap();
        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_taikhoan.Text!=""&&txt_matkhau.Text!=""&&txt_email.Text!=""&&txt_xacnhanmk.Text!=""&&cbb_chucvu.Text!="")
            {
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select Count(*) From DangKiTaiKhoan Where TenDangNhap='" + txt_taikhoan + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int t = (int)cmd.ExecuteScalar();
                    if(t==1)
                    {
                        MessageBox.Show("Tài Khoản Đã Tồn Tại!", "Thông Báo");
                    }else
                    {
                        if (txt_matkhau.Text != txt_xacnhanmk.Text)
                        {
                            MessageBox.Show("Xác Nhận mật Khẩu Không Đúng", "Thông Báo");
                        }else
                        {
                            string sql1 = "Insert into DangKiTaiKhoan Values('" + txt_taikhoan.Text + "','" +dn.CalculateMD5Hash(txt_matkhau.Text) + "',N'Nhà Hàng Của Di','" + txt_email.Text + "',N'Không Có','" + cbb_chucvu.Text + "')";
                            SqlCommand cmd1 = new SqlCommand(sql1, con);
                            int a = cmd1.ExecuteNonQuery();
                            if(a==1)
                            {
                                MessageBox.Show("Thêm Thành Công", "Thông Báo");
                                Load_TaiKhoan();
                            }else
                            {
                                MessageBox.Show("Thêm Thất Bại", "Thông Báo");
                            }
                        }
                    }
                }
            }
            else 
            {
                MessageBox.Show("Vui Lòng Nhập Đầy Đủ Thông Tin", "Thông Báo");
            }
        }

        private void txt_matkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            txt_matkhau.PasswordChar = '*';
        }

        private void txt_xacnhanmk_TextChanged(object sender, EventArgs e)
        {
            txt_xacnhanmk.PasswordChar = '*';
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (dgv_qltaikhoan.SelectedRows.Count > 0)
            {
                DataGridViewRow chon = dgv_qltaikhoan.SelectedRows[0];
                string tk = chon.Cells["TenDangNhap"].Value.ToString();
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select Count(*) From DangKiTaiKhoan Where TenDangNhap='" + tk + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int t = (int)cmd.ExecuteScalar();
                    if(t==1)
                    {
                        if(txt_matkhau.Text!=""&&txt_xacnhanmk.Text!=""&&txt_email.Text!=""&&cbb_chucvu.Text!="")
                        {
                            if(txt_matkhau.Text!=txt_xacnhanmk.Text)
                            {
                                MessageBox.Show("Xác Nhận Mật Khẩu Sai", "Thông Báo");
                            }else
                            {
                                string sql1 = "Update DangKiTaiKhoan Set MatKhau='" + dn.CalculateMD5Hash(txt_matkhau.Text) + "',Email='" + txt_email.Text + "',ChucVu='" + cbb_chucvu.Text + "' Where TenDangNhap='"+tk+"'";
                                SqlCommand cmd1 = new SqlCommand(sql1, con);
                                int b = cmd1.ExecuteNonQuery();
                                if(b==1)
                                {
                                    MessageBox.Show("Sữa Thành Công", "Thông Báo");
                                    Load_TaiKhoan();
                                }else
                                {
                                    MessageBox.Show("Sữa Không Thành Công", "Thông Báo");
                                }
                            }
                        }else
                        {
                            MessageBox.Show("Không Để Trống Mật Khẩu, Email, Chức Vụ", "Thông Báo");
                        }
                    }else
                    {
                        MessageBox.Show("Tài Khoản Này Không Tồn Tại!", "Thông Báo");
                    }
                }
            }else
            {
                MessageBox.Show("Chọn Tài kHoản Cần Thay Đổi!", "Thông Báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức Năng Xóa Hiện Không Thực Hiện", "Thông Báo");
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            Load_TaiKhoan();
        }
    }
}
