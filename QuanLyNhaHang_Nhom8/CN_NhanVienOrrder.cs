using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyNhaHang_Nhom8
{
    class CN_NhanVienOrrder
    {
        public string conStr = @"Data Source=DuyCute\DuyCute;Initial Catalog=QuanLyNhaHang;Integrated Security=True";
        public DataTable ThucDon()
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Truy vấn dữ liệu từ bảng ThucDon
                string query = "SELECT * FROM ThucDon";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                cmd.Fill(dt);
                con.Close();
                // Sau khi có dữ liệu trong DataTable, bạn có thể tiếp tục hiển thị nó trong FlowLayoutPanel.
                return dt;

            }
        }
        public DataTable ThucDon_use(string maloai)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "SELECT * FROM ThucDon Where MaLoaiMonAn='" + maloai + "'";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                con.Close();
                return dt;

            }
        }

        //ds bàn
        public DataTable DanhSachBan()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Truy vấn dữ liệu từ bảng Ban
                string query = "SELECT * FROM Ban";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);

                DataTable dt = new DataTable();
                cmd.Fill(dt);
                con.Close();

                return dt;
            }
        }
        public DataTable DanhSachBan_use(string trangthai)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string query = "Select*From Ban where TrangThai=N'" + trangthai + "'";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                cmd.Fill(dt);
                con.Close();
                return dt;

            }
        }

        public void Update_Ban(string maBan, string trangThai)
        {

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string sql = "Update Ban Set TrangThai=N'" + trangThai + "' Where MaBan='" + maBan + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void CapNhatSoLuongMonAn(string maBan, string maMonAn, int soLuong)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Cập nhật số lượng cho món tồn tại
                string queryUpdateMon = "UPDATE ChiTietDatMon SET SoLuong = SoLuong + @SoLuong WHERE MaDatMon IN (SELECT MaDatMon FROM DatMon WHERE MaBan = @MaBan) AND MaMonAn = @MaMonAn";
                using (SqlCommand cmdUpdateMon = new SqlCommand(queryUpdateMon, con))
                {
                    cmdUpdateMon.Parameters.AddWithValue("@MaBan", maBan);
                    cmdUpdateMon.Parameters.AddWithValue("@MaMonAn", maMonAn);
                    cmdUpdateMon.Parameters.AddWithValue("@SoLuong", soLuong);

                    // Thực thi truy vấn cập nhật
                    cmdUpdateMon.ExecuteNonQuery();
                }
            }
        }

        public bool MonAnExists(string maBan, string maMonAn)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem món đã tồn tại và có trạng thái chưa thanh toán hay không
                string query = "SELECT COUNT(*) FROM ChiTietDatMon " +
                               "INNER JOIN DatMon ON ChiTietDatMon.MaDatMon = DatMon.MaDatMon " +
                               "WHERE DatMon.MaBan = @MaBan AND ChiTietDatMon.MaMonAn = @MaMonAn AND ChiTietDatMon.TrangThai <> N'Đã Thanh Toán'";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaBan", maBan);
                cmd.Parameters.AddWithValue("@MaMonAn", maMonAn);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu món đã tồn tại và chưa thanh toán, ngược lại trả về false
                return count > 0;
            }
        }

        public void ThemDatMon(string maDatMon, string maBan, string tenDangNhap)
        {
            if (maDatMon == "" || maBan == "" || tenDangNhap == "")
            {
                MessageBox.Show("Chọn món để order", "Thông Báo");

            }
            else
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để thêm đặt món vào bảng DatMon
                    string queryDatMon = "INSERT INTO DatMon (MaDatMon, NgayDatMon, MaBan, TenDangNhap) VALUES (@MaDatMon, GETDATE(), @MaBan, @TenDangNhap)";
                    SqlCommand cmdDatMon = new SqlCommand(queryDatMon, con);

                    // Thiết lập các tham số
                    cmdDatMon.Parameters.AddWithValue("@MaDatMon", maDatMon);

                    cmdDatMon.Parameters.AddWithValue("@MaBan", maBan);
                    cmdDatMon.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);

                    // Thực thi truy vấn
                    cmdDatMon.ExecuteNonQuery();
                }
            }

        }
        private readonly object lockObject = new object();
        public string GenerateMaDatMon()
        {
            lock (lockObject)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để lấy mã nhân viên cuối cùng từ CSDL
                    string query = "SELECT TOP 1 MaDatMon FROM DatMon ORDER BY MaDatMon DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null) // Nếu có mã nhân viên cuối cùng
                    {
                        // Trích xuất số từ mã nhân viên cuối cùng và tăng giá trị
                        int lastNumber = int.Parse(result.ToString().Substring(2));
                        int nextNumber = lastNumber + 1;

                        // Tạo mã nhân viên mới
                        string newMaNhanVien = string.Format("DM{0:D3}", nextNumber);

                        // Kiểm tra xem mã nhân viên mới đã tồn tại chưa
                        if (MaDatMonExists(newMaNhanVien))
                        {
                            // Nếu đã tồn tại, tăng giá trị và kiểm tra lại
                            nextNumber++;
                            newMaNhanVien = string.Format("DM{0:D3}", nextNumber);
                        }

                        return newMaNhanVien;
                    }
                    else
                    {
                        // Nếu chưa có mã nhân viên nào, bắt đầu từ NV001
                        return "DM001";
                    }
                }
            }
        }
        private bool MaDatMonExists(string maDatMon)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem mã nhân viên đã tồn tại hay chưa
                string query = "SELECT COUNT(*) FROM DatMon WHERE MaDatMon = @MaDatMon";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaDatMon", maDatMon);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu mã nhân viên đã tồn tại, ngược lại trả về false
                return count > 0;
            }
        }
        private readonly object lockObject1 = new object();
        public string GenerateMaCTDatMon()
        {
            lock (lockObject1)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để lấy mã nhân viên cuối cùng từ CSDL
                    string query = "SELECT TOP 1 MaChiTietDatMon FROM ChiTietDatMon ORDER BY MaChiTietDatMon DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null) // Nếu có mã nhân viên cuối cùng
                    {
                        // Trích xuất số từ mã nhân viên cuối cùng và tăng giá trị
                        int lastNumber = int.Parse(result.ToString().Substring(4));
                        int nextNumber = lastNumber + 1;

                        // Tạo mã nhân viên mới
                        string newMaNhanVien = string.Format("CTDM{0:D3}", nextNumber);

                        // Kiểm tra xem mã nhân viên mới đã tồn tại chưa
                        if (MaCTDatMonExists(newMaNhanVien))
                        {
                            // Nếu đã tồn tại, tăng giá trị và kiểm tra lại
                            nextNumber++;
                            newMaNhanVien = string.Format("CTDM{0:D3}", nextNumber);
                        }

                        return newMaNhanVien;
                    }
                    else
                    {
                        // Nếu chưa có mã nhân viên nào, bắt đầu từ CTDM001
                        return "CTDM001";
                    }
                }
            }
        }

        private bool MaCTDatMonExists(string maCTDatMon)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem mã nhân viên đã tồn tại hay chưa
                string query = "SELECT COUNT(*) FROM ChiTietDatMon WHERE MaChiTietDatMon = @MaChiTietDatMon";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaChiTietDatMon", maCTDatMon);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu mã nhân viên đã tồn tại, ngược lại trả về false
                return count > 0;
            }
        }

        public void ThemChiTietDatMon(string maChiTietDatMon, string maDatMon, string maMonAn, int soLuong, string ghiChu, string trangThai)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Kiểm tra xem món đã tồn tại trong đơn đặt món chưa
                string queryCheckMon = "SELECT COUNT(*) FROM ChiTietDatMon WHERE MaDatMon = @MaDatMon AND MaMonAn = @MaMonAn";
                using (SqlCommand cmdCheckMon = new SqlCommand(queryCheckMon, con))
                {
                    cmdCheckMon.Parameters.AddWithValue("@MaDatMon", maDatMon);
                    cmdCheckMon.Parameters.AddWithValue("@MaMonAn", maMonAn);

                    int count = (int)cmdCheckMon.ExecuteScalar();

                    if (count > 0)
                    {
                        // Nếu món đã tồn tại và số lượng khác 0, cập nhật số lượng
                        if (soLuong != 0)
                        {
                            string queryUpdateMon = "UPDATE ChiTietDatMon SET SoLuong = SoLuong + @SoLuong WHERE MaDatMon = @MaDatMon AND MaMonAn = @MaMonAn";
                            using (SqlCommand cmdUpdateMon = new SqlCommand(queryUpdateMon, con))
                            {
                                cmdUpdateMon.Parameters.AddWithValue("@MaDatMon", maDatMon);
                                cmdUpdateMon.Parameters.AddWithValue("@MaMonAn", maMonAn);
                                cmdUpdateMon.Parameters.AddWithValue("@SoLuong", soLuong);

                                // Thực thi truy vấn cập nhật
                                cmdUpdateMon.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // Nếu món chưa tồn tại, thêm mới món vào đơn đặt món
                        string queryInsertMon = "INSERT INTO ChiTietDatMon (MaChiTietDatMon, MaDatMon, MaMonAn, SoLuong, GhiChu, TrangThai) VALUES (@MaChiTietDatMon, @MaDatMon, @MaMonAn, @SoLuong, @GhiChu, @TrangThai)";
                        using (SqlCommand cmdInsertMon = new SqlCommand(queryInsertMon, con))
                        {
                            cmdInsertMon.Parameters.AddWithValue("@MaChiTietDatMon", maChiTietDatMon);
                            cmdInsertMon.Parameters.AddWithValue("@MaDatMon", maDatMon);
                            cmdInsertMon.Parameters.AddWithValue("@MaMonAn", maMonAn);
                            cmdInsertMon.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmdInsertMon.Parameters.AddWithValue("@GhiChu", ghiChu);
                            cmdInsertMon.Parameters.AddWithValue("@TrangThai", trangThai);

                            // Thực thi truy vấn thêm mới
                            cmdInsertMon.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void ChuyenMonAn(string maBanNguon, string maBanDich)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Cập nhật trạng thái của tất cả các món từ bàn nguồn sang bàn đích
                string queryUpdateMon = "UPDATE DatMon SET MaBan =@MaBanDich  WHERE MaBan = @MaBanNguon AND MaDatMon IN (SELECT MaDatMon FROM ChiTietDatMon WHERE TrangThai <> N'Đã Thanh Toán')";
                using (SqlCommand cmdUpdateMon = new SqlCommand(queryUpdateMon, con))
                {
                    cmdUpdateMon.Parameters.AddWithValue("@MaBanDich", maBanDich);
                    cmdUpdateMon.Parameters.AddWithValue("@MaBanNguon", maBanNguon);

                    // Thực thi truy vấn cập nhật
                    cmdUpdateMon.ExecuteNonQuery();
                }
            }
        }

        public void XoaMonCu(string maBan)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                // Lấy danh sách mã đặt món cần xóa


                // Xóa các món cũ của bàn
                string queryDeleteMonCu = "DELETE FROM ChiTietDatMon WHERE MaDatMon IN (SELECT MaDatMon FROM DatMon WHERE MaBan = @MaBan) AND TrangThai <> N'Đã Thanh Toán'";
                using (SqlCommand cmdDeleteMonCu = new SqlCommand(queryDeleteMonCu, con))
                {
                    cmdDeleteMonCu.Parameters.AddWithValue("@MaBan", maBan);

                    // Thực thi truy vấn xóa
                    cmdDeleteMonCu.ExecuteNonQuery();
                }
                List<string> danhSachMaDatMon = LayDanhSachMaDatMon();
                // Xóa các mã đặt món không còn liên kết với món nào
                foreach (string maDatMon in danhSachMaDatMon)
                {
                    XoaMaDatMonKhongCoMon(con, maDatMon);
                }
            }
        }

        private List<string> LayDanhSachMaDatMon()
        {
            List<string> danhSachMaDatMon = new List<string>();

            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string querySelectMaDatMon = "SELECT MaDatMon FROM DatMon WHERE MaDatMon NOT IN (SELECT DISTINCT MaDatMon FROM ChiTietDatMon)";
                using (SqlCommand cmdSelectMaDatMon = new SqlCommand(querySelectMaDatMon, con))
                {
                    using (SqlDataReader reader = cmdSelectMaDatMon.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["MaDatMon"] != DBNull.Value)
                            {
                                danhSachMaDatMon.Add(reader["MaDatMon"].ToString());
                            }
                        }
                    }
                }
            }

            return danhSachMaDatMon;
        }

        private void XoaMaDatMonKhongCoMon(SqlConnection con, string maDatMon)
        {
            // Kiểm tra xem có món nào liên kết với mã đặt món không
            string queryCheckMon = "SELECT COUNT(*) FROM ChiTietDatMon WHERE MaDatMon = @MaDatMon";
            using (SqlCommand cmdCheckMon = new SqlCommand(queryCheckMon, con))
            {
                cmdCheckMon.Parameters.AddWithValue("@MaDatMon", maDatMon);

                int count = (int)cmdCheckMon.ExecuteScalar();

                // Nếu không có món nào liên kết, thì xóa mã đặt món
                if (count == 0)
                {
                    string queryDeleteMaDatMon = "DELETE FROM DatMon WHERE MaDatMon = @MaDatMon";
                    using (SqlCommand cmdDeleteMaDatMon = new SqlCommand(queryDeleteMaDatMon, con))
                    {
                        cmdDeleteMaDatMon.Parameters.AddWithValue("@MaDatMon", maDatMon);
                        cmdDeleteMaDatMon.ExecuteNonQuery();
                    }
                }
            }
        }

        private readonly object lockObject2 = new object();
        public string GenerateMaThanhToan()
        {
            lock (lockObject2)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để lấy mã nhân viên cuối cùng từ CSDL
                    string query = "SELECT TOP 1 MaThanhToan FROM ThanhToan ORDER BY MaThanhToan DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null) // Nếu có mã nhân viên cuối cùng
                    {
                        // Trích xuất số từ mã nhân viên cuối cùng và tăng giá trị
                        int lastNumber = int.Parse(result.ToString().Substring(4));
                        int nextNumber = lastNumber + 1;

                        // Tạo mã nhân viên mới
                        string newMaNhanVien = string.Format("TT{0:D3}", nextNumber);

                        // Kiểm tra xem mã nhân viên mới đã tồn tại chưa
                        if (MaThanhToanExists(newMaNhanVien))
                        {
                            // Nếu đã tồn tại, tăng giá trị và kiểm tra lại
                            nextNumber++;
                            newMaNhanVien = string.Format("TT{0:D3}", nextNumber);
                        }

                        return newMaNhanVien;
                    }
                    else
                    {
                        // Nếu chưa có mã nhân viên nào, bắt đầu từ CTDM001
                        return "TT001";
                    }
                }
            }
        }

        private bool MaThanhToanExists(string maThanhToan)
        {
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem mã nhân viên đã tồn tại hay chưa
                string query = "SELECT COUNT(*) FROM ThanhToan WHERE MaThanhToan = @MaThanhToan";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaThanhToan", maThanhToan);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu mã nhân viên đã tồn tại, ngược lại trả về false
                return count > 0;
            }
        }
    }
}
