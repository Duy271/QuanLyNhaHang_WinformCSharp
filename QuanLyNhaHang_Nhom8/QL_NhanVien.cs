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
using System.Drawing.Imaging;
using System.IO;
using System.Threading;

namespace QuanLyNhaHang_Nhom8
{
    public partial class QL_NhanVien : Form
    {

        private bool AnhDaThayDoi = false;
        private DataSet ds_ThongTinNV;
      
        private SqlDataAdapter da_ThongTinNV;
        string conStr = Properties.Settings.Default.ConStr;
        CN_QLNhanVien qlnv = new CN_QLNhanVien();
        public QL_NhanVien()
        {
            ds_ThongTinNV = new DataSet();
            da_ThongTinNV = new SqlDataAdapter();
            InitializeComponent();
        }

        private void QL_NhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTinNV();
            dgv_thongtinnv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadThongTinNV()
        {
           
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                
                string sql = "SELECT  NV.MaNhanVien, NV.AnhNhanVien, NG.Ten,NG.SoDienThoai,NG.Email,NG.DiaChi,NG.NgaySinh,NV.ChucVu,NV.TrangThai,NV.CaLam,NV.SoNgayNghi FROM Nguoi NG,NhanVien NV WHERE NV.MaNguoi = NG.MaNguoi";
                da_ThongTinNV = new SqlDataAdapter(sql, con);
                da_ThongTinNV.Fill(ds_ThongTinNV, "ThongTinNV");
                dgv_thongtinnv.DataSource = ds_ThongTinNV.Tables["ThongTinNV"];
                con.Close();
            }
        }
        public string manv;
        
        private void dgv_thongtinnv_SelectionChanged(object sender, EventArgs e)
        {
            if(dgv_thongtinnv.SelectedRows.Count>0)
            {
                DataGridViewRow slr = dgv_thongtinnv.SelectedRows[0];
                manv = slr.Cells["MaNhanVien"].Value.ToString();
                txt_tennv.Text = slr.Cells["Ten"].Value.ToString();
                txt_sdt.Text = slr.Cells["SoDienThoai"].Value.ToString();
                txt_email.Text = slr.Cells["Email"].Value.ToString();
                txt_diachi.Text = slr.Cells["DiaChi"].Value.ToString();
                string anhnv = slr.Cells["AnhNhanVien"].Value.ToString();
                if (!string.IsNullOrEmpty(anhnv))
                {
                    // Đường dẫn đầy đủ đến file ảnh
                    string imagePath = Path.Combine("..\\..\\Images\\people", anhnv);

                    // Kiểm tra xem file ảnh có tồn tại không
                    if (File.Exists(imagePath))
                    {
                        // Hiển thị ảnh lên PictureBox

                        pt_chonanh.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        // Xử lý trường hợp file ảnh không tồn tại
                        MessageBox.Show("File ảnh không tồn tại.");
                    }
                }
                else
                {
                    // Xử lý trường hợp tên file ảnh trống rỗng
                    MessageBox.Show("Tên file ảnh không hợp lệ.");
                }
                date_ngaysinh.Text = slr.Cells["NgaySinh"].Value.ToString();
                cbb_chucvu.Text = slr.Cells["ChucVu"].Value.ToString();
                cbb_trangthai.Text = slr.Cells["TrangThai"].Value.ToString();
                cbb_calam.Text = slr.Cells["CaLam"].Value.ToString();
                txt_songaynghi.Text = slr.Cells["SoNgayNghi"].Value.ToString();
                AnhDaThayDoi = false;
            }
        }

