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
    class CN_QLKhachHang
    {
        string conStr = Properties.Settings.Default.ConStr;
        private object lockObject = new object();

        public string GenerateKhachHang()
        {
            lock (lockObject)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để lấy mã nhân viên cuối cùng từ CSDL
                    string query = "SELECT TOP 1 MaKhachHang FROM KhachHang ORDER BY MaKhachHang DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null) // Nếu có mã nhân viên cuối cùng
                    {
                        // Trích xuất số từ mã nhân viên cuối cùng và tăng giá trị
                        int lastNumber = int.Parse(result.ToString().Substring(2));
                        int nextNumber = lastNumber + 1;

                        // Tạo mã nhân viên mới
                        string newMaNhanVien = string.Format("KH{0:D3}", nextNumber);

                        // Kiểm tra xem mã nhân viên mới đã tồn tại chưa
                        if (MaKhachHangExists(newMaNhanVien))
                        {
                            // Nếu đã tồn tại, tăng giá trị và kiểm tra lại
                            nextNumber++;
                            newMaNhanVien = string.Format("KH{0:D3}", nextNumber);
                        }

                        return newMaNhanVien;
                    }
                    else
                    {
                        // Nếu chưa có mã nhân viên nào, bắt đầu từ NV001
                        return "KH001";
                    }
                }
            }
        }


        private bool MaKhachHangExists(string maKhachHang)
        {


            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem mã nhân viên đã tồn tại hay chưa
                string query = "SELECT COUNT(*) FROM KhachHang WHERE MaKhachHang = @MaKhachHang";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu mã nhân viên đã tồn tại, ngược lại trả về false
                return count > 0;
            }
        }

        public int themKhachHang(string ten,string dienthoai,string email,string diachi,DateTime ngaysinh,string loai)
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                int t = 0;
                int a = 0;
                con.Open();
                string makh=GenerateKhachHang();
                string sql = "INSERT INTO Nguoi (MaNguoi, Ten, SoDienThoai, Email, DiaChi, NgaySinh) VALUES ('" + makh + "', N'" + ten + "', '" + dienthoai + "', '" + email + "', N'" + diachi + "', '" + ngaysinh + "')";
                string sql1 = "INSERT INTO KhachHang(MaKhachHang, MaNguoi, Loai) VALUES ('"+makh+"','"+makh+"','"+loai+"')";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                using(SqlCommand cmd1=new SqlCommand(sql1,con))
                {
                    t = cmd.ExecuteNonQuery();
                    a = cmd1.ExecuteNonQuery();
                    if(t==1&&a==1)
                    {
                        return 1;

                    }
                }
                return 0;
            }
        }

        public int capNhatKhachhang(string makh,string dienthoai,string ten,string email,string diachi,DateTime ngaysinh,string loai)
        {
            using(SqlConnection con=new SqlConnection(conStr))
            {
                int t = 0;
                int a = 0;
                con.Open();
                string sql = "Update Nguoi Set Ten=N'" + ten + "',SoDienThoai='" + dienthoai + "',Email='" + email + "',DiaChi='" + diachi + "',NgaySinh='" + ngaysinh + "' Where MaNguoi='" + makh + "'";
                string sql1 = "Update KhachHang Set Loai='" + loai + "' Where MaKhachHang='" + makh + "'";
                using(SqlCommand cmd=new SqlCommand(sql,con))
                using(SqlCommand cmd1=new SqlCommand(sql1,con))
                {
                    t = cmd.ExecuteNonQuery();
                    a = cmd1.ExecuteNonQuery();
                    if(t==1&&a==1)
                    {
                        return 1;
                    }
                }
                return 0;
            }
        }
    }
}
