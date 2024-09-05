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
    public partial class QL_KhachHang : Form
    {
        CN_QLKhachHang qlkh = new CN_QLKhachHang();
        string conStr;
        SqlDataAdapter da_ThongTinKH;
        DataSet ds_ThongTinKH;

        public QL_KhachHang()
        {
            conStr = Properties.Settings.Default.ConStr;
            da_ThongTinKH = new SqlDataAdapter();
            ds_ThongTinKH = new DataSet();
            InitializeComponent();
        }

        public void Load_ThongTinKhachHang()
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select MaKhachHang,Ten, SoDienThoai,Email,DiaChi,NgaySinh,Loai from Nguoi,KhachHang Where KhachHang.MaNguoi=Nguoi.MaNguoi";
                da_ThongTinKH = new SqlDataAdapter(sql, con);
                da_ThongTinKH.Fill(ds_ThongTinKH, "ThongTinKH");
                dgv_khachhang.DataSource = ds_ThongTinKH.Tables["ThongTinKH"];
            }
        }

        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            Load_ThongTinKhachHang();
            dgv_khachhang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

       

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txt_tenkh.Text==""||txt_email.Text==""||txt_dt.Text==""||txt_diachi.Text==""||cbb_loai.Text==""||date_ngaysinh.Text=="")
            {
                MessageBox.Show("Nhập Đầy Đủ Thông Tin!", "Thông Báo");
                return;
            }else
            {

                string ten=txt_tenkh.Text;
                string diachi=txt_diachi.Text;
                string email=txt_email.Text;
                string dienthoai=txt_dt.Text;
                DateTime ngaysinh;
                DateTime.TryParse(date_ngaysinh.Text,out ngaysinh);
                string loai=cbb_loai.Text;
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select Count(*) From Nguoi Where SoDienThoai='" + dienthoai + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int a = (int)cmd.ExecuteScalar();
                    if (a == 0)
                    {
                        int t = qlkh.themKhachHang(ten, dienthoai, email, diachi, ngaysinh, loai);
                        if (t != 1)
                        {
                            MessageBox.Show("Thêm Thất Bại!", "Thông Báo");
                        }
                        ds_ThongTinKH.Tables["ThongTinKH"].Clear();
                        Load_ThongTinKhachHang();
                    }
                    else 
                    {
                        MessageBox.Show("Số Điện Thoại Đã Tồn Tại!", "Thông Báo");
                    }
                }
            }
           
        }

        private void dgv_khachhang_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_khachhang.SelectedRows.Count > 0)
            {
                DataGridViewRow chon = dgv_khachhang.SelectedRows[0];
                txt_tenkh.Text = chon.Cells["Ten"].Value.ToString();
                txt_email.Text = chon.Cells["Email"].Value.ToString();
                txt_dt.Text = chon.Cells["SoDienThoai"].Value.ToString();
                date_ngaysinh.Text = chon.Cells["NgaySinh"].Value.ToString();
                txt_diachi.Text = chon.Cells["DiaChi"].Value.ToString();
                cbb_loai.Text = chon.Cells["Loai"].Value.ToString();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(dgv_khachhang.SelectedRows.Count>0)
            {
                
                DataGridViewRow chon = dgv_khachhang.SelectedRows[0];
                string makh = chon.Cells["MaKhachHang"].Value.ToString();
                string sql = "Delete From KhachHang Where MaKhachHang='" + makh + "'";
                string sql1 = "Delete from Nguoi Where MaNguoi='" + makh + "'";
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))        
                    using(SqlCommand cmd1 = new SqlCommand(sql1, con))
                    {
                        cmd.ExecuteNonQuery();
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show("Xóa Khách Hàng Thành Công!", "Thông Báo");
                        ds_ThongTinKH.Tables["ThongTinKH"].Clear();
                        Load_ThongTinKhachHang();
                    }
                    

                }
                
            }else
            {
                MessageBox.Show("Vui Lòng Chọn Khách Hàng Để Xóa", "Thông Báo");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txt_tenkh.Text == "" || txt_email.Text == "" || txt_dt.Text == "" || txt_diachi.Text == "" || cbb_loai.Text == "" || date_ngaysinh.Text == "")
            {
                MessageBox.Show("Nhập Đầy Đủ Thông Tin!", "Thông Báo");
                return;
            }
            else
            {
                DataGridViewRow chon = dgv_khachhang.SelectedRows[0];
                string makh = chon.Cells["MaKhachHang"].Value.ToString();
                string ten = txt_tenkh.Text;
                string diachi = txt_diachi.Text;
                string email = txt_email.Text;
                string dienthoai = txt_dt.Text;
                DateTime ngaysinh;
                DateTime.TryParse(date_ngaysinh.Text, out ngaysinh);
                string loai = cbb_loai.Text;
                int t = qlkh.capNhatKhachhang(makh, dienthoai, ten, email, diachi, ngaysinh, loai);
                if (t != 1)
                {
                    MessageBox.Show("Cập Nhật Thất Bại!", "Thông Báo");
                }
                ds_ThongTinKH.Tables["ThongTinKH"].Clear();
                Load_ThongTinKhachHang();
            }
        }

        private void btn_timsdt_Click(object sender, EventArgs e)
        {
            ds_ThongTinKH.Tables["ThongTinKH"].Clear(); // Xóa dữ liệu trong DataTable

            // Gán lại DataTable cho DataSource để làm mới DataGridView
            dgv_khachhang.DataSource = ds_ThongTinKH.Tables["ThongTinKH"];
            if(txt_tim.Text=="")
            {
                MessageBox.Show("Vui Lòng Nhập Số Điện Thoại!", "Thông Báo");
            }else
            {
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select MaKhachHang,Ten,SoDienThoai,Email,DiaChi,NgaySinh,Loai From KhachHang,Nguoi Where KhachHang.MaNguoi=Nguoi.MaNguoi AND SoDienThoai='" + txt_tim.Text + "'";
                    da_ThongTinKH = new SqlDataAdapter(sql, con);
                    da_ThongTinKH.Fill(ds_ThongTinKH, "ThongTinKH");
                    dgv_khachhang.DataSource = ds_ThongTinKH.Tables["ThongTinKH"];
                }
            }
        }
    }
}
