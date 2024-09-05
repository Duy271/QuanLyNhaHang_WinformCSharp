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
    class CN_QLThucDon
    {
        string conStr = Properties.Settings.Default.ConStr;
        private object lockObject = new object();

        public string GenerateMaMonAn()
        {
            lock (lockObject)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Tạo một SqlCommand để lấy mã nhân viên cuối cùng từ CSDL
                    string query = "SELECT TOP 1 MaMonAn FROM ThucDon ORDER BY MaMonAn DESC";
                    SqlCommand cmd = new SqlCommand(query, con);
                    object result = cmd.ExecuteScalar();

                    if (result != null) // Nếu có mã nhân viên cuối cùng
                    {
                        // Trích xuất số từ mã nhân viên cuối cùng và tăng giá trị
                        int lastNumber = int.Parse(result.ToString().Substring(1));
                        int nextNumber = lastNumber + 1;

                        // Tạo mã nhân viên mới
                        string newMaNhanVien = string.Format("M{0:D2}", nextNumber);

                        // Kiểm tra xem mã nhân viên mới đã tồn tại chưa
                        if (MaMonAnExists(newMaNhanVien))
                        {
                            // Nếu đã tồn tại, tăng giá trị và kiểm tra lại
                            nextNumber++;
                            newMaNhanVien = string.Format("M{0:D2}", nextNumber);
                        }

                        return newMaNhanVien;
                    }
                    else
                    {
                        // Nếu chưa có mã nhân viên nào, bắt đầu từ NV001
                        return "M001";
                    }
                }
            }
        }

        private bool MaMonAnExists(string maMonAn)
        {


            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.Open();

                // Tạo một SqlCommand để kiểm tra xem mã nhân viên đã tồn tại hay chưa
                string query = "SELECT COUNT(*) FROM ThucDon WHERE MaMonAn = @MaMonAn";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@MaMonAn", maMonAn);

                int count = (int)cmd.ExecuteScalar();

                // Trả về true nếu mã nhân viên đã tồn tại, ngược lại trả về false
                return count > 0;
            }
        }

        public bool ThemMonAn(string maMon, string tenMon, string MaLoai, string anhMon, string trangThai, double Gia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Thực hiện câu lệnh INSERT vào cơ sở dữ liệu
                    string sqlInsertMon = "Insert Into ThucDon(MaMonAn, TenMonAn, MaLoaiMonAn, DuongDanAnh,TrangThai, GiaBan) Values ('" + maMon + "','" + tenMon + "','" + MaLoai + "','" + anhMon + "','" + trangThai + "'," + Gia + ")";
                    

                   
                    using (SqlCommand cmdMonAn = new SqlCommand(sqlInsertMon, con))
                    {

                        cmdMonAn.ExecuteNonQuery();

                        MessageBox.Show("Thêm món ăn thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void XoaMonAn(string maMonAn)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                int t;
               
                con.Open();
                string sqlDeleteMonAn = "DELETE FROM ThucDon WHERE MaMonAn = @MaMonAn";
                using (SqlCommand cmdMonAn = new SqlCommand(sqlDeleteMonAn, con))
                {
                    cmdMonAn.Parameters.AddWithValue("@MaMonAn", maMonAn);
                    t = cmdMonAn.ExecuteNonQuery();
                }
              
                if (t == 1)
                {
                    MessageBox.Show("Xóa Thành Công", "Thông Bóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public bool SuaMonAn(string maMon, string tenMon, string MaLoai, string anhMon, string trangThai, double Gia)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();

                    // Thực hiện câu lệnh INSERT vào cơ sở dữ liệu
                    string sqlUpdateMon = "UPDATE ThucDon SET TenMonAn ='"+tenMon+"',MaLoaiMonAn='"+MaLoai+"',DuongDanAnh='"+anhMon+"',TrangThai='"+trangThai+"',GiaBan="+Gia+" WHERE MaMonAn = '"+maMon+"'";
                 

                   
                    using (SqlCommand cmdMonAn = new SqlCommand(sqlUpdateMon, con))
                    {
                        // Tạo mã người và mã nhân viên


                        cmdMonAn.ExecuteNonQuery();

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
        public string tenAnh(string maMon)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();

                string sql = "Select DuongDanAnh from ThucDon where MaMonAn='" + maMon + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                string anh = cmd.ExecuteScalar().ToString();

                return anh;



            }
        }
    }
}
