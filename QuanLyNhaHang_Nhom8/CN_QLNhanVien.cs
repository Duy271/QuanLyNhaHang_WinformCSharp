using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhaHang_Nhom8
{
    
    class CN_QLNhanVien
    {
        string conStr = Properties.Settings.Default.ConStr;
        private object lockObject = new object();

        public string GenerateMaNhanVien()
        {
            lock (lockObject)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string query = "SELECT TOP 1 MaNhanVien FROM NhanVien ORDER BY MaNhanVien DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();
                    if (result != null)  {
                        int lastNumber = int.Parse(result.ToString().Substring(2));
                        int nextNumber = lastNumber + 1;
                        string newMaNhanVien = string.Format("NV{0:D3}", nextNumber);
                        if (MaNhanVienExists(newMaNhanVien))
                        {
                            nextNumber++;
                            newMaNhanVien = string.Format("NV{0:D3}", nextNumber);
                        }
                        return newMaNhanVien;
                    }
                    else
                    {
                        return "NV001";
                    }
                }
            }
        }


        private bool MaNhanVienExists(string maNhanVien)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }


        public bool ThemNhanVien(string maNV, string tenNV, string soDienThoai, string email, string diaChi, string anhNV, DateTime ngaySinh, string chucVu, string trangThai, string caLam, int soNgayNghi)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string sqlInsertNguoi = "INSERT INTO Nguoi (MaNguoi, Ten, SoDienThoai, Email, DiaChi, NgaySinh) " +
                                            "VALUES (@MaNguoi, @Ten, @SoDienThoai, @Email, @DiaChi, @NgaySinh)";
                    string sqlInsertNhanVien = "INSERT INTO NhanVien (MaNhanVien, MaNguoi, AnhNhanVien, ChucVu, TrangThai, CaLam, SoNgayNghi,Luong) " +
                                               "VALUES (@MaNhanVien, @MaNguoi, @AnhNhanVien, @ChucVu, @TrangThai, @CaLam, @SoNgayNghi,@Luong)";

                    using (SqlCommand cmdNguoi = new SqlCommand(sqlInsertNguoi, con))
                    using (SqlCommand cmdNhanVien = new SqlCommand(sqlInsertNhanVien, con))
                    {
                        double Luong = 0;
                        cmdNguoi.Parameters.AddWithValue("@MaNguoi", maNV);
                        cmdNguoi.Parameters.AddWithValue("@Ten", tenNV);
                        cmdNguoi.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        cmdNguoi.Parameters.AddWithValue("@Email", email);
                        cmdNguoi.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmdNguoi.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmdNguoi.ExecuteNonQuery();

                        // Thêm thông tin vào bảng NhanVien
                        cmdNhanVien.Parameters.AddWithValue("@MaNhanVien", maNV);
                        cmdNhanVien.Parameters.AddWithValue("@MaNguoi", maNV);
                        cmdNhanVien.Parameters.AddWithValue("@AnhNhanVien", anhNV);
                        cmdNhanVien.Parameters.AddWithValue("@ChucVu", chucVu);
                        cmdNhanVien.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmdNhanVien.Parameters.AddWithValue("@CaLam", caLam);
                        cmdNhanVien.Parameters.AddWithValue("@SoNgayNghi", soNgayNghi);
                        cmdNhanVien.Parameters.AddWithValue("@Luong", Luong);
                        cmdNhanVien.ExecuteNonQuery();

                        MessageBox.Show("Thêm nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Xóa

        public void XoaNhanVien(string maNV)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int t;
                int u;
                con.Open();
                string sqlDeleteNhanVien = "DELETE FROM NhanVien WHERE MaNhanVien = @MaNhanVien";
                using (SqlCommand cmdNhanVien = new SqlCommand(sqlDeleteNhanVien, con))
                {
                    cmdNhanVien.Parameters.AddWithValue("@MaNhanVien", maNV);
                    t=cmdNhanVien.ExecuteNonQuery();
                }
                string sqlDeleteNguoi = "DELETE FROM Nguoi WHERE MaNguoi = @MaNguoi";
                using (SqlCommand cmdNguoi = new SqlCommand(sqlDeleteNguoi, con))
                {
                    cmdNguoi.Parameters.AddWithValue("@MaNguoi", maNV);
                    u=cmdNguoi.ExecuteNonQuery();
                }
                if(t==1&&u==1)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Bóa" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        //sữa
        public bool SuaNhanVien(string maNV, string tenNV, string soDienThoai, string email, string diaChi, string anhNV, DateTime ngaySinh, string chucVu, string trangThai, string caLam, int soNgayNghi)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Thực hiện câu lệnh INSERT vào cơ sở dữ liệu
                    string sqlUpdateNguoi = "UPDATE Nguoi SET Ten = @Ten, SoDienThoai = @SoDienThoai, Email = @Email, DiaChi = @DiaChi, NgaySinh = @NgaySinh WHERE MaNguoi = @MaNguoi";
                    string sqlUpdateNhanVien = "UPDATE NhanVien SET AnhNhanVien = @AnhNhanVien, ChucVu = @ChucVu, TrangThai = @TrangThai, CaLam = @CaLam, SoNgayNghi = @SoNgayNghi WHERE MaNhanVien = @MaNhanVien";

                    using (SqlCommand cmdNguoi = new SqlCommand(sqlUpdateNguoi, con))
                    using (SqlCommand cmdNhanVien = new SqlCommand(sqlUpdateNhanVien, con))
                    {
                        // Tạo mã người và mã nhân viên

                        double Luong = 0;

                        // Thêm thông tin vào bảng Nguoi
                        cmdNguoi.Parameters.AddWithValue("@MaNguoi", maNV);
                        cmdNguoi.Parameters.AddWithValue("@Ten", tenNV);
                        cmdNguoi.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        cmdNguoi.Parameters.AddWithValue("@Email", email);
                        cmdNguoi.Parameters.AddWithValue("@DiaChi", diaChi);
                        cmdNguoi.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                        cmdNguoi.ExecuteNonQuery();

                        // Thêm thông tin vào bảng NhanVien
                        cmdNhanVien.Parameters.AddWithValue("@MaNhanVien", maNV);
                        cmdNhanVien.Parameters.AddWithValue("@MaNguoi", maNV);
                        cmdNhanVien.Parameters.AddWithValue("@AnhNhanVien", anhNV);
                        cmdNhanVien.Parameters.AddWithValue("@ChucVu", chucVu);
                        cmdNhanVien.Parameters.AddWithValue("@TrangThai", trangThai);
                        cmdNhanVien.Parameters.AddWithValue("@CaLam", caLam);
                        cmdNhanVien.Parameters.AddWithValue("@SoNgayNghi", soNgayNghi);
                        cmdNhanVien.Parameters.AddWithValue("@Luong", Luong);
                        cmdNhanVien.ExecuteNonQuery();

                        MessageBox.Show("Cập nhật nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //Tìm mã ảnh để xóa
        public string tenAnh(string manv)
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                con.Open();
                
                string sql = "Select AnhNhanVien from NhanVien where MaNhanVien='" + manv + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                string anh =cmd.ExecuteScalar().ToString();
                
                return anh;


               
            }
        }
    }
}