        private void btn_chonAnh_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp; *.jpg; *.jpeg; *.png)|*.bmp;*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
                openFileDialog.Title = "Chọn ảnh";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Hiển thị ảnh đã chọn trong PictureBox
                        pt_chonanh.Image = Image.FromFile(openFileDialog.FileName);
                        AnhDaThayDoi = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở tệp ảnh: " + ex.Message);
                    }
                }
            }


        }

        private string CopyVaLuuAnh(string maNV)
        {
            DataGridViewRow selectedRow = dgv_thongtinnv.SelectedRows[0];
            string anhnguon=selectedRow.Cells["AnhNhanVien"].Value.ToString();
            maNV = maNV.Trim();
            // Đường dẫn đầy đủ đến file ảnh trong thư mục "people"
            string fullPath = Path.Combine("..\\..\\Images\\people", maNV + ".jpg");

            // Lấy hình ảnh từ PictureBox
            Image imageFromPictureBox = pt_chonanh.Image;

            // Kiểm tra xem PictureBox có hình ảnh hay không
            if (imageFromPictureBox != null)
            {
                
                // Lưu hình ảnh từ PictureBox vào thư mục "people"
                imageFromPictureBox.Save(fullPath, ImageFormat.Jpeg);

                // Trả về tên file ảnh (mã nhân viên + ".jpg") để lưu vào cơ sở dữ liệu
                return maNV + ".jpg";
            }
            else
            {
                // Trả về tên file ảnh cũ nếu không có hình ảnh mới
                return anhnguon;
            }
        }




        private void btn_them_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các TextBox và PictureBox
            string manv = qlnv.GenerateMaNhanVien();
            string tenNV = txt_tennv.Text;
            string soDienThoai = txt_sdt.Text;
            string email = txt_email.Text;
            string diaChi = txt_diachi.Text;
            string chucVu = cbb_chucvu.Text;
            string trangThai = cbb_trangthai.Text;
            string caLam = cbb_calam.Text;
            int soNgayNghi=int.Parse(txt_songaynghi.Text);
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Select Count(*) From Nguoi Where SoDienThoai='" + soDienThoai + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                int t = (int)cmd.ExecuteScalar();
                if(t==0)
                {
                   
                    
                    string anhNV=null;
                 
                    anhNV = CopyVaLuuAnh(manv);
                 
                    // Bạn cần cung cấp đường dẫn đến ảnh thực tế ở đây
                    if (anhNV == null)
                    {
                        anhNV = "avt.jpg";
                    }
                    DateTime ngaySinh;
                    DateTime.TryParse(date_ngaysinh.Text, out ngaySinh);
                    // Các giá trị khác...

                    //string maNV, string tenNV, string soDienThoai, string email, string diaChi, string anhNV, DateTime ngaySinh, string chucVu, string trangThai, string caLam, int soNgayLam
                    qlnv.ThemNhanVien(manv, tenNV, soDienThoai, email, diaChi, anhNV, ngaySinh, chucVu, trangThai, caLam, soNgayNghi);
                    ds_ThongTinNV.Tables["ThongTinNV"].Clear();
                    LoadThongTinNV();
                }else
                {
                    MessageBox.Show("Số Điện Thoại Đã Tồn Tại", "Thông Báo");
                }
            }
           
        }

        //Xóa
        private void XoaAnhNhanVien(string maNV)
        {
            try
            {
                maNV = maNV.Trim();

                // Xác định đường dẫn đầy đủ đến file ảnh
                string fullPath = Path.Combine("..\\..\\Images\\people", maNV);

                // Kiểm tra xem file ảnh có tồn tại không trước khi xóa
                if (File.Exists(fullPath))
                {
                    // Giải phóng tài nguyên hình ảnh (nếu có)
                    if (pt_chonanh.Image != null)
                    {
                        pt_chonanh.Image.Dispose();
                    }

                    // Xóa ảnh từ thư mục "people"
                    File.Delete(fullPath);

                    // Thông báo xóa thành công
                    //MessageBox.Show("Xóa ảnh thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("File ảnh không tồn tại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        


        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (dgv_thongtinnv.SelectedRows.Count > 0)
            {
                int t = 0;
                DataGridViewRow selectedRow = dgv_thongtinnv.SelectedRows[0];
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select Count(*) From NhanVien";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    t = (int)cmd.ExecuteScalar();
                }
                if(t>1)
                {
                    string maNV = selectedRow.Cells["MaNhanVien"].Value.ToString();

                    string anh = qlnv.tenAnh(maNV);

                    // Xóa ảnh từ thư mục "people"
                    XoaAnhNhanVien(anh);
                    // Xóa dữ liệu từ cơ sở dữ liệu
                    qlnv.XoaNhanVien(maNV);


                    ds_ThongTinNV.Tables["ThongTinNV"].Clear();
                    // Load lại dữ liệu vào DataGridView
                    LoadThongTinNV();
                }else
                {
                    MessageBox.Show("Chỉ Còn 1 Nhân Viên Nên Không Thể Xóa!", "Thông Báo");
                }
                // Lấy mã nhân viên cần xóa
                
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (dgv_thongtinnv.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_thongtinnv.SelectedRows[0];
                string maNV = selectedRow.Cells["MaNhanVien"].Value.ToString().Trim();

                // Lấy dữ liệu từ các TextBox và PictureBox
                string tenNV = txt_tennv.Text;
                string soDienThoai = txt_sdt.Text;
                string email = txt_email.Text;
                string diaChi = txt_diachi.Text;
                string chucVu = cbb_chucvu.Text;
                string trangThai = cbb_trangthai.Text;
                string caLam = cbb_calam.Text;
                int soNgayNghi = int.Parse(txt_songaynghi.Text);

                // Kiểm tra xem có ảnh mới được chọn hay không và xem ảnh đã thay đổi hay chưa
                if (AnhDaThayDoi)
                {
                    DateTime ngaySinh;
                    DateTime.TryParse(date_ngaysinh.Text, out ngaySinh);
                    string anh = qlnv.tenAnh(maNV);
                    MessageBox.Show(anh, "TT");
                    // Lưu ảnh mới vào thư mục "people"
                    string anhNV = CopyVaLuuAnhMoi(maNV);
                    
                    ds_ThongTinNV.Tables["ThongTinNV"].Clear();

                    // Cập nhật thông tin nhân viên
                    qlnv.SuaNhanVien(maNV, tenNV, soDienThoai, email, diaChi, anhNV, ngaySinh, chucVu, trangThai, caLam, soNgayNghi);
                   
                    // Load lại dữ liệu vào DataGridView
                    LoadThongTinNV();
                   
                }
                else
                {
                    DateTime ngaySinh;
                    DateTime.TryParse(date_ngaysinh.Text, out ngaySinh);
                    ds_ThongTinNV.Tables["ThongTinNV"].Clear();

                    // Cập nhật thông tin nhân viên
                    qlnv.SuaNhanVien(maNV, tenNV, soDienThoai, email, diaChi, qlnv.tenAnh(maNV), ngaySinh, chucVu, trangThai, caLam, soNgayNghi);

                    // Load lại dữ liệu vào DataGridView
                    LoadThongTinNV();
                }
            }
        }
        private string CopyVaLuuAnhMoi(string maNV)
        {
            DataGridViewRow selectedRow = dgv_thongtinnv.SelectedRows[0];
            string anhCuPath = selectedRow.Cells["AnhNhanVien"].Value.ToString();
            maNV = maNV.Trim();

            // Đường dẫn đầy đủ đến thư mục "people"
            string peopleFolderPath = Path.Combine("..\\..\\Images\\people");

            // Tạo tên tệp mới để tránh xung đột
            string tenTepMoi = GetTenTepMoi(maNV, peopleFolderPath);

            // Đường dẫn đầy đủ đến file ảnh mới trong thư mục "people"
            string fullPath = Path.Combine(peopleFolderPath, tenTepMoi);

            // Lấy hình ảnh từ PictureBox
            Image imageFromPictureBox = pt_chonanh.Image;

            // Kiểm tra xem PictureBox có hình ảnh hay không
            if (imageFromPictureBox != null)
            {
                // Lưu hình ảnh từ PictureBox vào thư mục "people"
                imageFromPictureBox.Save(fullPath, ImageFormat.Jpeg);

                // Trả về tên file ảnh mới để lưu vào cơ sở dữ liệu
                return tenTepMoi;
            }
            else
            {
                // Trả về tên file ảnh cũ nếu không có hình ảnh mới
                return anhCuPath;
            }
        }

        private string GetTenTepMoi(string maNV, string folderPath)
        {
            // Tạo tên tệp mới bằng cách sử dụng GUID
            string tenTepMoi = maNV + "_" + Guid.NewGuid() + ".jpg";

            // Kiểm tra xem tên tệp đã tồn tại chưa, nếu có thì đổi tên
            while (File.Exists(Path.Combine(folderPath, tenTepMoi)))
            {
                tenTepMoi = maNV + "_" + Guid.NewGuid() + ".jpg";
            }

            return tenTepMoi;
        }




        //chặn
       

    }
}
