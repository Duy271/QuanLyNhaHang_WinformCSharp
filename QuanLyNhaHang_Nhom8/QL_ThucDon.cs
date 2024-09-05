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
    public partial class QL_ThucDon : Form
    {
        private bool AnhDaThayDoi = false;
        private DataSet ds_ThongTinMA;

        private SqlDataAdapter da_ThongTinMA;
        string conStr = Properties.Settings.Default.ConStr;
        CN_QLThucDon qltd = new CN_QLThucDon();

        public QL_ThucDon()
        {
            ds_ThongTinMA = new DataSet();
            da_ThongTinMA = new SqlDataAdapter();
            InitializeComponent();
        }

        private void QL_ThucDon_Load(object sender, EventArgs e)
        {
            LoadThongTinMA();
            dgv_thucdon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        //
        private void LoadThongTinMA()
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string sql = "select *from ThucDon";
                da_ThongTinMA = new SqlDataAdapter(sql, con);
                da_ThongTinMA.Fill(ds_ThongTinMA, "ThongTinMA");
                if (!ds_ThongTinMA.Tables["ThongTinMA"].Columns.Contains("Anh"))
                {
                    // Thêm cột mới có tên "Anh" kiểu byte[] vào DataTable
                    DataColumn imageColumn = new DataColumn("Anh", typeof(byte[]));
                    ds_ThongTinMA.Tables["ThongTinMA"].Columns.Add(imageColumn);

                    // Đọc dữ liệu từ cột DuongDanAnh, chuyển thành byte[] và lưu vào cột Anh
                    foreach (DataRow row in ds_ThongTinMA.Tables["ThongTinMA"].Rows)
                    {
                        string imageName = row["DuongDanAnh"].ToString();
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            string imagePath = Path.Combine("..\\..\\Images\\thucdon", imageName);
                            if (File.Exists(imagePath))
                            {
                                byte[] imageData = File.ReadAllBytes(imagePath);
                                row["Anh"] = imageData;
                               
                            }
                        }
                    }
                }else
                {
                    foreach (DataRow row in ds_ThongTinMA.Tables["ThongTinMA"].Rows)
                    {
                        string imageName = row["DuongDanAnh"].ToString();
                        if (!string.IsNullOrEmpty(imageName))
                        {
                            string imagePath = Path.Combine("..\\..\\Images\\thucdon", imageName);
                            if (File.Exists(imagePath))
                            {
                                byte[] imageData = File.ReadAllBytes(imagePath);
                                row["Anh"] = imageData;
                                
                            }
                        }
                    }
                }
              

                dgv_thucdon.DataSource = ds_ThongTinMA.Tables["ThongTinMA"];
                con.Close();
            }
        }
        public string mama;

        private void dgv_thucdon_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv_thucdon.SelectedRows.Count > 0)
            {
                DataGridViewRow slr = dgv_thucdon.SelectedRows[0];
                mama = slr.Cells["MaMonAn"].Value.ToString();
                txt_mamon.Text = mama;
                txt_tenmon.Text = slr.Cells["TenMonAn"].Value.ToString();
                cbb_loaimon.Text = slr.Cells["MaLoaiMonAn"].Value.ToString();
                cbb_trangthai.Text = slr.Cells["TrangThai"].Value.ToString();

                string anhma = slr.Cells["DuongDanAnh"].Value.ToString();
                if (!string.IsNullOrEmpty(anhma))
                {
                    // Đường dẫn đầy đủ đến file ảnh
                    string imagePath = Path.Combine("..\\..\\Images\\thucdon", anhma);

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

                txt_giaban.Text = slr.Cells["GiaBan"].Value.ToString();
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

        private string CopyVaLuuAnh(string maMA)
        {
            DataGridViewRow selectedRow = dgv_thucdon.SelectedRows[0];
            string anhnguon = selectedRow.Cells["DuongDanAnh"].Value.ToString();
            maMA = maMA.Trim();
            // Đường dẫn đầy đủ đến file ảnh trong thư mục "people"
            string fullPath = Path.Combine("..\\..\\Images\\thucdon", maMA + ".jpg");

            // Lấy hình ảnh từ PictureBox
            Image imageFromPictureBox = pt_chonanh.Image;

            // Kiểm tra xem PictureBox có hình ảnh hay không
            if (imageFromPictureBox != null)
            {

                // Lưu hình ảnh từ PictureBox vào thư mục "people"
                imageFromPictureBox.Save(fullPath, ImageFormat.Jpeg);

                // Trả về tên file ảnh (mã nhân viên + ".jpg") để lưu vào cơ sở dữ liệu
                return maMA + ".jpg";
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
            string mama = qltd.GenerateMaMonAn();

            string tenMA = txt_tenmon.Text;
            string MaLoai = cbb_loaimon.Text;


            string anhMA = CopyVaLuuAnh(mama); // Bạn cần cung cấp đường dẫn đến ảnh thực tế ở đây
            if (anhMA == null)
            {
                anhMA = "dauhu.jpg";
            }
            string TrangThai = cbb_trangthai.Text;
            double Gia = double.Parse(txt_giaban.Text);
            qltd.ThemMonAn(mama, tenMA, MaLoai, anhMA, TrangThai, Gia);
            ds_ThongTinMA.Tables["ThongTinMA"].Rows.Clear();

            LoadThongTinMA();
            

        }


        private void XoaAnhMonAn(string maMA)
        {
            try
            {
                maMA = maMA.Trim();

                // Xác định đường dẫn đầy đủ đến file ảnh
                string fullPath = Path.Combine("..\\..\\Images\\thucdon", maMA);

                // Kiểm tra xem file ảnh có tồn tại không trước khi xóa
                if (File.Exists(fullPath))
                {
                    // Giải phóng tài nguyên hình ảnh (nếu có)
                    if (pt_chonanh.Image != null)
                    {
                        pt_chonanh.Image.Dispose();
                    }

                    // Xóa ảnh từ thư mục 
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
            
            if (dgv_thucdon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_thucdon.SelectedRows[0];
                int t=0;
                using(SqlConnection con=new SqlConnection(conStr))
                {
                    con.Open();
                    string sql = "Select Count(*) From ThucDon";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    t = (int)cmd.ExecuteScalar();
                }
                if(t>1)
                {

                    string maMA = selectedRow.Cells["MaMonAn"].Value.ToString();
                    //string checkMa = maMA.Substring(1);
                    //int ma = int.Parse(checkMa);
                    //if(ma>0&&ma<=12)
                    //{ }
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        con.Open();
                        string sqlxct = "Update ThucDon Set TrangThai='Het' Where MaMonAn='"+maMA+"'";
                        SqlCommand cmd = new SqlCommand(sqlxct, con);
                        cmd.ExecuteNonQuery();
                        ds_ThongTinMA.Tables["ThongTinMA"].Clear();
                        LoadThongTinMA();

                    }
                    

                    //string anh = qltd.tenAnh(maMA);

                    //// Xóa ảnh từ thư mục "people"
                    //XoaAnhMonAn(anh);
                    //// Xóa dữ liệu từ cơ sở dữ liệu
                    //qltd.XoaMonAn(maMA);


                    //ds_ThongTinMA.Tables["ThongTinMA"].Rows.Clear();

                    // Load lại dữ liệu vào DataGridView
                    
                }else
                {
                    MessageBox.Show("Chỉ Còn 1 Món Nên Không Thể Xóa", "Thông Báo");
                }
               
                
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {

            if (dgv_thucdon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_thucdon.SelectedRows[0];
                string maMA = selectedRow.Cells["MaMonAn"].Value.ToString().Trim();

                // Lấy dữ liệu từ các TextBox và PictureBox
                string tenMA = txt_tenmon.Text;
                string MaLoai = cbb_loaimon.Text;
                string TrangThai = cbb_trangthai.Text;
                double Gia = double.Parse(txt_giaban.Text);


                // Kiểm tra xem có ảnh mới được chọn hay không và xem ảnh đã thay đổi hay chưa
                if (AnhDaThayDoi)
                {

                    // Lưu ảnh mới vào thư mục "people"
                    string anhMA = CopyVaLuuAnhMoi(maMA);

                    


                    // Cập nhật thông tin nhân viên
                    qltd.SuaMonAn(maMA, tenMA, MaLoai, anhMA, TrangThai, Gia);
                    ds_ThongTinMA.Tables["ThongTinMA"].Rows.Clear();
                    // Load lại dữ liệu vào DataGridView
                    LoadThongTinMA();

                }
                else
                {

                    ds_ThongTinMA.Tables["ThongTinMA"].Rows.Clear();


                    // Cập nhật thông tin nhân viên
                    qltd.SuaMonAn(maMA, tenMA, MaLoai, qltd.tenAnh(maMA), TrangThai, Gia);

                    // Load lại dữ liệu vào DataGridView
                    LoadThongTinMA();
                }
            }
        }
        private string CopyVaLuuAnhMoi(string maMA)
        {
            DataGridViewRow selectedRow = dgv_thucdon.SelectedRows[0];
            string anhCuPath = selectedRow.Cells["DuongDanAnh"].Value.ToString();
            maMA = maMA.Trim();

            // Đường dẫn đầy đủ đến thư mục "people"
            string peopleFolderPath = Path.Combine("..\\..\\Images\\thucdon");

            // Tạo tên tệp mới để tránh xung đột
            string tenTepMoi = GetTenTepMoi(maMA, peopleFolderPath);

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

        private string GetTenTepMoi(string maMA, string folderPath)
        {
            // Tạo tên tệp mới bằng cách sử dụng GUID
            string tenTepMoi = maMA + "_" + Guid.NewGuid() + ".jpg";

            // Kiểm tra xem tên tệp đã tồn tại chưa, nếu có thì đổi tên
            while (File.Exists(Path.Combine(folderPath, tenTepMoi)))
            {
                tenTepMoi = maMA + "_" + Guid.NewGuid() + ".jpg";
            }

            return tenTepMoi;
        }


    }
}
